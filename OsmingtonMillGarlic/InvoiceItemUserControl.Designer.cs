namespace OsmingtonMillGarlic
{
	partial class InvoiceItemUserControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TextBox textBox5;
			this.DescriptionTextBox = new System.Windows.Forms.TextBox();
			this.InvoiceItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.InvoiceItemsDataSet = new System.Data.DataSet();
			this.InvoiceItemsDataTable = new System.Data.DataTable();
			this.dataColumn10 = new System.Data.DataColumn();
			this.dataColumn11 = new System.Data.DataColumn();
			this.dataColumn12 = new System.Data.DataColumn();
			this.dataColumn13 = new System.Data.DataColumn();
			this.dataColumn16 = new System.Data.DataColumn();
			this.dataColumn14 = new System.Data.DataColumn();
			this.dataColumn15 = new System.Data.DataColumn();
			this.dataColumn17 = new System.Data.DataColumn();
			this.dataColumn18 = new System.Data.DataColumn();
			this.UnitsTextBox = new System.Windows.Forms.TextBox();
			this.PerUnitTextBox = new System.Windows.Forms.TextBox();
			this.AddProductButton = new System.Windows.Forms.Button();
			this.AlterButton = new System.Windows.Forms.Button();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.AmountNumericTextBox = new OsmingtonMillGarlic.Controls.NumericTextBox();
			this.UnitPriceNumericTextBox = new OsmingtonMillGarlic.Controls.NumericTextBox();
			this.QuantityNumericTextBox = new OsmingtonMillGarlic.Controls.NumericTextBox();
			textBox5 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceItemsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceItemsDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceItemsDataTable)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox5
			// 
			textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			textBox5.BackColor = System.Drawing.SystemColors.Window;
			textBox5.Location = new System.Drawing.Point(645, 1);
			textBox5.Name = "textBox5";
			textBox5.ReadOnly = true;
			textBox5.Size = new System.Drawing.Size(100, 20);
			textBox5.TabIndex = 6;
			textBox5.TabStop = false;
			// 
			// DescriptionTextBox
			// 
			this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoiceItemsBindingSource, "Description", true));
			this.DescriptionTextBox.Location = new System.Drawing.Point(1, 1);
			this.DescriptionTextBox.Name = "DescriptionTextBox";
			this.DescriptionTextBox.Size = new System.Drawing.Size(645, 20);
			this.DescriptionTextBox.TabIndex = 0;
			this.DescriptionTextBox.Validated += new System.EventHandler(this.Control_Validated);
			// 
			// InvoiceItemsBindingSource
			// 
			this.InvoiceItemsBindingSource.DataMember = "InvoiceItems";
			this.InvoiceItemsBindingSource.DataSource = this.InvoiceItemsDataSet;
			// 
			// InvoiceItemsDataSet
			// 
			this.InvoiceItemsDataSet.DataSetName = "NewDataSet";
			this.InvoiceItemsDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.InvoiceItemsDataTable});
			// 
			// InvoiceItemsDataTable
			// 
			this.InvoiceItemsDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn16,
            this.dataColumn14,
            this.dataColumn15,
            this.dataColumn17,
            this.dataColumn18});
			this.InvoiceItemsDataTable.TableName = "InvoiceItems";
			// 
			// dataColumn10
			// 
			this.dataColumn10.AutoIncrement = true;
			this.dataColumn10.ColumnName = "ID";
			this.dataColumn10.DataType = typeof(int);
			// 
			// dataColumn11
			// 
			this.dataColumn11.ColumnName = "InvoiceID";
			this.dataColumn11.DataType = typeof(int);
			// 
			// dataColumn12
			// 
			this.dataColumn12.ColumnName = "ProductID";
			this.dataColumn12.DataType = typeof(int);
			// 
			// dataColumn13
			// 
			this.dataColumn13.ColumnName = "Description";
			// 
			// dataColumn16
			// 
			this.dataColumn16.ColumnName = "Quantity";
			this.dataColumn16.DataType = typeof(decimal);
			// 
			// dataColumn14
			// 
			this.dataColumn14.ColumnName = "UnitsText";
			// 
			// dataColumn15
			// 
			this.dataColumn15.ColumnName = "UnitPrice";
			this.dataColumn15.DataType = typeof(decimal);
			// 
			// dataColumn17
			// 
			this.dataColumn17.ColumnName = "PerUnitText";
			// 
			// dataColumn18
			// 
			this.dataColumn18.ColumnName = "Amount";
			this.dataColumn18.DataType = typeof(decimal);
			// 
			// UnitsTextBox
			// 
			this.UnitsTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.UnitsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoiceItemsBindingSource, "UnitsText", true));
			this.UnitsTextBox.Location = new System.Drawing.Point(62, 22);
			this.UnitsTextBox.Name = "UnitsTextBox";
			this.UnitsTextBox.Size = new System.Drawing.Size(100, 20);
			this.UnitsTextBox.TabIndex = 2;
			this.UnitsTextBox.Validated += new System.EventHandler(this.Control_Validated);
			// 
			// PerUnitTextBox
			// 
			this.PerUnitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PerUnitTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.PerUnitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoiceItemsBindingSource, "PerUnitText", true));
			this.PerUnitTextBox.Location = new System.Drawing.Point(214, 22);
			this.PerUnitTextBox.Name = "PerUnitTextBox";
			this.PerUnitTextBox.Size = new System.Drawing.Size(432, 20);
			this.PerUnitTextBox.TabIndex = 4;
			this.PerUnitTextBox.Validated += new System.EventHandler(this.Control_Validated);
			// 
			// AddProductButton
			// 
			this.AddProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AddProductButton.Location = new System.Drawing.Point(746, 1);
			this.AddProductButton.Name = "AddProductButton";
			this.AddProductButton.Size = new System.Drawing.Size(54, 41);
			this.AddProductButton.TabIndex = 8;
			this.AddProductButton.TabStop = false;
			this.AddProductButton.Text = "Add\r\nProduct";
			this.AddProductButton.UseVisualStyleBackColor = true;
			this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
			// 
			// AlterButton
			// 
			this.AlterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AlterButton.Location = new System.Drawing.Point(746, 22);
			this.AlterButton.Name = "AlterButton";
			this.AlterButton.Size = new System.Drawing.Size(54, 20);
			this.AlterButton.TabIndex = 7;
			this.AlterButton.TabStop = false;
			this.AlterButton.Text = "Alter";
			this.AlterButton.UseVisualStyleBackColor = true;
			this.AlterButton.Visible = false;
			this.AlterButton.Click += new System.EventHandler(this.AlterButton_Click);
			// 
			// DeleteButton
			// 
			this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeleteButton.Location = new System.Drawing.Point(746, 1);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(54, 20);
			this.DeleteButton.TabIndex = 6;
			this.DeleteButton.TabStop = false;
			this.DeleteButton.Text = "Delete";
			this.DeleteButton.UseVisualStyleBackColor = true;
			this.DeleteButton.Visible = false;
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// AmountNumericTextBox
			// 
			this.AmountNumericTextBox.AllowDecimal = true;
			this.AmountNumericTextBox.AllowNegative = true;
			this.AmountNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AmountNumericTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.AmountNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoiceItemsBindingSource, "Amount", true));
			this.AmountNumericTextBox.Location = new System.Drawing.Point(645, 22);
			this.AmountNumericTextBox.Name = "AmountNumericTextBox";
			this.AmountNumericTextBox.ReadOnly = true;
			this.AmountNumericTextBox.Size = new System.Drawing.Size(100, 20);
			this.AmountNumericTextBox.TabIndex = 5;
			this.AmountNumericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.AmountNumericTextBox.Validated += new System.EventHandler(this.Control_Validated);
			// 
			// UnitPriceNumericTextBox
			// 
			this.UnitPriceNumericTextBox.AllowDecimal = true;
			this.UnitPriceNumericTextBox.AllowNegative = true;
			this.UnitPriceNumericTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.UnitPriceNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoiceItemsBindingSource, "UnitPrice", true));
			this.UnitPriceNumericTextBox.Location = new System.Drawing.Point(161, 22);
			this.UnitPriceNumericTextBox.Name = "UnitPriceNumericTextBox";
			this.UnitPriceNumericTextBox.Size = new System.Drawing.Size(54, 20);
			this.UnitPriceNumericTextBox.TabIndex = 3;
			this.UnitPriceNumericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.UnitPriceNumericTextBox.NumberEntered += new OsmingtonMillGarlic.Controls.NumericTextBox.NumberEnteredHandler(this.UnitPriceNumericTextBox_NumberEntered);
			this.UnitPriceNumericTextBox.Validated += new System.EventHandler(this.Control_Validated);
			// 
			// QuantityNumericTextBox
			// 
			this.QuantityNumericTextBox.AllowDecimal = true;
			this.QuantityNumericTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.QuantityNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoiceItemsBindingSource, "Quantity", true));
			this.QuantityNumericTextBox.Location = new System.Drawing.Point(1, 22);
			this.QuantityNumericTextBox.Name = "QuantityNumericTextBox";
			this.QuantityNumericTextBox.Size = new System.Drawing.Size(62, 20);
			this.QuantityNumericTextBox.TabIndex = 1;
			this.QuantityNumericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.QuantityNumericTextBox.NumberEntered += new OsmingtonMillGarlic.Controls.NumericTextBox.NumberEnteredHandler(this.QuantityNumericTextBox_NumberEntered);
			this.QuantityNumericTextBox.Validated += new System.EventHandler(this.Control_Validated);
			// 
			// InvoiceItemUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.AmountNumericTextBox);
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.AlterButton);
			this.Controls.Add(textBox5);
			this.Controls.Add(this.PerUnitTextBox);
			this.Controls.Add(this.UnitPriceNumericTextBox);
			this.Controls.Add(this.UnitsTextBox);
			this.Controls.Add(this.QuantityNumericTextBox);
			this.Controls.Add(this.DescriptionTextBox);
			this.Controls.Add(this.AddProductButton);
			this.Name = "InvoiceItemUserControl";
			this.Size = new System.Drawing.Size(800, 42);
			((System.ComponentModel.ISupportInitialize)(this.InvoiceItemsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceItemsDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceItemsDataTable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button AddProductButton;
		private System.Windows.Forms.Button AlterButton;
		private System.Windows.Forms.Button DeleteButton;
		public System.Windows.Forms.TextBox DescriptionTextBox;
		public Controls.NumericTextBox QuantityNumericTextBox;
		public System.Windows.Forms.TextBox UnitsTextBox;
		public System.Windows.Forms.TextBox PerUnitTextBox;
		public Controls.NumericTextBox UnitPriceNumericTextBox;
		public Controls.NumericTextBox AmountNumericTextBox;
		private System.Data.DataSet InvoiceItemsDataSet;
		private System.Data.DataTable InvoiceItemsDataTable;
		private System.Data.DataColumn dataColumn10;
		private System.Data.DataColumn dataColumn11;
		private System.Data.DataColumn dataColumn12;
		private System.Data.DataColumn dataColumn13;
		private System.Data.DataColumn dataColumn16;
		private System.Data.DataColumn dataColumn14;
		private System.Data.DataColumn dataColumn15;
		private System.Data.DataColumn dataColumn17;
		private System.Data.DataColumn dataColumn18;
		private System.Windows.Forms.BindingSource InvoiceItemsBindingSource;
	}
}
