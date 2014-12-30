using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Word = Microsoft.Office.Interop.Word;
//using Microsoft.Office.Core;

namespace OsmingtonMillGarlic
{
	public partial class AddEditInvoiceForm : Form, IChildForm
	{
		public bool IsNewInvoice { get { return m_invoiceID == -1; } }

		private int m_invoiceID = -1;
		private bool m_updatingData = false;
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();
		private List<InvoiceItemUserControl> m_invoiceItems = new List<InvoiceItemUserControl>();

		public AddEditInvoiceForm(int invoiceID)
		{
			InitializeComponent();

			m_invoiceItems.Add(InvoiceItem1);
			m_invoiceItems.Add(InvoiceItem2);
			m_invoiceItems.Add(InvoiceItem3);
			m_invoiceItems.Add(InvoiceItem4);
			m_invoiceItems.Add(InvoiceItem5);
			m_invoiceItems.Add(InvoiceItem6);
			m_invoiceItems.Add(InvoiceItem7);
			m_invoiceItems.Add(InvoiceItem8);

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

			InvoicesDataSet.Tables["Invoices"].Clear();
			InvoicesDataSet.Tables["InvoiceItems"].Clear();

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

					int rowNumber = 0;
					foreach(DataRow row in invoiceItemsDataTable.Rows)
					{
						if (rowNumber < m_invoiceItems.Count)
						{
							m_invoiceItems[rowNumber].Row = row;
						}
						rowNumber++;
					}
				}

				// Tell the DataSet to accept all changes so that subsequent changes made by the user will show up.
				InvoicesDataSet.AcceptChanges();
			}
			else
			{
				foreach (InvoiceItemUserControl invoiceItem in m_invoiceItems)
				{
					invoiceItem.Clear();
				}

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

		private void CalculateInvoiceTotal()
		{
			if (InvoicesDataSet.Tables["Invoices"].Rows.Count > 0)
			{
				decimal subTotal = 0;
				foreach (DataRow row in InvoicesDataSet.Tables["InvoiceItems"].Rows)
				{
					if (row.RowState != DataRowState.Deleted)
					{
						subTotal += DatabaseAccess.GetDecimal(row["Amount"]);
					}
				}
				InvoicesDataSet.Tables["Invoices"].Rows[0]["SubTotal"] = subTotal;

				if (DatabaseAccess.GetDecimal(InvoicesDataSet.Tables["Invoices"].Rows[0]["GST"]) != 0)
				{
					InvoicesDataSet.Tables["Invoices"].Rows[0]["GST"] = subTotal * 0.1M;
					InvoicesDataSet.Tables["Invoices"].Rows[0]["InvoiceTotal"] = subTotal + subTotal * 0.1M;
				}
				else
				{
					InvoicesDataSet.Tables["Invoices"].Rows[0]["InvoiceTotal"] = subTotal;
				}

				SubTotalNumericTextBox.Update();
				GstNumericTextBox.Update();
				InvoiceTotalNumericTextBox.Update();
			}
		}

		private void InvoiceItem_ItemAdded(InvoiceItemUserControl sender, DataRow row)
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
			
			sender.Row = newRow;

			CalculateInvoiceTotal();
		}

		private void InvoiceItem_ItemAltered(InvoiceItemUserControl sender, DataRow row)
		{
			bool rowUpdated = false;

			foreach (DataRow existingRow in InvoicesDataSet.Tables["InvoiceItems"].Rows)
			{
				if (DatabaseAccess.GetInt(existingRow["ID"]) == DatabaseAccess.GetInt(row["ID"]))
				{
					existingRow["InvoiceID"] = m_invoiceID;
					existingRow["ProductID"] = row["ProductID"];
					existingRow["Description"] = row["Description"];
					existingRow["Quantity"] = row["Quantity"];
					existingRow["UnitsText"] = row["UnitsText"];
					existingRow["UnitPrice"] = row["UnitPrice"];
					existingRow["PerUnitText"] = row["PerUnitText"];
					existingRow["Amount"] = row["Amount"];
					rowUpdated = true;
					break;
				}
			}
			
			if(!rowUpdated)
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

				sender.Row = newRow;
			}
			
			CalculateInvoiceTotal();
		}

		private void InvoiceItem_ItemDeleted(InvoiceItemUserControl sender, DataRow row)
		{
			DataRow existingRow = InvoicesDataSet.Tables["InvoiceItems"].Rows.Find(DatabaseAccess.GetInt(row["ID"]));

			if (existingRow != null)
			{
				// Get the index of the selected row in the source DataSet.
				int index = InvoicesDataSet.Tables["InvoiceItems"].Rows.IndexOf(existingRow);
				// Mark the row as deleted.
				InvoicesDataSet.Tables["InvoiceItems"].Rows[index].Delete();

				sender.Clear();
			}

			CalculateInvoiceTotal();
		}

		private void CalculateGstButton_Click(object sender, EventArgs e)
		{
			if(InvoicesDataSet.Tables["Invoices"].Rows.Count > 0)
			{
				decimal subTotal = DatabaseAccess.GetDecimal(InvoicesDataSet.Tables["Invoices"].Rows[0]["SubTotal"]);

				InvoicesDataSet.Tables["Invoices"].Rows[0]["GST"] = subTotal * 0.1M;
				InvoicesDataSet.Tables["Invoices"].Rows[0]["InvoiceTotal"] = subTotal + subTotal * 0.1M;
			}
		}

		private void LockInvoiceButton_Click(object sender, EventArgs e)
		{
			if (InvoicesDataSet.Tables["Invoices"].Rows.Count > 0)
			{
				if (MessageBox.Show("Locking the Invoice will make further changes impossible.\r\n" +
								   "This operation cannot be undone.\r\n" +
								   "Are you sure you want to lock the Invoice?",
								   "Confirm Lock",
								   MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					InvoicesDataSet.Tables["Invoices"].Rows[0]["Locked"] = true;
				}
			}
		}

		private void CreateFileButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			int invoiceNumber = DatabaseAccess.GetInt(InvoicesDataSet.Tables["Invoices"].Rows[0]["InvoiceNumber"]);
			DateTime invoiceDate = DatabaseAccess.GetDateTime(InvoicesDataSet.Tables["Invoices"].Rows[0]["InvoiceDate"]);
			eInvoiceType invoiceType;
			WordInvoiceCreator iWordInvoiceCreator = new WordInvoiceCreator();

			if ((int)InvoiceTypeComboBox.SelectedValue == (int)eInvoiceType.JeanetteAndRichard)
			{
				invoiceType = eInvoiceType.JeanetteAndRichard;
			}
			else
			{
				invoiceType = eInvoiceType.OsmingtonMillGarlic;
			}

			iWordInvoiceCreator.CreateInvoice();
			iWordInvoiceCreator.FillInHeader(invoiceType, invoiceDate, invoiceNumber);
			iWordInvoiceCreator.FillInFooter(invoiceType);
			iWordInvoiceCreator.AddRecipientInformation(invoiceType,
														DatabaseAccess.GetString(InvoicesDataSet.Tables["Invoices"].Rows[0]["InvoiceTo"]),
														DatabaseAccess.GetString(InvoicesDataSet.Tables["Invoices"].Rows[0]["Reference"]));

			iWordInvoiceCreator.AddInvoiceBody();

			int rowNumber = 2;
			decimal subTotal = 0;

			foreach (DataRow row in InvoicesDataSet.Tables["InvoiceItems"].Rows)
			{
				decimal quantity = DatabaseAccess.GetDecimal(row["Quantity"]);
				decimal unitPrice = DatabaseAccess.GetDecimal(row["UnitPrice"]);
				decimal amount = quantity * unitPrice;

				subTotal += amount;

				iWordInvoiceCreator.SetCellText(rowNumber, 1, DatabaseAccess.GetString(row["Description"]));
				rowNumber++;
				iWordInvoiceCreator.SetCellText(rowNumber, 1, quantity.ToString());
				iWordInvoiceCreator.SetCellText(rowNumber, 2, DatabaseAccess.GetString(row["UnitsText"]));
				iWordInvoiceCreator.SetCellText(rowNumber, 3, unitPrice.ToString("C2"));
				iWordInvoiceCreator.SetCellText(rowNumber, 4, DatabaseAccess.GetString(row["PerUnitText"]));
				iWordInvoiceCreator.SetCellText(rowNumber, 5, amount.ToString("C2"));
				rowNumber++;
			}
			iWordInvoiceCreator.SetCellText(18, 3, subTotal.ToString("C2"));
			iWordInvoiceCreator.SetCellText(20, 3, subTotal.ToString("C2"));

			iWordInvoiceCreator.AddBankDetails();

			iWordInvoiceCreator.ShowWord();

			Cursor = Cursors.Default;
		}

		private void RetailCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			foreach (InvoiceItemUserControl invoiceItem in m_invoiceItems)
			{
				invoiceItem.Retail = RetailCheckBox.Checked;
			}
		}

	}
}
