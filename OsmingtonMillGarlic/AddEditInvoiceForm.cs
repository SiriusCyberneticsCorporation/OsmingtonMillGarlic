using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;

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
			m_invoiceItems.Add(InvoiceItem9);

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
			foreach (InvoiceItemUserControl invoiceItem in m_invoiceItems)
			{
				invoiceItem.Clear();
			}

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
			decimal subTotal = 0;
			foreach(DataRow row in InvoicesDataSet.Tables["InvoiceItems"].Rows)
			{
				subTotal += DatabaseAccess.GetDecimal(row["Amount"]);
			}
			InvoicesDataSet.Tables["Invoices"].Rows[0]["SubTotal"] = subTotal;
			
			if(DatabaseAccess.GetDecimal(InvoicesDataSet.Tables["Invoices"].Rows[0]["GST"]) != 0)
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
			DataRow existingRow = InvoicesDataSet.Tables["InvoiceItems"].Rows.Find(DatabaseAccess.GetInt(row["ID"]));

			if(existingRow != null)
			{
				existingRow["InvoiceID"] = m_invoiceID;
				existingRow["ProductID"] = row["ProductID"];
				existingRow["Description"] = row["Description"];
				existingRow["Quantity"] = row["Quantity"];
				existingRow["UnitsText"] = row["UnitsText"];
				existingRow["UnitPrice"] = row["UnitPrice"];
				existingRow["PerUnitText"] = row["PerUnitText"];
				existingRow["Amount"] = row["Amount"];
			}
			else 
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

		private static object MISSING = System.Reflection.Missing.Value;
		private static object ENDOFDOC = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
		private Word.Application m_wordApplication = new Word.Application();
		private Word.Document m_currentDocument = null;
		private Word.Paragraph m_currentParagraph = null;
		private Word.Table m_currentTable = null;

		private void CreateFileButton_Click(object sender, EventArgs e)
		{
			object template = MISSING;

			// Hide Word while creating the document to speed things up.
			m_wordApplication.Visible = false;

			// Create a new Document, by calling the Add function in the Documents collection
			m_currentDocument = m_wordApplication.Documents.Add(ref template, ref MISSING, ref MISSING, ref MISSING);
			m_currentDocument.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
			m_currentDocument.PageSetup.TopMargin = m_wordApplication.CentimetersToPoints(1.5f);
			m_currentDocument.PageSetup.BottomMargin = m_wordApplication.CentimetersToPoints(1.5f);
			m_currentDocument.PageSetup.LeftMargin = m_wordApplication.CentimetersToPoints(2.0f);
			m_currentDocument.PageSetup.RightMargin = m_wordApplication.CentimetersToPoints(2.0f);

			// Setting the focus on the page header
			m_currentDocument.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;

			// Inserting the page numbers centrally aligned in the page header
			m_currentDocument.ActiveWindow.Selection.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

			Word.Range currentRange = m_currentDocument.ActiveWindow.Selection.Range;
			
			// Insert first Header Line.
			//m_currentParagraph = currentRange.Paragraphs.Add(ref MISSING);
			//m_currentParagraph.Range.Font.Size = 38;


			// Insert first Header Line.
			m_currentParagraph = currentRange.Paragraphs.Add(ref MISSING);
			m_currentParagraph.Range.Font.Size = 38;
			m_currentParagraph.Range.InsertParagraphAfter();

			currentRange = currentRange.Sections.Last.Range;

			m_currentTable = m_currentDocument.Tables.Add(currentRange, 1, 4, ref MISSING, ref MISSING);
			//m_currentTable.Range.set_Style(m_currentDocument.Styles[GMSHelper.GetEnumDescription(ReportTextStyle.TableText)]);

			// Set up cell padding for the entire table.
			m_currentTable.LeftPadding = m_wordApplication.CentimetersToPoints(0.1f);
			m_currentTable.RightPadding = m_wordApplication.CentimetersToPoints(0.1f);
			m_currentTable.TopPadding = m_wordApplication.CentimetersToPoints(0.05f);
			m_currentTable.BottomPadding = m_wordApplication.CentimetersToPoints(0.05f);

			m_currentTable.Columns[1].Width = m_wordApplication.CentimetersToPoints(8.0f);
			m_currentTable.Columns[2].Width = m_wordApplication.CentimetersToPoints(9.8f);
			m_currentTable.Columns[3].Width = m_wordApplication.CentimetersToPoints(6.2f);
			m_currentTable.Columns[4].Width = m_wordApplication.CentimetersToPoints(1.7f);

			m_currentTable.Cell(1, 1).Range.Text = "Date";
			m_currentTable.Cell(1, 2).Range.Text = "TAX INVOICE";
			m_currentTable.Cell(1, 3).Range.Text = "INVOICE NUMBER";
			m_currentTable.Cell(1, 4).Range.Text = "nnn";

			m_wordApplication.Selection.HeaderFooter.Shapes.AddTextEffect(MsoPresetTextEffect.msoTextEffect9,
									   "Jeanette & Richard Smith",
									   "Boboni MT Black",
									   36,
									   MsoTriState.msoFalse,
									   MsoTriState.msoFalse,
									   0, 0, MISSING);


			// Make word visible to show the results.
			m_wordApplication.Visible = true;
			m_wordApplication.Activate();

		}

		private Word.Range GetLastRangeInDocument()
		{
			return m_currentDocument.Bookmarks.get_Item(ref ENDOFDOC).Range;
		}

	}
}
