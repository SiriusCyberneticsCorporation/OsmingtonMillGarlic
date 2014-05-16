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
	public partial class ProductsForm : Form, IChildForm
	{
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public ProductsForm()
		{
			InitializeComponent();
		}

		private void ProductsForm_FormClosing(object sender, FormClosingEventArgs e)
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

		private void ProductsForm_Load(object sender, EventArgs e)
		{
			FetchData();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			SaveChanges();
		}

		public void RefreshDisplay()
		{
		}

		public bool CanClose()
		{
			bool result = true;

			if(ProductsDataSet.HasChanges())
			{
				DialogResult answer =
						MessageBox.Show("The Products list has changed.\r\nDo you wish to save changes before continuing?",
										"Save Product Changes",
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
					ProductsDataSet.RejectChanges();
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
			string productsSql = "SELECT * FROM Products ORDER BY DisplayOrder";

			ProductsDataSet.Tables["Products"].Clear();

			DataTable productsDataTable = m_databaseAccess.ExecuteSelect(productsSql);
			if (productsDataTable != null && productsDataTable.Rows.Count > 0)
			{
				ProductsDataSet.Tables["Products"].Merge(productsDataTable);
			}
		}

		private bool SaveChanges()
		{
			bool successful = true;

			DataSet changes = ProductsDataSet.GetChanges();

			if (changes != null && m_databaseAccess.BeginTransaction())
			{
				DataTable productsDataTable = changes.Tables["Products"];

				if (productsDataTable.Rows.Count > 0)
				{
					successful = m_databaseAccess.SaveSimpleTableWithID(productsDataTable, "Products");
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
