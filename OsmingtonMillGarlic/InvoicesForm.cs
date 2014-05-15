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
			/*
			if (e.CloseReason == CloseReason.UserClosing)
			{
				this.Hide();
				e.Cancel = true;
			}
			*/
		}

		public void RefreshDisplay()
		{
		}

		public bool CanClose()
		{
			bool result = true;

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

		private bool SaveChanges()
		{
			bool successful = true;

			DataSet changes = InvoicesDataSet.GetChanges();

			if (changes != null && m_databaseAccess.BeginTransaction())
			{
				DataTable invoicesDataTable = changes.Tables["Invoices"];

				if (invoicesDataTable.Rows.Count > 0)
				{
					successful = m_databaseAccess.SaveSimpleTableWithID(invoicesDataTable, "Invoices");
				}

				// If all saves have been successful then commit the transaction.
				if (successful && m_databaseAccess.CommitTransaction())
				{
					// Tell the DataSet to accept all changes so that subsequent changes made by the user will show up.
					InvoicesDataSet.AcceptChanges();
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
