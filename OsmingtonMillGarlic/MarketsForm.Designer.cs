namespace OsmingtonMillGarlic
{
	partial class MarketsForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.MarketsDataSet = new System.Data.DataSet();
			this.MarketsDataTable = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataColumn5 = new System.Data.DataColumn();
			this.MarketsDataGridViewWithPaste = new OsmingtonMillGarlic.Controls.DataGridViewWithPaste();
			this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.marketDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.marketLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ActualCashAfterMarket = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.MarketsDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MarketsDataTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MarketsDataGridViewWithPaste)).BeginInit();
			this.SuspendLayout();
			// 
			// MarketsDataSet
			// 
			this.MarketsDataSet.DataSetName = "NewDataSet";
			this.MarketsDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.MarketsDataTable});
			// 
			// MarketsDataTable
			// 
			this.MarketsDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
			this.MarketsDataTable.TableName = "Markets";
			// 
			// dataColumn1
			// 
			this.dataColumn1.ColumnName = "ID";
			this.dataColumn1.DataType = typeof(int);
			// 
			// dataColumn2
			// 
			this.dataColumn2.ColumnName = "MarketDate";
			this.dataColumn2.DataType = typeof(System.DateTime);
			// 
			// dataColumn3
			// 
			this.dataColumn3.ColumnName = "MarketLocation";
			// 
			// dataColumn4
			// 
			this.dataColumn4.ColumnName = "ActualCashAfterMarket";
			this.dataColumn4.DataType = typeof(decimal);
			// 
			// dataColumn5
			// 
			this.dataColumn5.ColumnName = "Comments";
			// 
			// MarketsDataGridViewWithPaste
			// 
			this.MarketsDataGridViewWithPaste.AllowUserToAddRows = false;
			this.MarketsDataGridViewWithPaste.AllowUserToDeleteRows = false;
			this.MarketsDataGridViewWithPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MarketsDataGridViewWithPaste.AutoGenerateColumns = false;
			this.MarketsDataGridViewWithPaste.BackgroundColor = System.Drawing.SystemColors.Window;
			this.MarketsDataGridViewWithPaste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.MarketsDataGridViewWithPaste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.marketDateDataGridViewTextBoxColumn,
            this.marketLocationDataGridViewTextBoxColumn,
            this.ActualCashAfterMarket,
            this.Comments});
			this.MarketsDataGridViewWithPaste.DataMember = "Markets";
			this.MarketsDataGridViewWithPaste.DataSource = this.MarketsDataSet;
			this.MarketsDataGridViewWithPaste.Location = new System.Drawing.Point(12, 12);
			this.MarketsDataGridViewWithPaste.Name = "MarketsDataGridViewWithPaste";
			this.MarketsDataGridViewWithPaste.ReadOnly = true;
			this.MarketsDataGridViewWithPaste.RowHeadersVisible = false;
			this.MarketsDataGridViewWithPaste.Size = new System.Drawing.Size(659, 249);
			this.MarketsDataGridViewWithPaste.TabIndex = 2;
			this.MarketsDataGridViewWithPaste.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MarketssDataGridViewWithPaste_CellMouseDoubleClick);
			// 
			// IDColumn
			// 
			this.IDColumn.DataPropertyName = "ID";
			this.IDColumn.HeaderText = "ID";
			this.IDColumn.Name = "IDColumn";
			this.IDColumn.ReadOnly = true;
			this.IDColumn.Visible = false;
			// 
			// marketDateDataGridViewTextBoxColumn
			// 
			this.marketDateDataGridViewTextBoxColumn.DataPropertyName = "MarketDate";
			dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
			this.marketDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.marketDateDataGridViewTextBoxColumn.HeaderText = "Date";
			this.marketDateDataGridViewTextBoxColumn.Name = "marketDateDataGridViewTextBoxColumn";
			this.marketDateDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// marketLocationDataGridViewTextBoxColumn
			// 
			this.marketLocationDataGridViewTextBoxColumn.DataPropertyName = "MarketLocation";
			this.marketLocationDataGridViewTextBoxColumn.HeaderText = "Location";
			this.marketLocationDataGridViewTextBoxColumn.Name = "marketLocationDataGridViewTextBoxColumn";
			this.marketLocationDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// ActualCashAfterMarket
			// 
			this.ActualCashAfterMarket.DataPropertyName = "ActualCashAfterMarket";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "C2";
			this.ActualCashAfterMarket.DefaultCellStyle = dataGridViewCellStyle2;
			this.ActualCashAfterMarket.HeaderText = "Takings";
			this.ActualCashAfterMarket.Name = "ActualCashAfterMarket";
			this.ActualCashAfterMarket.ReadOnly = true;
			// 
			// Comments
			// 
			this.Comments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Comments.DataPropertyName = "Comments";
			this.Comments.HeaderText = "Comments";
			this.Comments.Name = "Comments";
			this.Comments.ReadOnly = true;
			// 
			// MarketsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(683, 273);
			this.Controls.Add(this.MarketsDataGridViewWithPaste);
			this.Name = "MarketsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Markets";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MarketsForm_FormClosing);
			this.Load += new System.EventHandler(this.MarketsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.MarketsDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MarketsDataTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MarketsDataGridViewWithPaste)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Data.DataSet MarketsDataSet;
		private System.Data.DataTable MarketsDataTable;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Data.DataColumn dataColumn4;
		private Controls.DataGridViewWithPaste MarketsDataGridViewWithPaste;
		private System.Data.DataColumn dataColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn marketDateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn marketLocationDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ActualCashAfterMarket;
		private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
	}
}