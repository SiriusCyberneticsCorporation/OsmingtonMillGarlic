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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProductsDataSet = new System.Data.DataSet();
            this.ProductsDataTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.GarlicVarietyDataTable = new System.Data.DataTable();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ProductsDataGridViewWithPaste = new OsmingtonMillGarlic.Controls.DataGridViewWithPaste();
            this.dataColumn14 = new System.Data.DataColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wholesalePriceDataGridViewTextBoxColumn = new OsmingtonMillGarlic.Controls.NumericDataGridViewColumn();
            this.marketPriceDataGridViewTextBoxColumn = new OsmingtonMillGarlic.Controls.NumericDataGridViewColumn();
            this.UnitWeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VarietyIDColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WholeGarlic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GarlicVarietyDataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridViewWithPaste)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductsDataSet
            // 
            this.ProductsDataSet.DataSetName = "NewDataSet";
            this.ProductsDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.ProductsDataTable,
            this.GarlicVarietyDataTable});
            // 
            // ProductsDataTable
            // 
            this.ProductsDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn14});
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
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "Unit";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "Units";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "PerUnit";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "UnitWeight";
            this.dataColumn10.DataType = typeof(decimal);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "VarietyID";
            this.dataColumn11.DataType = typeof(int);
            // 
            // GarlicVarietyDataTable
            // 
            this.GarlicVarietyDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn12,
            this.dataColumn13});
            this.GarlicVarietyDataTable.TableName = "GarlicVariety";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "ID";
            this.dataColumn12.DataType = typeof(int);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "Name";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(825, 12);
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
            this.UnitWeightColumn,
            this.VarietyIDColumn,
            this.Unit,
            this.Units,
            this.PerUnit,
            this.iDDataGridViewTextBoxColumn,
            this.DisplayOrder,
            this.WholeGarlic});
            this.ProductsDataGridViewWithPaste.DataMember = "Products";
            this.ProductsDataGridViewWithPaste.DataSource = this.ProductsDataSet;
            this.ProductsDataGridViewWithPaste.Location = new System.Drawing.Point(12, 12);
            this.ProductsDataGridViewWithPaste.Name = "ProductsDataGridViewWithPaste";
            this.ProductsDataGridViewWithPaste.Size = new System.Drawing.Size(807, 290);
            this.ProductsDataGridViewWithPaste.TabIndex = 0;
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "WholeGarlic";
            this.dataColumn14.DataType = typeof(bool);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Active";
            this.Column1.HeaderText = "Active";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
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
            this.wholesalePriceDataGridViewTextBoxColumn.Width = 65;
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
            this.marketPriceDataGridViewTextBoxColumn.Width = 65;
            // 
            // UnitWeightColumn
            // 
            this.UnitWeightColumn.DataPropertyName = "UnitWeight";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.UnitWeightColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.UnitWeightColumn.HeaderText = "Weight";
            this.UnitWeightColumn.Name = "UnitWeightColumn";
            this.UnitWeightColumn.Width = 50;
            // 
            // VarietyIDColumn
            // 
            this.VarietyIDColumn.DataPropertyName = "VarietyID";
            this.VarietyIDColumn.DataSource = this.ProductsDataSet;
            this.VarietyIDColumn.DisplayMember = "GarlicVariety.Name";
            this.VarietyIDColumn.HeaderText = "Variety";
            this.VarietyIDColumn.Name = "VarietyIDColumn";
            this.VarietyIDColumn.ValueMember = "GarlicVariety.ID";
            this.VarietyIDColumn.Width = 110;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Unit.Width = 50;
            // 
            // Units
            // 
            this.Units.DataPropertyName = "Units";
            this.Units.HeaderText = "Units";
            this.Units.Name = "Units";
            this.Units.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Units.Width = 50;
            // 
            // PerUnit
            // 
            this.PerUnit.DataPropertyName = "PerUnit";
            this.PerUnit.HeaderText = "Per Unit Text";
            this.PerUnit.Name = "PerUnit";
            this.PerUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PerUnit.Width = 55;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            dataGridViewCellStyle5.NullValue = "0";
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // DisplayOrder
            // 
            this.DisplayOrder.DataPropertyName = "DisplayOrder";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DisplayOrder.DefaultCellStyle = dataGridViewCellStyle6;
            this.DisplayOrder.HeaderText = "Display Order";
            this.DisplayOrder.Name = "DisplayOrder";
            this.DisplayOrder.Width = 50;
            // 
            // WholeGarlic
            // 
            this.WholeGarlic.DataPropertyName = "WholeGarlic";
            this.WholeGarlic.HeaderText = "Whole Garlic";
            this.WholeGarlic.Name = "WholeGarlic";
            this.WholeGarlic.Width = 50;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 314);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ProductsDataGridViewWithPaste);
            this.MaximizeBox = false;
            this.Name = "ProductsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Products";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductsForm_FormClosing);
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GarlicVarietyDataTable)).EndInit();
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
		private System.Data.DataColumn dataColumn7;
		private System.Data.DataColumn dataColumn8;
		private System.Data.DataColumn dataColumn9;
		private System.Data.DataColumn dataColumn10;
		private System.Data.DataColumn dataColumn11;
		private System.Data.DataTable GarlicVarietyDataTable;
		private System.Data.DataColumn dataColumn12;
		private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn WholeGarlic;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewComboBoxColumn VarietyIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitWeightColumn;
        private Controls.NumericDataGridViewColumn marketPriceDataGridViewTextBoxColumn;
        private Controls.NumericDataGridViewColumn wholesalePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}