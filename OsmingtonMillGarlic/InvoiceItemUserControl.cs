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
		public delegate void InvoiceItemHandler(DataRow row);

		public event InvoiceItemHandler ItemAdded;
		public event InvoiceItemHandler ItemAltered;
		public event InvoiceItemHandler ItemDeleted;

		private int m_ID = -1;
		private int m_productID = -1;
		private string m_unitText = string.Empty;
		private string m_unitsText = string.Empty;
		private DataRow m_row = null;
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public InvoiceItemUserControl()
		{
			InitializeComponent();
		}

		public void Set(DataRow row)
		{
			m_row = row;
			m_ID = DatabaseAccess.GetInt(row["ID"]);
			m_productID = DatabaseAccess.GetInt(row["ProductID"]);
			DescriptionTextBox.Text = DatabaseAccess.GetString(row["Description"]);
			QuantityNumericTextBox.Text = DatabaseAccess.GetDecimal(row["Quantity"]).ToString();
			UnitsTextBox.Text = DatabaseAccess.GetString(row["UnitsText"]);
			UnitPriceNumericTextBox.Text = DatabaseAccess.GetString(row["UnitPrice"]).ToString();
			PerUnitTextBox.Text = DatabaseAccess.GetString(row["PerUnitText"]);
			AmountNumericTextBox.Text = DatabaseAccess.GetString(row["Amount"]).ToString();
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
						DescriptionTextBox.Text = DatabaseAccess.GetString(productsDataTable.Rows[0]["Description"]);
						QuantityNumericTextBox.Text = "1";
						m_unitText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Unit"]);
						m_unitsText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Units"]);
						UnitsTextBox.Text = m_unitText + " @ ";
						UnitPriceNumericTextBox.Text = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["WholesalePrice"]).ToString("C2");
						PerUnitTextBox.Text = DatabaseAccess.GetString(productsDataTable.Rows[0]["PerUnit"]);
						AmountNumericTextBox.Text = (QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue).ToString("C2");
					}

					AddProductButton.Visible = false;
					DeleteButton.Visible = true;
					AlterButton.Visible = true;

					RefreshRowData();

					if(ItemAdded != null)
					{
						ItemAdded(m_row);
					}
				}
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (ItemDeleted != null)
				{
					ItemDeleted(m_row);
				}
				m_row = null;
				m_ID = -1;
				m_productID = -1;
				DescriptionTextBox.Text = string.Empty;
				QuantityNumericTextBox.Text = string.Empty;
				UnitsTextBox.Text = string.Empty;
				UnitPriceNumericTextBox.Text = string.Empty;
				PerUnitTextBox.Text = string.Empty;
				AmountNumericTextBox.Text = string.Empty;
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
						DescriptionTextBox.Text = DatabaseAccess.GetString(productsDataTable.Rows[0]["Description"]);
						QuantityNumericTextBox.Text = "1";
						m_unitText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Unit"]);
						m_unitsText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Units"]);
						UnitsTextBox.Text = m_unitText + " @ ";
						UnitPriceNumericTextBox.Text = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["WholesalePrice"]).ToString("C2");
						PerUnitTextBox.Text = DatabaseAccess.GetString(productsDataTable.Rows[0]["PerUnit"]);
						AmountNumericTextBox.Text = (QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue).ToString("C2");
					}

					AddProductButton.Visible = false;
					DeleteButton.Visible = true;
					AlterButton.Visible = true;

					RefreshRowData();

					if (ItemAltered != null)
					{
						ItemAltered(m_row);
					}
				}
			}
		}

		private void QuantityNumericTextBox_NumberEntered(Controls.NumericTextBox source)
		{
			if(QuantityNumericTextBox.DecimalValue > 0)
			{
				if (QuantityNumericTextBox.DecimalValue > 1 && m_unitsText.Length > 0)
				{
					UnitsTextBox.Text = m_unitsText + " @ ";
				}
				else if (m_unitText.Length > 0)
				{
					UnitsTextBox.Text = m_unitText + " @ ";
				}
			}
			AmountNumericTextBox.Text = (QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue).ToString("C2");
		}

		private void UnitPriceNumericTextBox_NumberEntered(Controls.NumericTextBox source)
		{
			AmountNumericTextBox.Text = (QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue).ToString("C2");
		}
	}
}
