namespace OsmingtonMillGarlic
{
	partial class ProductsForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.ProductsDataSet = new System.Data.DataSet();
			this.ProductsDataTable = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataColumn5 = new System.Data.DataColumn();
			this.dataColumn6 = new System.Data.DataColumn();
			this.SaveButton = new System.Windows.Forms.Button();
			this.ProductsDataGridViewWithPaste = new OsmingtonMillGarlic.Controls.DataGridViewWithPaste();
			this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.wholesalePriceDataGridViewTextBoxColumn = new OsmingtonMillGarlic.Controls.NumericDataGridViewColumn();
			this.marketPriceDataGridViewTextBoxColumn = new OsmingtonMillGarlic.Controls.NumericDataGridViewColumn();
			this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.ProductsDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ProductsDataTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridViewWithPaste)).BeginInit();
			this.SuspendLayout();
			// 
			// ProductsDataSet
			// 
			this.ProductsDataSet.DataSetName = "NewDataSet";
			this.ProductsDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.ProductsDataTable});
			// 
			// ProductsDataTable
			// 
			this.ProductsDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
			this.ProductsDataTable.TableName = "Products";
			// 
			// dataColumn1
			// 
			this.dataColumn1.ColumnName = "Active";
			this.dataColumn1.DataType = typeof(bool);
			// 
			// dataColumn2
			// 
			this.dataColumn2.ColumnName = "Description";
			// 
			// dataColumn3
			// 
			this.dataColumn3.ColumnName = "WholesalePrice";
			this.dataColumn3.DataType = typeof(decimal);
			// 
			// dataColumn4
			// 
			this.dataColumn4.ColumnName = "MarketPrice";
			this.dataColumn4.DataType = typeof(decimal);
			// 
			// dataColumn5
			// 
			this.dataColumn5.AutoIncrement = true;
			this.dataColumn5.ColumnName = "ID";
			this.dataColumn5.DataType = typeof(int);
			// 
			// dataColumn6
			// 
			this.dataColumn6.ColumnName = "DisplayOrder";
			this.dataColumn6.DataType = typeof(int);
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveButton.Location = new System.Drawing.Point(598, 12);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 1;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// ProductsDataGridViewWithPaste
			// 
			this.ProductsDataGridViewWithPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProductsDataGridViewWithPaste.AutoGenerateColumns = false;
			this.ProductsDataGridViewWithPaste.BackgroundColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ProductsDataGridViewWithPaste.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.ProductsDataGridViewWithPaste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ProductsDataGridViewWithPaste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.descriptionDataGridViewTextBoxColumn,
            this.wholesalePriceDataGridViewTextBoxColumn,
            this.marketPriceDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn,
            this.DisplayOrder});
			this.ProductsDataGridViewWithPaste.DataMember = "Products";
			this.ProductsDataGridViewWithPaste.DataSource = this.ProductsDataSet;
			this.ProductsDataGridViewWithPaste.Location = new System.Drawing.Point(12, 12);
			this.ProductsDataGridViewWithPaste.Name = "ProductsDataGridViewWithPaste";
			this.ProductsDataGridViewWithPaste.Size = new System.Drawing.Size(580, 290);
			this.ProductsDataGridViewWithPaste.TabIndex = 0;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "Active";
			this.Column1.HeaderText = "Active";
			this.Column1.Name = "Column1";
			this.Column1.Width = 50;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
			this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
			this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			// 
			// wholesalePriceDataGridViewTextBoxColumn
			// 
			this.wholesalePriceDataGridViewTextBoxColumn.AllowDecimal = false;
			this.wholesalePriceDataGridViewTextBoxColumn.AllowNegative = false;
			this.wholesalePriceDataGridViewTextBoxColumn.DataPropertyName = "WholesalePrice";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "C2";
			this.wholesalePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.wholesalePriceDataGridViewTextBoxColumn.HeaderText = "Wholesale Price";
			this.wholesalePriceDataGridViewTextBoxColumn.Name = "wholesalePriceDataGridViewTextBoxColumn";
			this.wholesalePriceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.wholesalePriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.wholesalePriceDataGridViewTextBoxColumn.Width = 80;
			// 
			// marketPriceDataGridViewTextBoxColumn
			// 
			this.marketPriceDataGridViewTextBoxColumn.AllowDecimal = false;
			this.marketPriceDataGridViewTextBoxColumn.AllowNegative = false;
			this.marketPriceDataGridViewTextBoxColumn.DataPropertyName = "MarketPrice";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "C2";
			this.marketPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
			this.marketPriceDataGridViewTextBoxColumn.HeaderText = "Market Price";
			this.marketPriceDataGridViewTextBoxColumn.Name = "marketPriceDataGridViewTextBoxColumn";
			this.marketPriceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.marketPriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.marketPriceDataGridViewTextBoxColumn.Width = 80;
			// 
			// iDDataGridViewTextBoxColumn
			// 
			this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
			dataGridViewCellStyle4.NullValue = "0";
			this.iDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
			this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
			this.iDDataGridViewTextBoxColumn.Visible = false;
			// 
			// DisplayOrder
			// 
			this.DisplayOrder.DataPropertyName = "DisplayOrder";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.DisplayOrder.DefaultCellStyle = dataGridViewCellStyle5;
			this.DisplayOrder.HeaderText = "Display Order";
			this.DisplayOrder.Name = "DisplayOrder";
			this.DisplayOrder.Width = 50;
			// 
			// ProductsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(685, 314);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.ProductsDataGridViewWithPaste);
			this.Name = "ProductsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Products";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductsForm_FormClosing);
			this.Load += new System.EventHandler(this.ProductsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.ProductsDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ProductsDataTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridViewWithPaste)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.DataGridViewWithPaste ProductsDataGridViewWithPaste;
		private System.Data.DataSet ProductsDataSet;
		private System.Data.DataTable ProductsDataTable;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Data.DataColumn dataColumn4;
		private System.Windows.Forms.Button SaveButton;
		private System.Data.DataColumn dataColumn5;
		private System.Data.DataColumn dataColumn6;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private Controls.NumericDataGridViewColumn wholesalePriceDataGridViewTextBoxColumn;
		private Controls.NumericDataGridViewColumn marketPriceDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn DisplayOrder;
	}
}