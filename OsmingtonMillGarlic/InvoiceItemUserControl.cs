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

		public bool Retail
        {
            get { return m_retail; }
            set
            {
                m_retail = value;

                if (m_productID > 0)
                {
                    string productsSql = "SELECT Description, MarketPrice, WholesalePrice, Unit, Units, PerUnit FROM Products " +
                                         "WHERE ID = " + DatabaseAccess.FormatNumber(m_productID);

                    DataTable productsDataTable = m_databaseAccess.ExecuteSelect(productsSql);
                    if (productsDataTable != null && productsDataTable.Rows.Count > 0)
                    {
                        m_updatingData = true;

                        decimal unitPrice;

                        if (m_retail)
                        {
                            unitPrice = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["MarketPrice"]);
                        }
                        else
                        {
                            unitPrice = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["WholesalePrice"]);
                        }

                        InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitPrice"] = unitPrice;
                        InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Amount"] = QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue;

                        m_updatingData = false;

                        if (ItemAltered != null)
                        {
                            ItemAltered(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
                        }
                    }
                }
            }
        }

		public void Clear() 
		{ 
			InvoiceItemsDataSet.Tables["InvoiceItems"].Clear();
			InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Add(InvoiceItemsDataSet.Tables["InvoiceItems"].NewRow());
		}

		public DataRow Row 
		{
			get { return InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]; }
			set 
			{
				m_updatingData = true;

				InvoiceItemsDataSet.Tables["InvoiceItems"].Clear();
				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Add(value.ItemArray);

                m_productID = DatabaseAccess.GetInt(InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["ProductID"]);

                AddProductButton.Visible = false;
				DeleteButton.Visible = true;
				AlterButton.Visible = false;

				m_updatingData = false;
			}
		}

//		private int m_ID = -1;
		private int m_productID = -1;
        private bool m_retail = false;
        private bool m_updatingData = false;
		private string m_unitText = string.Empty;
		private string m_unitsText = string.Empty;
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public InvoiceItemUserControl()
		{
			InitializeComponent();

			InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Add(InvoiceItemsDataSet.Tables["InvoiceItems"].NewRow());
		}
		
		private void AddProductButton_Click(object sender, EventArgs e)
		{
			AddEditProductForm iAddEditProductForm = new AddEditProductForm();

			if (iAddEditProductForm.ShowDialog(this) == DialogResult.OK)
			{
				if (iAddEditProductForm.SelectedID > 0)
				{
					m_productID = iAddEditProductForm.SelectedID;
					string productsSql = "SELECT Description, MarketPrice, WholesalePrice, Unit, Units, PerUnit FROM Products " +
										 "WHERE ID = " + DatabaseAccess.FormatNumber(m_productID);

					DataTable productsDataTable = m_databaseAccess.ExecuteSelect(productsSql);
					if (productsDataTable != null && productsDataTable.Rows.Count > 0)
					{
						m_updatingData = true;

						decimal unitPrice;

						if (m_retail)
						{
							unitPrice = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["MarketPrice"]);
						}
						else
						{
							unitPrice = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["WholesalePrice"]);
						}						

						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["ProductID"] = m_productID;
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Description"] = DatabaseAccess.GetString(productsDataTable.Rows[0]["Description"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Quantity"] = 1;
						m_unitText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Unit"]);
						m_unitsText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Units"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitsText"] = m_unitText + " @ ";
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitPrice"] = unitPrice;
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["PerUnitText"] = DatabaseAccess.GetString(productsDataTable.Rows[0]["PerUnit"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Amount"] = QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue;

						m_updatingData = false;
					}

					AddProductButton.Visible = false;
					DeleteButton.Visible = true;
					AlterButton.Visible = true;
					UnitPriceNumericTextBox.ReadOnly = true;

					if (ItemAdded != null)
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
                AddProductButton.Visible = true;
                DeleteButton.Visible = false;
                AlterButton.Visible = false;
                AddProductButton.Focus();

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
					string productsSql = "SELECT Description, MarketPrice, WholesalePrice, Unit, Units, PerUnit FROM Products " +
										 "WHERE ID = " + DatabaseAccess.FormatNumber(m_productID);

					DataTable productsDataTable = m_databaseAccess.ExecuteSelect(productsSql);
					if (productsDataTable != null && productsDataTable.Rows.Count > 0)
					{
						m_updatingData = true;

						decimal unitPrice;

						if (m_retail)
						{
							unitPrice = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["MarketPrice"]);
						}
						else
						{
							unitPrice = DatabaseAccess.GetDecimal(productsDataTable.Rows[0]["WholesalePrice"]);
						}						

						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["ProductID"] = m_productID;
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Description"] = DatabaseAccess.GetString(productsDataTable.Rows[0]["Description"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Quantity"] = 1;
						m_unitText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Unit"]);
						m_unitsText = DatabaseAccess.GetString(productsDataTable.Rows[0]["Units"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitsText"] = m_unitText + " @ ";
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitPrice"] = unitPrice;
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["PerUnitText"] = DatabaseAccess.GetString(productsDataTable.Rows[0]["PerUnit"]);
						InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Amount"] = QuantityNumericTextBox.DecimalValue * UnitPriceNumericTextBox.DecimalValue;

						m_updatingData = false;
					}

					AddProductButton.Visible = false;
					DeleteButton.Visible = true;
					AlterButton.Visible = true;
					UnitPriceNumericTextBox.ReadOnly = true;

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
				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Quantity"] = QuantityNumericTextBox.DecimalValue;
				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Amount"] = QuantityNumericTextBox.DecimalValue *
																				UnitPriceNumericTextBox.DecimalValue;

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
				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitPrice"] = UnitPriceNumericTextBox.DecimalValue;
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

				if (ItemAltered != null)
				{
					ItemAltered(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
				}
			}
		}

		private void DescriptionTextBox_Leave(object sender, EventArgs e)
		{
			if (!m_updatingData && InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Count > 0)
			{
				if (DescriptionTextBox.Text.Length > 0)
				{
					AddProductButton.Visible = false;
					DeleteButton.Visible = true;
					AlterButton.Visible = false;
				}

				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["Description"] = DescriptionTextBox.Text;

				if (ItemAltered != null)
				{
					ItemAltered(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
				}
			}
		}

		private void UnitsTextBox_Leave(object sender, EventArgs e)
		{
			if (!m_updatingData && InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Count > 0)
			{
				if (DescriptionTextBox.Text.Length > 0)
				{
					AddProductButton.Visible = false;
					DeleteButton.Visible = true;
					AlterButton.Visible = false;
				}

				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["UnitsText"] = UnitsTextBox.Text;

				if (ItemAltered != null)
				{
					ItemAltered(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
				}
			}
		}

		private void PerUnitTextBox_Leave(object sender, EventArgs e)
		{
			if (!m_updatingData && InvoiceItemsDataSet.Tables["InvoiceItems"].Rows.Count > 0)
			{
				if (DescriptionTextBox.Text.Length > 0)
				{
					AddProductButton.Visible = false;
					DeleteButton.Visible = true;
					AlterButton.Visible = false;
				}

				InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]["PerUnitText"] = PerUnitTextBox.Text;

				if (ItemAltered != null)
				{
					ItemAltered(this, InvoiceItemsDataSet.Tables["InvoiceItems"].Rows[0]);
				}
			}
		}
	}
}
