﻿using System;
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
		public OMG_MainForm()
		{
			InitializeComponent();
		}

		private void OMG_MainForm_Load(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.WindowMaximized)
			{
				WindowState = FormWindowState.Maximized;
				Location = Properties.Settings.Default.WindowLocation;
				Size = Properties.Settings.Default.WindowSize;
			}
			else if (Properties.Settings.Default.WindowMinimized)
			{
				WindowState = FormWindowState.Minimized;
				Location = Properties.Settings.Default.WindowLocation;
				Size = Properties.Settings.Default.WindowSize;
			}
			else
			{
				Location = Properties.Settings.Default.WindowLocation;
				Size = Properties.Settings.Default.WindowSize;
			}
		}

		private void OMG_MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool okToClose = true;

			foreach (Form childForm in this.MdiChildren)
			{
				if (!((IChildForm)childForm).CanClose())
				{
					okToClose = false;
					break;
				}
			}

			if (!okToClose)
			{
				e.Cancel = true;
			}

			if (WindowState == FormWindowState.Maximized)
			{
				Properties.Settings.Default.WindowLocation = RestoreBounds.Location;
				Properties.Settings.Default.WindowSize = RestoreBounds.Size;
				Properties.Settings.Default.WindowMaximized = true;
				Properties.Settings.Default.WindowMinimized = false;
			}
			else if (WindowState == FormWindowState.Normal)
			{
				Properties.Settings.Default.WindowLocation = Location;
				Properties.Settings.Default.WindowSize = Size;
				Properties.Settings.Default.WindowMaximized = false;
				Properties.Settings.Default.WindowMinimized = false;
			}
			else
			{
				Properties.Settings.Default.WindowLocation = RestoreBounds.Location;
				Properties.Settings.Default.WindowSize = RestoreBounds.Size;
				Properties.Settings.Default.WindowMaximized = false;
				Properties.Settings.Default.WindowMinimized = true;
			}
			Properties.Settings.Default.Save();
		}

		public void RefreshDisplay()
		{
			foreach(Form childForm in this.MdiChildren)
			{
				if (childForm != ActiveMdiChild)
				{
					((IChildForm)childForm).RefreshDisplay();
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ShowChildForm(Form childForm)
		{
			childForm.WindowState = FormWindowState.Maximized;
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
			ShowProductsForm();
		}

		private void ListAllMarketsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowMarketsForm();
		}
		
		private void newMarketToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewMarket();
		}

		private void ListAllInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowInvoicesForm();
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
			foreach (Form childForm in this.MdiChildren)
			{
				if (((IChildForm)childForm).CanClose())
				{
					childForm.Close();
				}
			}
		}

		private void ProductsToolStripButton_Click(object sender, EventArgs e)
		{
			ShowProductsForm();
		}

		private void MarketsToolStripButton_Click(object sender, EventArgs e)
		{
			ShowMarketsForm();
		}

		private void NewMarketToolStripButton_Click(object sender, EventArgs e)
		{
			NewMarket();
		}

		private void InvoicesToolStripButton_Click(object sender, EventArgs e)
		{
			ShowInvoicesForm();
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

		private void CashManagementToolStripButton_Click(object sender, EventArgs e)
		{
			Form existingInstance = GetExistingInstance(typeof(CashManagementForm));

			if (existingInstance != null)
			{
				ShowChildForm(existingInstance);
			}
			else
			{
				ShowChildForm(new CashManagementForm());
			}
		}

		private void ShowInvoicesForm()
		{
			Form existingInstance = GetExistingInstance(typeof(InvoicesForm));

			if (existingInstance != null)
			{
				ShowChildForm(existingInstance);
			}
			else
			{
				ShowChildForm(new InvoicesForm());
			}
		}

		private void NewMarket()
		{
			Form existingInstance = GetExistingInstance(typeof(MarketAttendedForm));

			if (existingInstance != null && ((MarketAttendedForm)existingInstance).IsNewMarket)
			{				
				ShowChildForm(existingInstance);
			}
			else
			{
				ShowChildForm(new MarketAttendedForm(-1));
			}
		}

		private void NewInvoiceToolStripButton_Click(object sender, EventArgs e)
		{
			Form existingInstance = GetExistingInstance(typeof(AddEditInvoiceForm));

			if (existingInstance != null && ((AddEditInvoiceForm)existingInstance).IsNewInvoice)
			{
				ShowChildForm(existingInstance);
			}
			else
			{
				ShowChildForm(new AddEditInvoiceForm(-1));
			}
		}

		private void marketSummaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MarketSummaryReportForm iMarketSummaryReportForm = new MarketSummaryReportForm();
			iMarketSummaryReportForm.ShowDialog(this);
		}
	}
}
