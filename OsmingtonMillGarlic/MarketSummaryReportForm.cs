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

			StartDateNullableDatePicker.Value = DateTime.Now.AddDays(0- (((int)(DateTime.Now.DayOfWeek) + 1) % 7));
			EndDateNullableDatePicker.Value = DateTime.Now;
		}

        private void StartDateNullableDatePicker_ValueChanged(object sender, EventArgs e)
        {
            EndDateNullableDatePicker.MinDate = StartDateNullableDatePicker.DateTimeValue;
            ShowResults();
        }

        private void EndDateNullableDatePicker_ValueChanged(object sender, EventArgs e)
        {
            StartDateNullableDatePicker.MaxDate = EndDateNullableDatePicker.DateTimeValue;
            ShowResults();
        }

        private void ShowResults()
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

                decimal totalNumberSold = 0;
                decimal totalTotalWeight = 0;
                decimal totalTotalValue = 0;
                foreach (DataRow row in MarketSummaryDataSet.Tables["MarketSummary"].Rows)
                {
                    totalNumberSold += DatabaseAccess.GetDecimal(row["NumberSold"]);
                    totalTotalWeight += DatabaseAccess.GetDecimal(row["TotalWeight"]);
                    totalTotalValue += DatabaseAccess.GetDecimal(row["TotalValue"]);
                }

                TotalNumberSoldTextBox.Text = totalNumberSold.ToString();
                TotalTotalWeightTextBox.Text = totalTotalWeight.ToString();
                TotalTotalValueTextBox.Text = totalTotalValue.ToString();
            }
        }

        private void MarketSummaryDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int left = MarketSummaryDataGridView.Left + 2;
            int GarlicVarietyColumnWidth = MarketSummaryDataGridView.Columns["GarlicVarietyColumn"].Width;
            int DescriptionColumnWidth = MarketSummaryDataGridView.Columns["DescriptionColumn"].Width;
            int NumberSoldColumnWidth = MarketSummaryDataGridView.Columns["NumberSoldColumn"].Width;
            int TotalWeightColumnWidth = MarketSummaryDataGridView.Columns["TotalWeightColumn"].Width;
            int TotalValueColumnWidth = MarketSummaryDataGridView.Columns["TotalValueColumn"].Width;

            TotalsLabel.Top = MarketSummaryDataGridView.Bottom + 1;
            TotalsLabel.Width = GarlicVarietyColumnWidth + DescriptionColumnWidth;
            TotalNumberSoldTextBox.Top = MarketSummaryDataGridView.Bottom + 1;
            TotalNumberSoldTextBox.Left = left + GarlicVarietyColumnWidth + DescriptionColumnWidth;
            TotalNumberSoldTextBox.Width = NumberSoldColumnWidth;
            TotalTotalWeightTextBox.Top = MarketSummaryDataGridView.Bottom + 1;
            TotalTotalWeightTextBox.Left = left + GarlicVarietyColumnWidth + DescriptionColumnWidth + NumberSoldColumnWidth;
            TotalTotalWeightTextBox.Width = TotalWeightColumnWidth;
            TotalTotalValueTextBox.Top = MarketSummaryDataGridView.Bottom + 1;
            TotalTotalValueTextBox.Left = left + GarlicVarietyColumnWidth + DescriptionColumnWidth + NumberSoldColumnWidth + TotalWeightColumnWidth;
            TotalTotalValueTextBox.Width = TotalValueColumnWidth;
        }
    }
}
