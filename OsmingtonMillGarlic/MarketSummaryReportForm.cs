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
	public partial class MarketSummaryReportForm : Form
	{
		private DatabaseAccess m_databaseAccess = new DatabaseAccess();

		public MarketSummaryReportForm()
		{
			InitializeComponent();

			StartDateNullableDatePicker.Value = null;
			EndDateNullableDatePicker.Value = null;
		}

		private void DatePicker_ValueChanged(object sender, EventArgs e)
		{
			string querySQL = "SELECT GarlicVariety.Name AS GarlicVariety, Products.Description, " +
							  "SUM(MarketProducts.SoldAtMarket) AS NumberSold, " +
							  "SUM(Products.UnitWeight * MarketProducts.SoldAtMarket) AS TotalWeight, " +
							  "(SUM(MarketProducts.SoldAtMarket)*Products.MarketPrice) AS TotalValue " +
							  "FROM Markets " +
							  "INNER JOIN MarketProducts ON MarketProducts.MarketID = Markets.ID " +
							  "INNER JOIN Products ON Products.ID = MarketProducts.ProductID " +
							  "INNER JOIN GarlicVariety ON GarlicVariety.ID = Products.VarietyID ";

			if (StartDateNullableDatePicker.Value != DBNull.Value && StartDateNullableDatePicker.Value != null)
			{
				querySQL += "WHERE Markets.MarketDate >= " + DatabaseAccess.FormatDate(StartDateNullableDatePicker.DateTimeValue) + " ";

				if (EndDateNullableDatePicker.Value != DBNull.Value && EndDateNullableDatePicker.Value != null)
				{
					querySQL += "AND Markets.MarketDate <= " + DatabaseAccess.FormatDate(EndDateNullableDatePicker.DateTimeValue) + " ";
				}
			}
			else if (EndDateNullableDatePicker.Value != DBNull.Value && EndDateNullableDatePicker.Value != null)
			{
				querySQL += "WHERE Markets.MarketDate <= " + DatabaseAccess.FormatDate(EndDateNullableDatePicker.DateTimeValue) + " ";
			}
			querySQL += "GROUP BY Products.ID ORDER BY GarlicVariety.ID, Products.DisplayOrder";

			MarketSummaryDataSet.Tables["MarketSummary"].Clear();

			DataTable reportDataTable = m_databaseAccess.ExecuteSelect(querySQL);
			
			if (reportDataTable != null && reportDataTable.Rows.Count > 0)
			{
				MarketSummaryDataSet.Tables["MarketSummary"].Merge(reportDataTable);
			}

		}
	}
}
