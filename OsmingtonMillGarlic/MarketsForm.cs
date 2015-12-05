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
	public partial class MarketsForm : Form, IChildForm
	{
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public MarketsForm()
		{
			InitializeComponent();
		}

		private void MarketsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!CanClose())
			{
				e.Cancel = true;
			}
		}

		private void MarketsForm_Load(object sender, EventArgs e)
		{
			RefreshDisplay();
		}

		public void RefreshDisplay()
		{
			string marketsSql = "SELECT ID, MarketDate, MarketLocation, ActualCashAfterMarket, Comments FROM Markets ORDER BY MarketDate DESC";

			MarketsDataSet.Tables["Markets"].Clear();

			DataTable marketsDataTable = m_databaseAccess.ExecuteSelect(marketsSql);
			if (marketsDataTable != null && marketsDataTable.Rows.Count > 0)
			{
				MarketsDataSet.Tables["Markets"].Merge(marketsDataTable);
			}
		}

		public bool CanClose()
		{
			return true;
		}

		private void MarketssDataGridViewWithPaste_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{			
			int marketID = DatabaseAccess.GetInt(MarketsDataGridViewWithPaste.Rows[e.RowIndex].Cells["IDColumn"].Value);
			
			MarketAttendedForm marketForm = new MarketAttendedForm(marketID);
			marketForm.MdiParent = this.MdiParent;
			marketForm.Show();
		}
	}
}
