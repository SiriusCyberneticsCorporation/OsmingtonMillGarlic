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
	public partial class AddEditInvoiceForm : Form, IChildForm
	{
		public bool IsNewInvoice { get { return m_invoiceID == -1; } }

		private int m_invoiceID = -1;
		private bool m_updatingData = false;
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public AddEditInvoiceForm(int invoiceID)
		{
			InitializeComponent();

			m_invoiceID = invoiceID;
		}

		private void AddEditInvoiceForm_Load(object sender, EventArgs e)
		{
			FillComboBoxes();

			FetchData();
		}

		private void AddEditInvoiceForm_FormClosing(object sender, FormClosingEventArgs e)
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

		private void FillComboBoxes()
		{
			string invoiceTypesSql = "SELECT ID, Description FROM InvoiceTypes";

			InvoicesDataSet.Tables["InvoiceTypes"].Clear();

			DataTable invoiceTypesDataTable = m_databaseAccess.ExecuteSelect(invoiceTypesSql);
			if (invoiceTypesDataTable != null && invoiceTypesDataTable.Rows.Count > 0)
			{
				InvoicesDataSet.Tables["InvoiceTypes"].Merge(invoiceTypesDataTable);
			}
			// Tell the DataSet to accept all changes so that subsequent changes made by the user will show up.
			InvoicesDataSet.AcceptChanges();
		}

		public void RefreshDisplay()
		{
		}

		private void GatherAllChanges()
		{
			// Move focus to force validation.
			Control currentControl = this.ActiveControl;
			if (currentControl == InvoiceTypeComboBox)
			{
				InvoiceDateNullableDatePicker.Focus();
			}
			else
			{
				InvoiceTypeComboBox.Focus();
			}
			currentControl.Focus();

			// If the row of ORGANISATIONS data wrapped by the OrganisationsBindingSource has been altered
			// by the user then it is necessary to end the edit so that the changes are returned to the DataSet.
			DataRowView iDataRowView = (DataRowView)InvoicesBindingSource.Current;
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

			if (InvoicesDataSet.HasChanges())
			{
				DialogResult answer =
						MessageBox.Show("The Invoices list has changed.\r\nDo you wish to save changes before continuing?",
										"Save Invoice Changes",
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
					InvoicesDataSet.RejectChanges();
				}
				else if (answer == DialogResult.Cancel)
				{
					result = false;
				}
			}

			return result;
		}

		private int NextInvoiceNumber()
		{
			int invoiceNumber = -1;
			string nextInvoiceNumberSql = "SELECT MAX(InvoiceNumber) FROM Invoices";

			invoiceNumber = DatabaseAccess.GetInt(m_databaseAccess.ExecuteScalar(nextInvoiceNumberSql));
			invoiceNumber++;

			return invoiceNumber;
		}

		private void FetchData()
		{
			m_updatingData = true;

			string productsSql = "SELECT ID, Active, Description, WholesalePrice FROM Products ORDER BY DisplayOrder";

			InvoicesDataSet.Tables["Products"].Clear();
			InvoicesDataSet.Tables["Invoices"].Clear();
			InvoicesDataSet.Tables["InvoiceItems"].Clear();

			DataTable productsDataTable = m_databaseAccess.ExecuteSelect(productsSql);
			if (productsDataTable != null && productsDataTable.Rows.Count > 0)
			{
				InvoicesDataSet.Tables["Products"].Merge(productsDataTable);
			}
			// Tell the DataSet to accept all changes so that subsequent changes made by the user will show up.
			InvoicesDataSet.AcceptChanges();

			if (m_invoiceID > 0)
			{
				string invoiceSql = "SELECT * FROM Invoices WHERE ID = " + DatabaseAccess.FormatNumber(m_invoiceID);

				DataTable invoicesDataTable = m_databaseAccess.ExecuteSelect(invoiceSql);
				if (invoicesDataTable != null && invoicesDataTable.Rows.Count > 0)
				{
					InvoicesDataSet.Tables["Invoices"].Merge(invoicesDataTable);
				}

				string invoiceItemsSql = "SELECT * FROM InvoiceItems WHERE InvoiceID = " + DatabaseAccess.FormatNumber(m_invoiceID);

				DataTable invoiceItemsDataTable = m_databaseAccess.ExecuteSelect(invoiceItemsSql);
				if (invoiceItemsDataTable != null && invoiceItemsDataTable.Rows.Count > 0)
				{
					InvoicesDataSet.Tables["InvoiceItems"].Merge(invoiceItemsDataTable);
				}

				// Tell the DataSet to accept all changes so that subsequent changes made by the user will show up.
				InvoicesDataSet.AcceptChanges();
			}
			else
			{
				DataRow newInvoiceRow = InvoicesDataSet.Tables["Invoices"].NewRow();
				newInvoiceRow["InvoiceType"] = 1;
				newInvoiceRow["InvoiceDate"] = DateTime.Today;
				newInvoiceRow["InvoiceNumber"] = NextInvoiceNumber();
				InvoicesDataSet.Tables["Invoices"].Rows.Add(newInvoiceRow);
			}

			// Reset the Binding to synchronise fetch data with displayed and UNEDITED data.
			InvoicesBindingSource.ResetBindings(false);

			m_updatingData = false;
		}

		private bool SaveChanges()
		{
			bool successful = true;
			bool newInvoice = IsNewInvoice;

			DataSet changes = InvoicesDataSet.GetChanges();

			if (changes != null && m_databaseAccess.BeginTransaction())
			{
				DataTable invoicesDataTable = changes.Tables["Invoices"];

				if (invoicesDataTable.Rows.Count > 0)
				{
					successful = m_databaseAccess.SaveSimpleTableWithID(invoicesDataTable, "Invoices");
				}

				if (successful && newInvoice)
				{
					object id = m_databaseAccess.ExecuteScalar("SELECT LAST_INSERT_ID()");
					m_invoiceID = DatabaseAccess.GetInt(id);
				}

				if (successful)
				{
					DataTable invoiceItemsDataTable = changes.Tables["InvoiceItems"];

					if (invoiceItemsDataTable.Rows.Count > 0)
					{
						if (newInvoice)
						{
							foreach (DataRow row in invoiceItemsDataTable.Rows)
							{
								row["InvoiceID"] = m_invoiceID;
							}
						}
						successful = m_databaseAccess.SaveSimpleTableWithID(invoiceItemsDataTable, "InvoiceItems");
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

		private void InvoiceItem_ItemAdded(DataRow row)
		{
			DataRow newRow = InvoicesDataSet.Tables["InvoiceItems"].NewRow();

			newRow["InvoiceID"] = m_invoiceID;
			newRow["ProductID"] = row["ProductID"];
			newRow["Description"] = row["Description"];
			newRow["Quantity"] = row["Quantity"];
			newRow["UnitsText"] = row["UnitsText"];
			newRow["UnitPrice"] = row["UnitPrice"];
			newRow["PerUnitText"] = row["PerUnitText"];
			newRow["Amount"] = row["Amount"];

			InvoicesDataSet.Tables["InvoiceItems"].Rows.Add(newRow);
		}

		private void InvoiceItem_ItemAltered(DataRow row)
		{

		}

		private void InvoiceItem_ItemDeleted(DataRow row)
		{

		}
	}
}
