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
	public partial class AddEditProductForm : Form
	{
		private int m_productID = -1;
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public int SelectedID
		{
			get
			{
				if (ProductsComboBox.SelectedIndex >= 0)
				{
					return DatabaseAccess.GetInt(ProductsComboBox.SelectedValue);
				}
				else
				{
					return -1;
				}
			}
		}

		public AddEditProductForm(int productID = -1)
		{
			InitializeComponent();

			m_productID = productID;
		}

		private void AddEditProductForm_Load(object sender, EventArgs e)
		{
			string productsSql = "SELECT ID, Description FROM Products ORDER BY DisplayOrder";

			DataTable productsDataTable = m_databaseAccess.ExecuteSelect(productsSql);
			if (productsDataTable != null && productsDataTable.Rows.Count > 0)
			{
				SelectProductDataSet.Tables["Products"].Merge(productsDataTable);
			}

			if(m_productID > 0)
			{
				ProductsComboBox.SelectedValue = m_productID;
			}
		}
	}
}
