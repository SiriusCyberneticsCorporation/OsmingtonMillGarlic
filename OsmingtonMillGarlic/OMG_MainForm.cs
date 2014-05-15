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
	public partial class OMG_MainForm : Form
	{
		/*
		private ProductsForm m_productsForm = new ProductsForm();
		private MarketsForm m_marketsForm = new MarketsForm();
		private MarketAttendedForm m_newMarketForm = new MarketAttendedForm(-1);
		private InvoicesForm m_invoicesForm = new InvoicesForm();
		*/

		public OMG_MainForm()
		{
			InitializeComponent();
		}

		public void RefreshDisplay()
		{
			foreach(Form childForm in this.MdiChildren)
			{
				((IChildForm)childForm).RefreshDisplay();
			}
			/*
			m_productsForm.RefreshDisplay();
			m_marketsForm.RefreshDisplay();
			m_newMarketForm.RefreshDisplay();
			m_invoicesForm.RefreshDisplay();
			*/
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ShowChildForm(Form childForm)
		{
			childForm.MdiParent = this;
			childForm.Show();
			childForm.BringToFront();
		}

		private Form GetExistingInstance(Type formType)
		{
			Form foundChild = null;

			foreach (Form childForm in this.MdiChildren)
			{
				if (childForm.GetType() == formType)
				{
					foundChild = childForm;
					break;
				}
			}

			return foundChild;
		}

		private void ListAllProductsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form existingInstance = GetExistingInstance(typeof(ProductsForm));

			if(existingInstance != null)
			{
				ShowChildForm(existingInstance);
			}
			else
			{
				ShowChildForm(new ProductsForm());
			}
			//ShowChildForm(m_productsForm);
		}

		private void ListAllMarketsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowChildForm(m_marketsForm);
		}
		
		private void newMarketToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewMarket();
		}

		private void ListAllInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowChildForm(m_invoicesForm);
		}

		private void OMG_MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool okToClose = true;

			if (okToClose && m_productsForm != null)
			{
				okToClose = ((IChildForm)m_productsForm).CanClose();
			}
			if (okToClose && m_marketsForm != null)
			{
				okToClose = ((IChildForm)m_marketsForm).CanClose();
			}
			if (okToClose && m_invoicesForm != null)
			{
				okToClose = ((IChildForm)m_invoicesForm).CanClose();
			}
		}

		private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
		}

		private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
		}

		private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
		}

		private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_productsForm != null && ((IChildForm)m_productsForm).CanClose())
			{
				m_productsForm.Close();
			}
			if (m_marketsForm != null && ((IChildForm)m_marketsForm).CanClose())
			{
				m_marketsForm.Close();
			}
			if (m_invoicesForm != null && ((IChildForm)m_invoicesForm).CanClose())
			{
				m_invoicesForm.Close();
			}
		}

		private void ProductsToolStripButton_Click(object sender, EventArgs e)
		{
			ShowChildForm(m_productsForm);
		}

		private void MarketsToolStripButton_Click(object sender, EventArgs e)
		{
			ShowChildForm(m_marketsForm);
		}

		private void NewMarketToolStripButton_Click(object sender, EventArgs e)
		{
			NewMarket();
		}

		private void InvoicesToolStripButton_Click(object sender, EventArgs e)
		{
			ShowChildForm(m_invoicesForm);
		}

		private void ShowProductsForm()
		{
			Form existingInstance = GetExistingInstance(typeof(ProductsForm));

			if (existingInstance != null)
			{
				ShowChildForm(existingInstance);
			}
			else
			{
				ShowChildForm(new ProductsForm());
			}
			//ShowChildForm(m_productsForm);
		}

		private void ShowProductsForm()
		{
			Form existingInstance = GetExistingInstance(typeof(ProductsForm));

			if (existingInstance != null)
			{
				ShowChildForm(existingInstance);
			}
			else
			{
				ShowChildForm(new ProductsForm());
			}
		}

		private void ShowMarketsForm()
		{
			Form existingInstance = GetExistingInstance(typeof(MarketsForm));

			if (existingInstance != null)
			{
				ShowChildForm(existingInstance);
			}
			else
			{
				ShowChildForm(new MarketsForm());
			}
		}

		private void ShowProductsForm()
		{
			Form existingInstance = GetExistingInstance(typeof(ProductsForm));

			if (existingInstance != null)
			{
				ShowChildForm(existingInstance);
			}
			else
			{
				ShowChildForm(new ProductsForm());
			}
			//ShowChildForm(m_productsForm);
		}

		private void NewMarket()
		{
			ShowChildForm(m_newMarketForm);
		}
	}
}
