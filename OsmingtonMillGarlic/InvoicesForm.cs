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
	public partial class InvoicesForm : Form, IChildForm
	{
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public InvoicesForm()
		{
			InitializeComponent();
		}

		private void InvoicesForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!CanClose())
			{
				e.Cancel = true;
			}
		}

		private void InvoicesForm_Load(object sender, EventArgs e)
		{
			RefreshDisplay();
		}

		public void RefreshDisplay()
		{
			string invoiceTypesSql = "SELECT * FROM InvoiceTypes";
			string invoicesSql = "SELECT ID, InvoiceType, InvoiceNumber, InvoiceDate, InvoiceTo, Reference, Total FROM Invoices";

			InvoicesDataSet.Tables["Invoices"].Clear();
			InvoicesDataSet.Tables["InvoiceTypes"].Clear();

			DataTable invoiceTypesDataTable = m_databaseAccess.ExecuteSelect(invoiceTypesSql);
			if (invoiceTypesDataTable != null && invoiceTypesDataTable.Rows.Count > 0)
			{
				InvoicesDataSet.Tables["InvoiceTypes"].Merge(invoiceTypesDataTable);
			}

			DataTable invoicesDataTable = m_databaseAccess.ExecuteSelect(invoicesSql);
			if (invoicesDataTable != null && invoicesDataTable.Rows.Count > 0)
			{
				InvoicesDataSet.Tables["Invoices"].Merge(invoicesDataTable);
			}
		}

		public bool CanClose()
		{
			return true;
		}

		private void InvoicesDataGridViewWithPaste_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			int invoiceID = DatabaseAccess.GetInt(InvoicesDataGridViewWithPaste.CurrentRow.Cells["IDColumn"].Value);

			AddEditInvoiceForm invoiceForm = new AddEditInvoiceForm(invoiceID);
			invoiceForm.MdiParent = this.MdiParent;
			invoiceForm.Show();
		}

	}
}
