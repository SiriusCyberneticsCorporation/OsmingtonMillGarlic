using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsmingtonMillGarlic
{
	public partial class InvoiceItemUserControl : UserControl
	{
		public delegate void InvoiceItemHandler(InvoiceItemUserControl sender, DataRow row);

		public event InvoiceItemHandler ItemAdded;
		public event InvoiceItemHandler ItemAltered;
		public event InvoiceItemHandler ItemDeleted;

		public void Clear() { InvoiceItemsDataSet.Tables["InvoiceItems"].Clear(); }

		public DataRow Row 
		{
			get { return InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]; }
			set 
			{
				m_updatingData = true;

				InvoiceItemsDataSet.Tables["InvoiceItems"].Clear();
				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Add(value.ItemArray);

				AddProductButton.Visible = false;
				DeleteButton.Visible = true;
				AlterButton.Visible = false;

				m_updatingData = false;
			}
		}

//		private int m_ID = -1;
		private int m_productID = -1;
		private bool m_updatingData = false;
		private string m_unitText = string.Empty;
		private string m_unitsText = string.Empty;
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public InvoiceItemUserControl()
		{
			InitializeComponent();
						
			InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Add(InvoiceItemsDataSet.Tables["InvoiceItems"].NewRow());
		}

		/*
		public void Set(DataRow row)
		{
			m_updatingData = true;

			m_row = row;
			m_ID = DatabaseAccess.GetInt(row["ID"]);
			m_productID = DatabaseAccess.GetInt(row["ProductID"]);
			DescriptionTextBox.Text = DatabaseAccess.GetString(row["Description"]);
			QuantityNumericTextBox.Text = DatabaseAccess.GetDecimal(row["Quantity"]).ToString();
			UnitsTextBox.Text = DatabaseAccess.GetString(row["UnitsText"]);
			UnitPriceNumericTextBox.Text = DatabaseAccess.GetString(row["UnitPrice"]).ToString();
			PerUnitTextBox.Text = DatabaseAccess.GetString(row["PerUnitText"]);
			AmountNumericTextBox.Text = DatabaseAccess.GetString(row["Amount"]).ToString();

			m_updatingData = false;
		}

		public void Get(ref DataRow row)
		{
			row["ID"] = m_ID;
			row["ProductID"] = m_productID;
			row["Description"] = DescriptionTextBox.Text;
			row["Quantity"] = QuantityNumericTextBox.DecimalValue;
			row["UnitsText"] = UnitsTextBox.Text;
			row["UnitPrice"] = UnitPriceNumericTextBox.DecimalValue;
			row["PerUnitText"] = PerUnitTextBox.Text;
			row["Amount"] = AmountNumericTextBox.DecimalValue;
		}
		*/
		/*
		private void RefreshRowData()
		{
			if (m_row == null)
			{
				m_row = InvoicesDataSet.Tables["InvoiceItems"].NewRow();
			}
			m_row["ID"] = m_ID;
			m_row["ProductID"] = m_productID;
			m_row["Description"] = DescriptionTextBox.Text;
			m_row["Quantity"] = QuantityNumericTextBox.DecimalValue;
			m_row["UnitsText"] = UnitsTextBox.Text;
			m_row["UnitPrice"] = UnitPriceNumericTextBox.DecimalValue;
			m_row["PerUnitText"] = PerUnitTextBox.Text;
			m_row["Amount"] = AmountNumericTextBox.DecimalValue;
		}
		*/
		private void AddProductButton_Click(object sender, EventArgs e)
		{
			AddEditProductForm iAddEditProductForm = new AddEditProductForm();

			if (iAddEditProductForm.ShowDialog(this) == DialogResult.OK)
			{
				if (iAddEditProductForm.SelectedID > 0)
				{
					m_productID = iAddEditProductForm.SelectedID;
					string productsSql = "SELECT Description, WholesalePrice, Unit, Units, PerUnit FROM Products " +
										 "WHERE ID = " + DatabaseAccess.FormatNumber(m_productID);

					DataTable productsDataTable = m_databaseAccess.ExecuteSelect(productsSql);
					if (productsDataTable != null && productsDataTable.Rows.Count > 0)
					{
						m_updatingData = true;

						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["ProductID"] = m_productID;
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Description"] = DatabaseAccess.GetString(productsDataTable.Rows[0]["Description"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Quantity"] = 1;
						m_unitText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Unit"]);
						m_unitsText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Units"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitsText"] = m_unitText + " @ ";
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitPrice"] = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["WholesalePrice"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["PerUnitText"] = DatabaseAccess.GetString(productsDataTable.Rows[0]["PerUnit"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Amount"] = QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue;

						/*
						DescriptionTextBox.Text = DatabaseAccess.GetString(productsDataTable.Rows[0]["Description"]);
						QuantityNumericTextBox.Text = "1";
						m_unitText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Unit"]);
						m_unitsText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Units"]);
						UnitsTextBox.Text = m_unitText + " @ ";
						UnitPriceNumericTextBox.Text = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["WholesalePrice"]).ToString("C2");
						PerUnitTextBox.Text = DatabaseAccess.GetString(productsDataTable.Rows[0]["PerUnit"]);
						AmountNumericTextBox.Text = (QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue).ToString("C2");
						*/

						m_updatingData = false;
					}

					AddProductButton.Visible = false;
					DeleteButton.Visible = true;
					AlterButton.Visible = true;
					UnitPriceNumericTextBox.ReadOnly = true;

					//RefreshRowData();

					if(ItemAdded != null)
					{
						ItemAdded(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
					}
				}
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				m_updatingData = true;

				if (ItemDeleted != null)
				{
					ItemDeleted(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
				}

				m_productID = -1;
				m_unitText = string.Empty;
				m_unitsText = string.Empty;

				m_updatingData = false;
			}
		}

		private void AlterButton_Click(object sender, EventArgs e)
		{
			AddEditProductForm iAddEditProductForm = new AddEditProductForm();

			if (iAddEditProductForm.ShowDialog(this) == DialogResult.OK)
			{
				if (iAddEditProductForm.SelectedID > 0)
				{
					m_productID = iAddEditProductForm.SelectedID;
					string productsSql = "SELECT Description, WholesalePrice, Unit, Units, PerUnit FROM Products " +
										 "WHERE ID = " + DatabaseAccess.FormatNumber(m_productID);

					DataTable productsDataTable = m_databaseAccess.ExecuteSelect(productsSql);
					if (productsDataTable != null && productsDataTable.Rows.Count > 0)
					{
						m_updatingData = true;

						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["ProductID"] = m_productID;
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Description"] = DatabaseAccess.GetString(productsDataTable.Rows[0]["Description"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Quantity"] = 1;
						m_unitText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Unit"]);
						m_unitsText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Units"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitsText"] = m_unitText + " @ ";
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitPrice"] = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["WholesalePrice"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["PerUnitText"] = DatabaseAccess.GetString(productsDataTable.Rows[0]["PerUnit"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Amount"] = QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue;

						/*
						DescriptionTextBox.Text = DatabaseAccess.GetString(productsDataTable.Rows[0]["Description"]);
						QuantityNumericTextBox.Text = "1";
						m_unitText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Unit"]);
						m_unitsText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Units"]);
						UnitsTextBox.Text = m_unitText + " @ ";
						UnitPriceNumericTextBox.Text = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["WholesalePrice"]).ToString("C2");
						PerUnitTextBox.Text = DatabaseAccess.GetString(productsDataTable.Rows[0]["PerUnit"]);
						AmountNumericTextBox.Text = (QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue).ToString("C2");
						*/

						m_updatingData = false;
					}

					AddProductButton.Visible = false;
					DeleteButton.Visible = true;
					AlterButton.Visible = true;
					UnitPriceNumericTextBox.ReadOnly = true;

					//RefreshRowData();

					if (ItemAltered != null)
					{
						ItemAltered(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
					}
				}
			}
		}

		private void QuantityNumericTextBox_NumberEntered(Controls.NumericTextBox source)
		{
			if (!m_updatingData && InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Count > 0)
			{
				if (QuantityNumericTextBox.DecimalValue > 0)
				{
					if (QuantityNumericTextBox.DecimalValue > 1 && m_unitsText.Length > 0)
					{
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitsText"] = m_unitsText + " @ ";
					}
					else if (m_unitText.Length > 0)
					{
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitsText"] = m_unitText + " @ ";
					}
				}
				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Quantity"] = QuantityNumericTextBox.DecimalValue;
				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Amount"] = QuantityNumericTextBox.DecimalValue * 
																				UnitPriceNumericTextBox.DecimalValue;

				if (ItemAltered != null)
				{
					ItemAltered(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
				}
			}
		}

		private void UnitPriceNumericTextBox_NumberEntered(Controls.NumericTextBox source)
		{
			if (!m_updatingData && InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Count > 0)
			{
				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Amount"] = QuantityNumericTextBox.DecimalValue * 
																				UnitPriceNumericTextBox.DecimalValue;

				if (ItemAltered != null)
				{
					ItemAltered(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
				}
			}
		}

		private void Control_Validated(object sender, EventArgs e)
		{
			if (!m_updatingData && InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Count > 0)
			{
				if (AddProductButton.Visible)
				{
					AddProductButton.Visible = false;
					DeleteButton.Visible = true;
					AlterButton.Visible = false;
				}

				if (sender == QuantityNumericTextBox)
				{
					if (QuantityNumericTextBox.DecimalValue > 0)
					{
						if (QuantityNumericTextBox.DecimalValue > 1 && m_unitsText.Length > 0)
						{
							InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitsText"] = m_unitsText + " @ ";
						}
						else if (m_unitText.Length > 0)
						{
							InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitsText"] = m_unitText + " @ ";
						}
					}
					InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Amount"] = QuantityNumericTextBox.DecimalValue *
																					UnitPriceNumericTextBox.DecimalValue;
				}
				else if (sender == UnitPriceNumericTextBox)
				{
					InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Amount"] = QuantityNumericTextBox.DecimalValue *
																				UnitPriceNumericTextBox.DecimalValue;
				}

				if (ItemAltered != null)
				{
					ItemAltered(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
				}
			}
		}
	}
}
