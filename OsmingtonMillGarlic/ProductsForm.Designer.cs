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
			this.ProductsDataSet = new System.Data.DataSet();
			this.ProductsDataTable = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataColumn5 = new System.Data.DataColumn();
			this.SaveButton = new System.Windows.Forms.Button();
			this.ProductsDataGridViewWithPaste = new OsmingtonMillGarlic.Controls.DataGridViewWithPaste();
			this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.wholesalePriceDataGridViewTextBoxColumn = new OsmingtonMillGarlic.Controls.NumericDataGridViewColumn();
			this.marketPriceDataGridViewTextBoxColumn = new OsmingtonMillGarlic.Controls.NumericDataGridViewColumn();
			this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataColumn5});
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
			this.ProductsDataGridViewWithPaste.AllowUserToDeleteRows = false;
			this.ProductsDataGridViewWithPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProductsDataGridViewWithPaste.AutoGenerateColumns = false;
			this.ProductsDataGridViewWithPaste.BackgroundColor = System.Drawing.SystemColors.Window;
			this.ProductsDataGridViewWithPaste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ProductsDataGridViewWithPaste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.descriptionDataGridViewTextBoxColumn,
            this.wholesalePriceDataGridViewTextBoxColumn,
            this.marketPriceDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
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
			this.wholesalePriceDataGridViewTextBoxColumn.AllowDecimal = true;
			this.wholesalePriceDataGridViewTextBoxColumn.AllowNegative = false;
			this.wholesalePriceDataGridViewTextBoxColumn.DataPropertyName = "WholesalePrice";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle1.Format = "C2";
			this.wholesalePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.wholesalePriceDataGridViewTextBoxColumn.HeaderText = "WholesalePrice";
			this.wholesalePriceDataGridViewTextBoxColumn.Name = "wholesalePriceDataGridViewTextBoxColumn";
			this.wholesalePriceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.wholesalePriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// marketPriceDataGridViewTextBoxColumn
			// 
			this.marketPriceDataGridViewTextBoxColumn.AllowDecimal = true;
			this.marketPriceDataGridViewTextBoxColumn.AllowNegative = false;
			this.marketPriceDataGridViewTextBoxColumn.DataPropertyName = "MarketPrice";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "C2";
			this.marketPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.marketPriceDataGridViewTextBoxColumn.HeaderText = "MarketPrice";
			this.marketPriceDataGridViewTextBoxColumn.Name = "marketPriceDataGridViewTextBoxColumn";
			this.marketPriceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.marketPriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// iDDataGridViewTextBoxColumn
			// 
			this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
			dataGridViewCellStyle3.NullValue = "0";
			this.iDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
			this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
			this.iDDataGridViewTextBoxColumn.Visible = false;
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
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private Controls.NumericDataGridViewColumn wholesalePriceDataGridViewTextBoxColumn;
		private Controls.NumericDataGridViewColumn marketPriceDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
	}
}