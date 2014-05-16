﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsmingtonMillGarlic
{
	public partial class MarketAttendedForm : Form, IChildForm
	{
		public bool IsNewMarket { get { return m_marketID == -1; } }

		private int m_marketID = -1;
		private bool m_updatingData = false;
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public MarketAttendedForm(int marketID)
		{
			InitializeComponent();

			m_marketID = marketID;
		}

		private void MarketAttendedForm_Load(object sender, EventArgs e)
		{
			FetchData();
		}

		private void ProductsDataGridViewWithPaste_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (!m_updatingData && e.RowIndex >= 0 && e.RowIndex < ProductsDataGridViewWithPaste.Rows.Count)
			{
				m_updatingData = true;

				ProductsDataGridViewWithPaste.Rows[e.RowIndex].Cells["Products_MarketIDColumn"].Value = m_marketID;

				int productID = DatabaseAccess.GetInt(ProductsDataGridViewWithPaste.Rows[e.RowIndex].Cells["Products_ProductIDColumn"].Value);
				int takenTo = DatabaseAccess.GetInt(ProductsDataGridViewWithPaste.Rows[e.RowIndex].Cells["Products_TakenToMarketColumn"].Value);
				int broughtBack = DatabaseAccess.GetInt(ProductsDataGridViewWithPaste.Rows[e.RowIndex].Cells["Products_BroughtBackFromMarketColumn"].Value);

				if (takenTo > broughtBack)
				{
					int numberSold = takenTo - broughtBack;
					DataRow[] product = MarketAttendedDataSet.Tables["Products"].Select("ID = " + DatabaseAccess.FormatNumber(productID));

					ProductsDataGridViewWithPaste.Rows[e.RowIndex].Cells["Products_SoldAtMarketColumn"].Value = numberSold;

					if (product.Length > 0)
					{
						decimal cost = DatabaseAccess.GetDecimal(product[0]["MarketPrice"]);
						ProductsDataGridViewWithPaste.Rows[e.RowIndex].Cells["Products_AmountColumn"].Value = cost * numberSold;
					}
				}
				else
				{
					ProductsDataGridViewWithPaste.Rows[e.RowIndex].Cells["Products_SoldAtMarketColumn"].Value = 0;
					ProductsDataGridViewWithPaste.Rows[e.RowIndex].Cells["Products_AmountColumn"].Value = 0;
				}

				CalculateTakings();

				m_updatingData = false;
			}
		}

		private void SundryItemsDataGridViewWithPaste_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (!m_updatingData && e.RowIndex >= 0 && e.RowIndex < ProductsDataGridViewWithPaste.Rows.Count)
			{
				m_updatingData = true;

				SundryItemsDataGridViewWithPaste.Rows[e.RowIndex].Cells["Sundries_MarketIDColumn"].Value = m_marketID;

				CalculateTakings();

				m_updatingData = false;
			}
		}

		private void CashAfterMarketNumericTextBox_NumberEntered(Controls.NumericTextBox source)
		{
			if (!m_updatingData)
			{
				m_updatingData = true;

				CalculateTakings();

				m_updatingData = false;
			}
		}

		private void MarketsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!CanClose())
			{
				e.Cancel = true;
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			GatherAllChanges();
			SaveChanges();
		}

		private void CalculateTakings()
		{
			if (MarketAttendedDataSet.Tables["Markets"] != null && MarketAttendedDataSet.Tables["Markets"].Rows.Count > 0)
			{
				
				decimal takings = 0;
				decimal costs = StallCostsNumericTextBox.DecimalValue;
				decimal cash = CashAfterMarketNumericTextBox.DecimalValue;

				foreach (DataGridViewRow row in ProductsDataGridViewWithPaste.Rows)
				{
					takings += DatabaseAccess.GetDecimal(row.Cells["Products_AmountColumn"].Value);
				}

				foreach (DataGridViewRow row in SundryItemsDataGridViewWithPaste.Rows)
				{
					takings += DatabaseAccess.GetDecimal(row.Cells["Sundries_ProfitLossColumn"].Value);
				}
				
				MarketAttendedDataSet.Tables["Markets"].Rows[0]["EstimatedTakings"] = takings;
				MarketAttendedDataSet.Tables["Markets"].Rows[0]["ActualCashAfterMarket"] = cash;
				MarketAttendedDataSet.Tables["Markets"].Rows[0]["Discrepancy"] = cash - takings + costs;

				TakingsNumericTextBox.Update();
				DiscrepancyNumericTextBox.Update();
			}
		}

		public void RefreshDisplay()
		{
		}

		private void GatherAllChanges()
		{
			// Move focus to force validation.
			Control currentControl = this.ActiveControl;
			if (currentControl == MarketLocationTextBox)
			{
				StallCostsNumericTextBox.Focus();
			}
			else
			{
				MarketLocationTextBox.Focus();
			}
			currentControl.Focus();

			// If the row of ORGANISATIONS data wrapped by the OrganisationsBindingSource has been altered
			// by the user then it is necessary to end the edit so that the changes are returned to the DataSet.
			DataRowView iDataRowView = (DataRowView)MarketAttendedBindingSource.Current;
			if (iDataRowView != null)
			{
				if (iDataRowView.IsEdit)
				{
					iDataRowView.EndEdit();
				}
			}
		}

		public bool CanClose()
		{
			bool result = true;

			GatherAllChanges();

			if (MarketAttendedDataSet.HasChanges())
			{
				DialogResult answer =
						MessageBox.Show("The Markets list has changed.\r\nDo you wish to save changes before continuing?",
										"Save Market Changes",
										MessageBoxButtons.YesNoCancel,
										MessageBoxIcon.Question);

				if (answer == DialogResult.Yes)
				{
					result = SaveChanges();
				}
				else if (answer == DialogResult.No)
				{
					// If the user does not wish to save the changes then discard them so that subsequent 
					// calls to CanClose() do not result in duplicate messages.
					MarketAttendedDataSet.RejectChanges();
				}
				else if (answer == DialogResult.Cancel)
				{
					result = false;
				}
			}

			return result;
		}

		private void FetchData()
		{
			m_updatingData = true;

			string productsSql = "SELECT ID, Active, Description, MarketPrice FROM Products ORDER BY DisplayOrder";

			MarketAttendedDataSet.Tables["Products"].Clear();
			MarketAttendedDataSet.Tables["Markets"].Clear();
			MarketAttendedDataSet.Tables["MarketProducts"].Clear();
			MarketAttendedDataSet.Tables["MarketSundries"].Clear();

			DataTable productsDataTable = m_databaseAccess.ExecuteSelect(productsSql);
			if (productsDataTable != null && productsDataTable.Rows.Count > 0)
			{
				MarketAttendedDataSet.Tables["Products"].Merge(productsDataTable);
			}
			// Tell the DataSet to accept all changes so that subsequent changes made by the user will show up.
			MarketAttendedDataSet.AcceptChanges();

			if (m_marketID > 0)
			{
				string marketSql = "SELECT * FROM Markets WHERE ID = " + DatabaseAccess.FormatNumber(m_marketID);

				DataTable marketsDataTable = m_databaseAccess.ExecuteSelect(marketSql);
				if (marketsDataTable != null && marketsDataTable.Rows.Count > 0)
				{
					MarketAttendedDataSet.Tables["Markets"].Merge(marketsDataTable);
				}

				string marketProductsSql = "SELECT * FROM MarketProducts WHERE MarketID = " + DatabaseAccess.FormatNumber(m_marketID);

				DataTable marketProductsDataTable = m_databaseAccess.ExecuteSelect(marketProductsSql);
				if (marketProductsDataTable != null && marketProductsDataTable.Rows.Count > 0)
				{
					MarketAttendedDataSet.Tables["MarketProducts"].Merge(marketProductsDataTable);
				}

				string marketSundriesSql = "SELECT * FROM MarketSundries WHERE MarketID = " + DatabaseAccess.FormatNumber(m_marketID);

				DataTable marketSundriesDataTable = m_databaseAccess.ExecuteSelect(marketSundriesSql);
				if (marketSundriesDataTable != null && marketSundriesDataTable.Rows.Count > 0)
				{
					MarketAttendedDataSet.Tables["MarketSundries"].Merge(marketSundriesDataTable);
				}

				// Tell the DataSet to accept all changes so that subsequent changes made by the user will show up.
				MarketAttendedDataSet.AcceptChanges();
			}
			else
			{
				DataRow newMarketRow = MarketAttendedDataSet.Tables["Markets"].NewRow();
				newMarketRow["MarketDate"] = DateTime.Today;
				newMarketRow["MarketLocation"] = "Margaret River";
				newMarketRow["StallCosts"] = 25;
				MarketAttendedDataSet.Tables["Markets"].Rows.Add(newMarketRow);

				foreach (DataRow row in MarketAttendedDataSet.Tables["Products"].Rows)
				{
					if (DatabaseAccess.GetBool(row["Active"]))
					{
						DataRow newProductRow = MarketAttendedDataSet.Tables["MarketProducts"].NewRow();
						//newProductRow["MarketID"] = -1;
						newProductRow["ProductID"] = DatabaseAccess.GetInt(row["ID"]);
						MarketAttendedDataSet.Tables["MarketProducts"].Rows.Add(newProductRow);
					}
				}
			}

			// Reset the Binding to synchronise fetch data with displayed and UNEDITED data.
			MarketAttendedBindingSource.ResetBindings(false);

			m_updatingData = false;
		}

		private bool SaveChanges()
		{
			bool successful = true;
			bool newMarket = IsNewMarket;

			DataSet changes = MarketAttendedDataSet.GetChanges();

			if (changes != null && m_databaseAccess.BeginTransaction())
			{
				DataTable marketsDataTable = changes.Tables["Markets"];

				if (marketsDataTable.Rows.Count > 0)
				{
					successful = m_databaseAccess.SaveSimpleTableWithID(marketsDataTable, "Markets");
				}

				if (successful && newMarket)
				{
					object id = m_databaseAccess.ExecuteScalar("SELECT LAST_INSERT_ID()");
					m_marketID = DatabaseAccess.GetInt(id);
				}

				if(successful)
				{
					DataTable marketProductsDataTable = changes.Tables["MarketProducts"];

					if (marketProductsDataTable.Rows.Count > 0)
					{
						if (newMarket)
						{
							foreach(DataRow row in marketProductsDataTable.Rows)
							{
								row["MarketID"] = m_marketID;
							}
						}
						successful = m_databaseAccess.SaveSimpleTableWithID(marketProductsDataTable, "MarketProducts");
					}
				}

				if (successful)
				{
					DataTable marketSundriesDataTable = changes.Tables["MarketSundries"];

					if (marketSundriesDataTable.Rows.Count > 0)
					{
						if (newMarket)
						{
							foreach (DataRow row in marketSundriesDataTable.Rows)
							{
								row["MarketID"] = m_marketID;
							}
						}
						successful = m_databaseAccess.SaveSimpleTableWithID(marketSundriesDataTable, "MarketSundries");
					}
				}

				// If all saves have been successful then commit the transaction.
				if (successful && m_databaseAccess.CommitTransaction())
				{
					FetchData();
				}
				else
				{
					m_databaseAccess.RollbackTransaction();
					successful = false;
				}
			}

			return successful;
		}

	}
}