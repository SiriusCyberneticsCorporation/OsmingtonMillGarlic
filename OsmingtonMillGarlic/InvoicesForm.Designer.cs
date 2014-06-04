namespace OsmingtonMillGarlic
{
	partial class InvoicesForm
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
			this.InvoicesDataSet = new System.Data.DataSet();
			this.InvoicesDataTable = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataColumn5 = new System.Data.DataColumn();
			this.dataColumn6 = new System.Data.DataColumn();
			this.dataColumn7 = new System.Data.DataColumn();
			this.InvoicesDataGridViewWithPaste = new OsmingtonMillGarlic.Controls.DataGridViewWithPaste();
			this.InvoiceTypesDataTable = new System.Data.DataTable();
			this.dataColumn8 = new System.Data.DataColumn();
			this.dataColumn9 = new System.Data.DataColumn();
			this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.invoiceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.invoiceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.invoiceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.InvoiceTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.referenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.InvoicesDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoicesDataTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoicesDataGridViewWithPaste)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceTypesDataTable)).BeginInit();
			this.SuspendLayout();
			// 
			// InvoicesDataSet
			// 
			this.InvoicesDataSet.DataSetName = "NewDataSet";
			this.InvoicesDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.InvoicesDataTable,
            this.InvoiceTypesDataTable});
			// 
			// InvoicesDataTable
			// 
			this.InvoicesDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7});
			this.InvoicesDataTable.TableName = "Invoices";
			// 
			// dataColumn1
			// 
			this.dataColumn1.ColumnName = "ID";
			this.dataColumn1.DataType = typeof(int);
			// 
			// dataColumn2
			// 
			this.dataColumn2.ColumnName = "InvoiceType";
			this.dataColumn2.DataType = typeof(int);
			// 
			// dataColumn3
			// 
			this.dataColumn3.ColumnName = "InvoiceNumber";
			this.dataColumn3.DataType = typeof(int);
			// 
			// dataColumn4
			// 
			this.dataColumn4.ColumnName = "InvoiceDate";
			this.dataColumn4.DataType = typeof(System.DateTime);
			// 
			// dataColumn5
			// 
			this.dataColumn5.ColumnName = "InvoiceTo";
			// 
			// dataColumn6
			// 
			this.dataColumn6.ColumnName = "Reference";
			// 
			// dataColumn7
			// 
			this.dataColumn7.ColumnName = "Total";
			this.dataColumn7.DataType = typeof(decimal);
			// 
			// InvoicesDataGridViewWithPaste
			// 
			this.InvoicesDataGridViewWithPaste.AllowUserToAddRows = false;
			this.InvoicesDataGridViewWithPaste.AllowUserToDeleteRows = false;
			this.InvoicesDataGridViewWithPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InvoicesDataGridViewWithPaste.AutoGenerateColumns = false;
			this.InvoicesDataGridViewWithPaste.BackgroundColor = System.Drawing.SystemColors.Window;
			this.InvoicesDataGridViewWithPaste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.InvoicesDataGridViewWithPaste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.invoiceTypeDataGridViewTextBoxColumn,
            this.invoiceNumberDataGridViewTextBoxColumn,
            this.invoiceDateDataGridViewTextBoxColumn,
            this.InvoiceTo,
            this.referenceDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
			this.InvoicesDataGridViewWithPaste.DataMember = "Invoices";
			this.InvoicesDataGridViewWithPaste.DataSource = this.InvoicesDataSet;
			this.InvoicesDataGridViewWithPaste.Location = new System.Drawing.Point(12, 12);
			this.InvoicesDataGridViewWithPaste.Name = "InvoicesDataGridViewWithPaste";
			this.InvoicesDataGridViewWithPaste.ReadOnly = true;
			this.InvoicesDataGridViewWithPaste.RowHeadersVisible = false;
			this.InvoicesDataGridViewWithPaste.Size = new System.Drawing.Size(575, 378);
			this.InvoicesDataGridViewWithPaste.TabIndex = 0;
			this.InvoicesDataGridViewWithPaste.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InvoicesDataGridViewWithPaste_CellMouseDoubleClick);
			// 
			// InvoiceTypesDataTable
			// 
			this.InvoiceTypesDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn8,
            this.dataColumn9});
			this.InvoiceTypesDataTable.TableName = "InvoiceTypes";
			// 
			// dataColumn8
			// 
			this.dataColumn8.ColumnName = "ID";
			this.dataColumn8.DataType = typeof(int);
			// 
			// dataColumn9
			// 
			this.dataColumn9.ColumnName = "Description";
			// 
			// IDColumn
			// 
			this.IDColumn.DataPropertyName = "ID";
			this.IDColumn.HeaderText = "ID";
			this.IDColumn.Name = "IDColumn";
			this.IDColumn.ReadOnly = true;
			this.IDColumn.Visible = false;
			// 
			// invoiceTypeDataGridViewTextBoxColumn
			// 
			this.invoiceTypeDataGridViewTextBoxColumn.DataPropertyName = "InvoiceType";
			this.invoiceTypeDataGridViewTextBoxColumn.DataSource = this.InvoicesDataSet;
			this.invoiceTypeDataGridViewTextBoxColumn.DisplayMember = "InvoiceTypes.Description";
			this.invoiceTypeDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.invoiceTypeDataGridViewTextBoxColumn.HeaderText = "Invoice Type";
			this.invoiceTypeDataGridViewTextBoxColumn.Name = "invoiceTypeDataGridViewTextBoxColumn";
			this.invoiceTypeDataGridViewTextBoxColumn.ReadOnly = true;
			this.invoiceTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.invoiceTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.invoiceTypeDataGridViewTextBoxColumn.ValueMember = "InvoiceTypes.ID";
			this.invoiceTypeDataGridViewTextBoxColumn.Width = 150;
			// 
			// invoiceNumberDataGridViewTextBoxColumn
			// 
			this.invoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber";
			this.invoiceNumberDataGridViewTextBoxColumn.HeaderText = "Invoice Number";
			this.invoiceNumberDataGridViewTextBoxColumn.Name = "invoiceNumberDataGridViewTextBoxColumn";
			this.invoiceNumberDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// invoiceDateDataGridViewTextBoxColumn
			// 
			this.invoiceDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDate";
			dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
			this.invoiceDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.invoiceDateDataGridViewTextBoxColumn.HeaderText = "Invoice Date";
			this.invoiceDateDataGridViewTextBoxColumn.Name = "invoiceDateDataGridViewTextBoxColumn";
			this.invoiceDateDataGridViewTextBoxColumn.ReadOnly = true;
			this.invoiceDateDataGridViewTextBoxColumn.Width = 90;
			// 
			// InvoiceTo
			// 
			this.InvoiceTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.InvoiceTo.DataPropertyName = "InvoiceTo";
			this.InvoiceTo.HeaderText = "To";
			this.InvoiceTo.Name = "InvoiceTo";
			this.InvoiceTo.ReadOnly = true;
			// 
			// referenceDataGridViewTextBoxColumn
			// 
			this.referenceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.referenceDataGridViewTextBoxColumn.DataPropertyName = "Reference";
			this.referenceDataGridViewTextBoxColumn.HeaderText = "Reference";
			this.referenceDataGridViewTextBoxColumn.Name = "referenceDataGridViewTextBoxColumn";
			this.referenceDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// totalDataGridViewTextBoxColumn
			// 
			this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "C2";
			this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
			this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
			this.totalDataGridViewTextBoxColumn.ReadOnly = true;
			this.totalDataGridViewTextBoxColumn.Width = 50;
			// 
			// InvoicesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 402);
			this.Controls.Add(this.InvoicesDataGridViewWithPaste);
			this.Name = "InvoicesForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Invoices";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InvoicesForm_FormClosing);
			this.Load += new System.EventHandler(this.InvoicesForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.InvoicesDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoicesDataTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoicesDataGridViewWithPaste)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceTypesDataTable)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Data.DataSet InvoicesDataSet;
		private System.Data.DataTable InvoicesDataTable;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Data.DataColumn dataColumn4;
		private System.Data.DataColumn dataColumn5;
		private System.Data.DataColumn dataColumn6;
		private System.Data.DataColumn dataColumn7;
		private Controls.DataGridViewWithPaste InvoicesDataGridViewWithPaste;
		private System.Data.DataTable InvoiceTypesDataTable;
		private System.Data.DataColumn dataColumn8;
		private System.Data.DataColumn dataColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn invoiceTypeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn invoiceDateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceTo;
		private System.Windows.Forms.DataGridViewTextBoxColumn referenceDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
	}
}