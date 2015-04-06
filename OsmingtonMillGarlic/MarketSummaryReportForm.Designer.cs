namespace OsmingtonMillGarlic
{
	partial class MarketSummaryReportForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.FiltersGroupBox = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.MarketSummaryDataGridView = new System.Windows.Forms.DataGridView();
			this.MarketSummaryDataSet = new System.Data.DataSet();
			this.MarketSummaryDataTable = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataColumn5 = new System.Data.DataColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EndDateNullableDatePicker = new OsmingtonMillGarlic.Controls.NullableDatePicker();
			this.StartDateNullableDatePicker = new OsmingtonMillGarlic.Controls.NullableDatePicker();
			this.garlicVarietyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.numberSoldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalWeightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FiltersGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MarketSummaryDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MarketSummaryDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MarketSummaryDataTable)).BeginInit();
			this.SuspendLayout();
			// 
			// FiltersGroupBox
			// 
			this.FiltersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FiltersGroupBox.Controls.Add(this.label2);
			this.FiltersGroupBox.Controls.Add(this.EndDateNullableDatePicker);
			this.FiltersGroupBox.Controls.Add(this.label1);
			this.FiltersGroupBox.Controls.Add(this.StartDateNullableDatePicker);
			this.FiltersGroupBox.Location = new System.Drawing.Point(12, 12);
			this.FiltersGroupBox.Name = "FiltersGroupBox";
			this.FiltersGroupBox.Size = new System.Drawing.Size(730, 51);
			this.FiltersGroupBox.TabIndex = 0;
			this.FiltersGroupBox.TabStop = false;
			this.FiltersGroupBox.Text = "Report Filters";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(180, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "End Date";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Start Date";
			// 
			// MarketSummaryDataGridView
			// 
			this.MarketSummaryDataGridView.AllowUserToAddRows = false;
			this.MarketSummaryDataGridView.AllowUserToDeleteRows = false;
			this.MarketSummaryDataGridView.AllowUserToResizeRows = false;
			this.MarketSummaryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MarketSummaryDataGridView.AutoGenerateColumns = false;
			this.MarketSummaryDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.MarketSummaryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.MarketSummaryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.garlicVarietyDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.numberSoldDataGridViewTextBoxColumn,
            this.totalWeightDataGridViewTextBoxColumn,
            this.totalValueDataGridViewTextBoxColumn});
			this.MarketSummaryDataGridView.DataMember = "MarketSummary";
			this.MarketSummaryDataGridView.DataSource = this.MarketSummaryDataSet;
			this.MarketSummaryDataGridView.Location = new System.Drawing.Point(12, 69);
			this.MarketSummaryDataGridView.Name = "MarketSummaryDataGridView";
			this.MarketSummaryDataGridView.ReadOnly = true;
			this.MarketSummaryDataGridView.RowHeadersVisible = false;
			this.MarketSummaryDataGridView.Size = new System.Drawing.Size(730, 428);
			this.MarketSummaryDataGridView.TabIndex = 1;
			// 
			// MarketSummaryDataSet
			// 
			this.MarketSummaryDataSet.DataSetName = "NewDataSet";
			this.MarketSummaryDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.MarketSummaryDataTable});
			// 
			// MarketSummaryDataTable
			// 
			this.MarketSummaryDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
			this.MarketSummaryDataTable.TableName = "MarketSummary";
			// 
			// dataColumn1
			// 
			this.dataColumn1.ColumnName = "GarlicVariety";
			// 
			// dataColumn2
			// 
			this.dataColumn2.ColumnName = "Description";
			// 
			// dataColumn3
			// 
			this.dataColumn3.ColumnName = "NumberSold";
			this.dataColumn3.DataType = typeof(decimal);
			// 
			// dataColumn4
			// 
			this.dataColumn4.ColumnName = "TotalWeight";
			this.dataColumn4.DataType = typeof(decimal);
			// 
			// dataColumn5
			// 
			this.dataColumn5.ColumnName = "TotalValue";
			this.dataColumn5.DataType = typeof(decimal);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "GarlicVariety";
			this.dataGridViewTextBoxColumn1.HeaderText = "Garlic Variety";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
			this.dataGridViewTextBoxColumn2.HeaderText = "Description";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "NumberSold";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewTextBoxColumn3.HeaderText = "Number Sold";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "TotalWeight";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewTextBoxColumn4.HeaderText = "Total Weight";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.DataPropertyName = "TotalValue";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewTextBoxColumn5.HeaderText = "Total Value";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			// 
			// EndDateNullableDatePicker
			// 
			this.EndDateNullableDatePicker.CustomFormat = "dd-MMM-yyyy";
			this.EndDateNullableDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.EndDateNullableDatePicker.Location = new System.Drawing.Point(238, 19);
			this.EndDateNullableDatePicker.MaxDate = new System.DateTime(2079, 1, 1, 0, 0, 0, 0);
			this.EndDateNullableDatePicker.Name = "EndDateNullableDatePicker";
			this.EndDateNullableDatePicker.Size = new System.Drawing.Size(104, 20);
			this.EndDateNullableDatePicker.TabIndex = 2;
			this.EndDateNullableDatePicker.Value = new System.DateTime(2015, 4, 6, 0, 0, 0, 0);
			this.EndDateNullableDatePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
			// 
			// StartDateNullableDatePicker
			// 
			this.StartDateNullableDatePicker.CustomFormat = "dd-MMM-yyyy";
			this.StartDateNullableDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.StartDateNullableDatePicker.Location = new System.Drawing.Point(67, 19);
			this.StartDateNullableDatePicker.MaxDate = new System.DateTime(2079, 1, 1, 0, 0, 0, 0);
			this.StartDateNullableDatePicker.Name = "StartDateNullableDatePicker";
			this.StartDateNullableDatePicker.Size = new System.Drawing.Size(104, 20);
			this.StartDateNullableDatePicker.TabIndex = 0;
			this.StartDateNullableDatePicker.Value = new System.DateTime(2015, 4, 6, 0, 0, 0, 0);
			this.StartDateNullableDatePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
			// 
			// garlicVarietyDataGridViewTextBoxColumn
			// 
			this.garlicVarietyDataGridViewTextBoxColumn.DataPropertyName = "GarlicVariety";
			this.garlicVarietyDataGridViewTextBoxColumn.HeaderText = "Garlic Variety";
			this.garlicVarietyDataGridViewTextBoxColumn.Name = "garlicVarietyDataGridViewTextBoxColumn";
			this.garlicVarietyDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
			this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
			this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// numberSoldDataGridViewTextBoxColumn
			// 
			this.numberSoldDataGridViewTextBoxColumn.DataPropertyName = "NumberSold";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle1.Format = "N0";
			dataGridViewCellStyle1.NullValue = null;
			this.numberSoldDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.numberSoldDataGridViewTextBoxColumn.HeaderText = "Number Sold";
			this.numberSoldDataGridViewTextBoxColumn.Name = "numberSoldDataGridViewTextBoxColumn";
			this.numberSoldDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// totalWeightDataGridViewTextBoxColumn
			// 
			this.totalWeightDataGridViewTextBoxColumn.DataPropertyName = "TotalWeight";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.totalWeightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.totalWeightDataGridViewTextBoxColumn.HeaderText = "Total Weight";
			this.totalWeightDataGridViewTextBoxColumn.Name = "totalWeightDataGridViewTextBoxColumn";
			this.totalWeightDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// totalValueDataGridViewTextBoxColumn
			// 
			this.totalValueDataGridViewTextBoxColumn.DataPropertyName = "TotalValue";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.totalValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
			this.totalValueDataGridViewTextBoxColumn.HeaderText = "Total Value";
			this.totalValueDataGridViewTextBoxColumn.Name = "totalValueDataGridViewTextBoxColumn";
			this.totalValueDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// MarketSummaryReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(754, 509);
			this.Controls.Add(this.MarketSummaryDataGridView);
			this.Controls.Add(this.FiltersGroupBox);
			this.Name = "MarketSummaryReportForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Market Summary Report";
			this.FiltersGroupBox.ResumeLayout(false);
			this.FiltersGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MarketSummaryDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MarketSummaryDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MarketSummaryDataTable)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox FiltersGroupBox;
		private Controls.NullableDatePicker StartDateNullableDatePicker;
		private System.Windows.Forms.Label label2;
		private Controls.NullableDatePicker EndDateNullableDatePicker;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView MarketSummaryDataGridView;
		private System.Data.DataSet MarketSummaryDataSet;
		private System.Data.DataTable MarketSummaryDataTable;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Data.DataColumn dataColumn4;
		private System.Data.DataColumn dataColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn garlicVarietyDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn numberSoldDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn totalWeightDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn totalValueDataGridViewTextBoxColumn;
	}
}