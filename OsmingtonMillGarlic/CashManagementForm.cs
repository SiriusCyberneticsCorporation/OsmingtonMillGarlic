using System;
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
	public partial class CashManagementForm : Form, IChildForm
	{
		private bool m_updatingData = false;
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public CashManagementForm()
		{
			m_updatingData = true;
			InitializeComponent();
			m_updatingData = false;
		}

		private void CashManagementForm_Load(object sender, EventArgs e)
		{
			FetchData();
		}

		private void CashManagementForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!CanClose())
			{
				e.Cancel = true;
			}
		}

		private void NextMarketFloatDataGridViewWithPaste_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (!m_updatingData)
			{
				m_updatingData = true;

				CalculateTotal(NextMarketFloatDataGridViewWithPaste, "NextMarketFloat_", e.RowIndex);

				m_updatingData = false;
			}
		}

		private void CashOnHandDataGridViewWithPaste_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (!m_updatingData)
			{
				m_updatingData = true;

				CalculateTotal(CashOnHandDataGridViewWithPaste, "CashOnHand_", e.RowIndex);

				m_updatingData = false;
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			GatherAllChanges();
			SaveChanges();
		}

		private void CalculateTotal(DataGridView sourceGrid, string prefix, int rowIndex)
		{
			decimal total = 0;
			DataGridViewRow sourceRow = sourceGrid.Rows[rowIndex];

			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "HundredDollarNotesColumn"].Value) * 100;
			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "FiftyDollarNotesColumn"].Value) * 50;
			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "TwentyDollarNotesColumn"].Value) * 20;
			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "TenDollarNotesColumn"].Value) * 10;
			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "FiveDollarNotesColumn"].Value) * 5;
			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "TwoDollarCoinsColumn"].Value) * 2;
			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "OneDollarCoinsColumn"].Value) * 1;
			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "FiftyCentCoinsColumn"].Value) * 0.50M;
			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "TwentyCentCoinsColumn"].Value) * 0.20M;
			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "TenCentCoinsColumn"].Value) * 0.10M;
			total += DatabaseAccess.GetInt(sourceRow.Cells[prefix + "FiveCentCoinsColumn"].Value) * 0.05M;

			sourceRow.Cells[prefix + "TotalColumn"].Value = total;
		}

		public void RefreshDisplay()
		{
			if (CanClose())
			{
				FetchData();
			}
		}

		private void GatherAllChanges()
		{
			// Move focus to force validation.
			Control currentControl = this.ActiveControl;			
			if (currentControl == NextMarketFloatDataGridViewWithPaste)
			{
				CashOnHandDataGridViewWithPaste.Focus();
			}
			else
			{
				NextMarketFloatDataGridViewWithPaste.Focus();
			}
			currentControl.Focus();
			/*
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
			*/
		}

		public bool CanClose()
		{
			bool result = true;

			GatherAllChanges();

			if (CashManagementDataSet.HasChanges())
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
					CashManagementDataSet.RejectChanges();
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

			string nextMarketFloatSql = "SELECT * FROM NextMarketFloat LIMIT 1";
			string cashOnHandSql = "SELECT * FROM CashOnHand";

			CashManagementDataSet.Tables["NextMarketFloat"].Clear();
			CashManagementDataSet.Tables["CashOnHand"].Clear();

			DataTable nextMarketFloatDataTable = m_databaseAccess.ExecuteSelect(nextMarketFloatSql);
			if (nextMarketFloatDataTable != null && nextMarketFloatDataTable.Rows.Count > 0)
			{
				CashManagementDataSet.Tables["NextMarketFloat"].Merge(nextMarketFloatDataTable);
			}

			DataTable cashOnHandDataTable = m_databaseAccess.ExecuteSelect(cashOnHandSql);
			if (cashOnHandDataTable != null && cashOnHandDataTable.Rows.Count > 0)
			{
				CashManagementDataSet.Tables["CashOnHand"].Merge(cashOnHandDataTable);
			}

			// Tell the DataSet to accept all changes so that subsequent changes made by the user will show up.
			CashManagementDataSet.AcceptChanges();

			if (nextMarketFloatDataTable == null || nextMarketFloatDataTable.Rows.Count == 0)
			{
				CashManagementDataSet.Tables["NextMarketFloat"].Rows.Add(CashManagementDataSet.Tables["NextMarketFloat"].NewRow());
			}
				
			m_updatingData = false;
		}

		private bool SaveChanges()
		{
			bool successful = true;

			DataSet changes = CashManagementDataSet.GetChanges();

			if (changes != null && m_databaseAccess.BeginTransaction())
			{
				DataTable nextMarketFloatDataTable = changes.Tables["NextMarketFloat"];

				if (nextMarketFloatDataTable.Rows.Count > 0)
				{
					successful = m_databaseAccess.SaveSimpleTableWithID(nextMarketFloatDataTable, "NextMarketFloat");
				}

				if (successful)
				{
					DataTable cashOnHandDataTable = changes.Tables["CashOnHand"];

					if (cashOnHandDataTable.Rows.Count > 0)
					{
						successful = m_databaseAccess.SaveSimpleTableWithID(cashOnHandDataTable, "CashOnHand");
					}
				}

				// If all saves have been successful then commit the transaction.
				if (successful && m_databaseAccess.CommitTransaction())
				{
					((OMG_MainForm)this.MdiParent).RefreshDisplay();
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
