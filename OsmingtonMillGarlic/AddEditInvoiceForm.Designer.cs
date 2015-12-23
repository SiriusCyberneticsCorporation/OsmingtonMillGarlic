namespace OsmingtonMillGarlic
{
	partial class AddEditInvoiceForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InvoiceDateNullableDatePicker = new OsmingtonMillGarlic.Controls.NullableDatePicker();
            this.InvoicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InvoicesDataSet = new System.Data.DataSet();
            this.InvoicesDataTable = new System.Data.DataTable();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
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
            this.InvoiceTypesDataTable = new System.Data.DataTable();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.InvoiceNumberTextBox = new System.Windows.Forms.TextBox();
            this.ToTextBox = new System.Windows.Forms.TextBox();
            this.ReferenceTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.InvoiceTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.RetailCheckBox = new System.Windows.Forms.CheckBox();
            this.CreateFileButton = new System.Windows.Forms.Button();
            this.LockInvoiceButton = new System.Windows.Forms.Button();
            this.InvoiceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.numericTextBox1 = new OsmingtonMillGarlic.Controls.NumericTextBox();
            this.InvoiceTotalNumericTextBox = new OsmingtonMillGarlic.Controls.NumericTextBox();
            this.CalculateGstButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GstNumericTextBox = new OsmingtonMillGarlic.Controls.NumericTextBox();
            this.SubTotalNumericTextBox = new OsmingtonMillGarlic.Controls.NumericTextBox();
            this.InvoiceItemsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.InvoiceItem8 = new OsmingtonMillGarlic.InvoiceItemUserControl();
            this.InvoiceItem7 = new OsmingtonMillGarlic.InvoiceItemUserControl();
            this.InvoiceItem6 = new OsmingtonMillGarlic.InvoiceItemUserControl();
            this.InvoiceItem5 = new OsmingtonMillGarlic.InvoiceItemUserControl();
            this.InvoiceItem4 = new OsmingtonMillGarlic.InvoiceItemUserControl();
            this.InvoiceItem3 = new OsmingtonMillGarlic.InvoiceItemUserControl();
            this.InvoiceItem2 = new OsmingtonMillGarlic.InvoiceItemUserControl();
            this.InvoiceItem1 = new OsmingtonMillGarlic.InvoiceItemUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesDataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceItemsDataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceTypesDataTable)).BeginInit();
            this.InvoiceTableLayoutPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.InvoiceItemsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Invoice Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InvoiceDateNullableDatePicker
            // 
            this.InvoiceDateNullableDatePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.InvoicesBindingSource, "InvoiceDate", true));
            this.InvoiceDateNullableDatePicker.Location = new System.Drawing.Point(91, 41);
            this.InvoiceDateNullableDatePicker.MaxDate = new System.DateTime(2079, 1, 1, 0, 0, 0, 0);
            this.InvoiceDateNullableDatePicker.Name = "InvoiceDateNullableDatePicker";
            this.InvoiceDateNullableDatePicker.Size = new System.Drawing.Size(200, 20);
            this.InvoiceDateNullableDatePicker.TabIndex = 3;
            this.InvoiceDateNullableDatePicker.Value = new System.DateTime(2014, 5, 22, 0, 0, 0, 0);
            // 
            // InvoicesBindingSource
            // 
            this.InvoicesBindingSource.DataMember = "Invoices";
            this.InvoicesBindingSource.DataSource = this.InvoicesDataSet;
            // 
            // InvoicesDataSet
            // 
            this.InvoicesDataSet.DataSetName = "NewDataSet";
            this.InvoicesDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.InvoicesDataTable,
            this.InvoiceItemsDataTable,
            this.InvoiceTypesDataTable});
            // 
            // InvoicesDataTable
            // 
            this.InvoicesDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn19,
            this.dataColumn23});
            this.InvoicesDataTable.TableName = "Invoices";
            // 
            // dataColumn5
            // 
            this.dataColumn5.AutoIncrement = true;
            this.dataColumn5.ColumnName = "ID";
            this.dataColumn5.DataType = typeof(int);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "InvoiceNumber";
            this.dataColumn6.DataType = typeof(int);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "InvoiceDate";
            this.dataColumn7.DataType = typeof(System.DateTime);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "InvoiceTo";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "Reference";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "Discount";
            this.dataColumn20.DataType = typeof(decimal);
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "SubTotal";
            this.dataColumn21.DataType = typeof(decimal);
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "GST";
            this.dataColumn22.DataType = typeof(decimal);
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "InvoiceTotal";
            this.dataColumn1.DataType = typeof(decimal);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "InvoiceType";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "Locked";
            this.dataColumn19.DataType = typeof(bool);
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "Retail";
            this.dataColumn23.DataType = typeof(bool);
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
            // InvoiceTypesDataTable
            // 
            this.InvoiceTypesDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn3,
            this.dataColumn4});
            this.InvoiceTypesDataTable.TableName = "InvoiceTypes";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "ID";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Description";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(516, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Invoice Number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InvoiceNumberTextBox
            // 
            this.InvoiceNumberTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.InvoiceNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoicesBindingSource, "InvoiceNumber", true));
            this.InvoiceNumberTextBox.Location = new System.Drawing.Point(609, 42);
            this.InvoiceNumberTextBox.Name = "InvoiceNumberTextBox";
            this.InvoiceNumberTextBox.ReadOnly = true;
            this.InvoiceNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.InvoiceNumberTextBox.TabIndex = 5;
            // 
            // ToTextBox
            // 
            this.ToTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoicesBindingSource, "InvoiceTo", true));
            this.ToTextBox.Location = new System.Drawing.Point(92, 67);
            this.ToTextBox.Multiline = true;
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(229, 45);
            this.ToTextBox.TabIndex = 6;
            // 
            // ReferenceTextBox
            // 
            this.ReferenceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoicesBindingSource, "Reference", true));
            this.ReferenceTextBox.Location = new System.Drawing.Point(480, 67);
            this.ReferenceTextBox.Multiline = true;
            this.ReferenceTextBox.Name = "ReferenceTextBox";
            this.ReferenceTextBox.Size = new System.Drawing.Size(229, 45);
            this.ReferenceTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Reference";
            // 
            // InvoiceTableLayoutPanel
            // 
            this.InvoiceTableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InvoiceTableLayoutPanel.ColumnCount = 1;
            this.InvoiceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.InvoiceTableLayoutPanel.Controls.Add(this.TopPanel, 0, 0);
            this.InvoiceTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 2);
            this.InvoiceTableLayoutPanel.Controls.Add(this.InvoiceItemsTableLayoutPanel, 0, 1);
            this.InvoiceTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.InvoiceTableLayoutPanel.Name = "InvoiceTableLayoutPanel";
            this.InvoiceTableLayoutPanel.RowCount = 3;
            this.InvoiceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.InvoiceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.InvoiceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.InvoiceTableLayoutPanel.Size = new System.Drawing.Size(762, 607);
            this.InvoiceTableLayoutPanel.TabIndex = 0;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.RetailCheckBox);
            this.TopPanel.Controls.Add(this.CreateFileButton);
            this.TopPanel.Controls.Add(this.LockInvoiceButton);
            this.TopPanel.Controls.Add(this.InvoiceTypeComboBox);
            this.TopPanel.Controls.Add(this.label6);
            this.TopPanel.Controls.Add(this.SaveButton);
            this.TopPanel.Controls.Add(this.label4);
            this.TopPanel.Controls.Add(this.ReferenceTextBox);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Controls.Add(this.ToTextBox);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.InvoiceNumberTextBox);
            this.TopPanel.Controls.Add(this.InvoiceDateNullableDatePicker);
            this.TopPanel.Controls.Add(this.label3);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(762, 118);
            this.TopPanel.TabIndex = 0;
            // 
            // RetailCheckBox
            // 
            this.RetailCheckBox.AutoSize = true;
            this.RetailCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RetailCheckBox.Location = new System.Drawing.Point(348, 44);
            this.RetailCheckBox.Name = "RetailCheckBox";
            this.RetailCheckBox.Size = new System.Drawing.Size(53, 17);
            this.RetailCheckBox.TabIndex = 13;
            this.RetailCheckBox.Text = "Retail";
            this.RetailCheckBox.UseVisualStyleBackColor = true;
            this.RetailCheckBox.CheckedChanged += new System.EventHandler(this.RetailCheckBox_CheckedChanged);
            // 
            // CreateFileButton
            // 
            this.CreateFileButton.Location = new System.Drawing.Point(459, 13);
            this.CreateFileButton.Name = "CreateFileButton";
            this.CreateFileButton.Size = new System.Drawing.Size(90, 23);
            this.CreateFileButton.TabIndex = 12;
            this.CreateFileButton.Text = "Create File";
            this.CreateFileButton.UseVisualStyleBackColor = true;
            this.CreateFileButton.Click += new System.EventHandler(this.CreateFileButton_Click);
            // 
            // LockInvoiceButton
            // 
            this.LockInvoiceButton.Location = new System.Drawing.Point(311, 13);
            this.LockInvoiceButton.Name = "LockInvoiceButton";
            this.LockInvoiceButton.Size = new System.Drawing.Size(90, 23);
            this.LockInvoiceButton.TabIndex = 11;
            this.LockInvoiceButton.Text = "Lock Invoice";
            this.LockInvoiceButton.UseVisualStyleBackColor = true;
            this.LockInvoiceButton.Click += new System.EventHandler(this.LockInvoiceButton_Click);
            // 
            // InvoiceTypeComboBox
            // 
            this.InvoiceTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.InvoicesBindingSource, "InvoiceType", true));
            this.InvoiceTypeComboBox.DataSource = this.InvoicesDataSet;
            this.InvoiceTypeComboBox.DisplayMember = "InvoiceTypes.Description";
            this.InvoiceTypeComboBox.FormattingEnabled = true;
            this.InvoiceTypeComboBox.Location = new System.Drawing.Point(92, 14);
            this.InvoiceTypeComboBox.Name = "InvoiceTypeComboBox";
            this.InvoiceTypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.InvoiceTypeComboBox.TabIndex = 10;
            this.InvoiceTypeComboBox.ValueMember = "InvoiceTypes.ID";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Invoice Type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(665, 13);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.numericTextBox1);
            this.BottomPanel.Controls.Add(this.InvoiceTotalNumericTextBox);
            this.BottomPanel.Controls.Add(this.CalculateGstButton);
            this.BottomPanel.Controls.Add(this.label8);
            this.BottomPanel.Controls.Add(this.label7);
            this.BottomPanel.Controls.Add(this.label5);
            this.BottomPanel.Controls.Add(this.GstNumericTextBox);
            this.BottomPanel.Controls.Add(this.SubTotalNumericTextBox);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(12, 467);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(12, 3, 12, 12);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(738, 128);
            this.BottomPanel.TabIndex = 2;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.AllowDecimal = true;
            this.numericTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.numericTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoicesBindingSource, "InvoiceTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.numericTextBox1.Location = new System.Drawing.Point(180, 56);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.ReadOnly = true;
            this.numericTextBox1.Size = new System.Drawing.Size(100, 20);
            this.numericTextBox1.TabIndex = 6;
            this.numericTextBox1.TabStop = false;
            this.numericTextBox1.Visible = false;
            // 
            // InvoiceTotalNumericTextBox
            // 
            this.InvoiceTotalNumericTextBox.AllowDecimal = true;
            this.InvoiceTotalNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InvoiceTotalNumericTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.InvoiceTotalNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoicesBindingSource, "InvoiceTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.InvoiceTotalNumericTextBox.Location = new System.Drawing.Point(582, 55);
            this.InvoiceTotalNumericTextBox.Name = "InvoiceTotalNumericTextBox";
            this.InvoiceTotalNumericTextBox.ReadOnly = true;
            this.InvoiceTotalNumericTextBox.Size = new System.Drawing.Size(100, 20);
            this.InvoiceTotalNumericTextBox.TabIndex = 2;
            this.InvoiceTotalNumericTextBox.TabStop = false;
            this.InvoiceTotalNumericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CalculateGstButton
            // 
            this.CalculateGstButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CalculateGstButton.Location = new System.Drawing.Point(300, 27);
            this.CalculateGstButton.Name = "CalculateGstButton";
            this.CalculateGstButton.Size = new System.Drawing.Size(136, 23);
            this.CalculateGstButton.TabIndex = 3;
            this.CalculateGstButton.Text = "Calculate GST";
            this.CalculateGstButton.UseVisualStyleBackColor = true;
            this.CalculateGstButton.Click += new System.EventHandler(this.CalculateGstButton_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(444, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Total including GST";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(444, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "GST";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(444, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Sub Total";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GstNumericTextBox
            // 
            this.GstNumericTextBox.AllowDecimal = true;
            this.GstNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GstNumericTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.GstNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoicesBindingSource, "GST", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.GstNumericTextBox.Location = new System.Drawing.Point(582, 29);
            this.GstNumericTextBox.Name = "GstNumericTextBox";
            this.GstNumericTextBox.ReadOnly = true;
            this.GstNumericTextBox.Size = new System.Drawing.Size(100, 20);
            this.GstNumericTextBox.TabIndex = 1;
            this.GstNumericTextBox.TabStop = false;
            this.GstNumericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SubTotalNumericTextBox
            // 
            this.SubTotalNumericTextBox.AllowDecimal = true;
            this.SubTotalNumericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SubTotalNumericTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.SubTotalNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.InvoicesBindingSource, "SubTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.SubTotalNumericTextBox.Location = new System.Drawing.Point(582, 3);
            this.SubTotalNumericTextBox.Name = "SubTotalNumericTextBox";
            this.SubTotalNumericTextBox.ReadOnly = true;
            this.SubTotalNumericTextBox.Size = new System.Drawing.Size(100, 20);
            this.SubTotalNumericTextBox.TabIndex = 0;
            this.SubTotalNumericTextBox.TabStop = false;
            this.SubTotalNumericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // InvoiceItemsTableLayoutPanel
            // 
            this.InvoiceItemsTableLayoutPanel.AutoScroll = true;
            this.InvoiceItemsTableLayoutPanel.ColumnCount = 1;
            this.InvoiceItemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.InvoiceItemsTableLayoutPanel.Controls.Add(this.InvoiceItem8, 0, 7);
            this.InvoiceItemsTableLayoutPanel.Controls.Add(this.InvoiceItem7, 0, 6);
            this.InvoiceItemsTableLayoutPanel.Controls.Add(this.InvoiceItem6, 0, 5);
            this.InvoiceItemsTableLayoutPanel.Controls.Add(this.InvoiceItem5, 0, 4);
            this.InvoiceItemsTableLayoutPanel.Controls.Add(this.InvoiceItem4, 0, 3);
            this.InvoiceItemsTableLayoutPanel.Controls.Add(this.InvoiceItem3, 0, 2);
            this.InvoiceItemsTableLayoutPanel.Controls.Add(this.InvoiceItem2, 0, 1);
            this.InvoiceItemsTableLayoutPanel.Controls.Add(this.InvoiceItem1, 0, 0);
            this.InvoiceItemsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceItemsTableLayoutPanel.Location = new System.Drawing.Point(3, 121);
            this.InvoiceItemsTableLayoutPanel.Name = "InvoiceItemsTableLayoutPanel";
            this.InvoiceItemsTableLayoutPanel.RowCount = 9;
            this.InvoiceItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.InvoiceItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.InvoiceItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.InvoiceItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.InvoiceItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.InvoiceItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.InvoiceItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.InvoiceItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.InvoiceItemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.InvoiceItemsTableLayoutPanel.Size = new System.Drawing.Size(756, 340);
            this.InvoiceItemsTableLayoutPanel.TabIndex = 1;
            // 
            // InvoiceItem8
            // 
            this.InvoiceItem8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceItem8.Location = new System.Drawing.Point(10, 294);
            this.InvoiceItem8.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.InvoiceItem8.Name = "InvoiceItem8";
            this.InvoiceItem8.Retail = false;
            this.InvoiceItem8.Size = new System.Drawing.Size(736, 42);
            this.InvoiceItem8.TabIndex = 7;
            this.InvoiceItem8.ItemAdded += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAdded);
            this.InvoiceItem8.ItemAltered += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAltered);
            this.InvoiceItem8.ItemDeleted += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemDeleted);
            // 
            // InvoiceItem7
            // 
            this.InvoiceItem7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceItem7.Location = new System.Drawing.Point(10, 252);
            this.InvoiceItem7.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.InvoiceItem7.Name = "InvoiceItem7";
            this.InvoiceItem7.Retail = false;
            this.InvoiceItem7.Size = new System.Drawing.Size(736, 42);
            this.InvoiceItem7.TabIndex = 6;
            this.InvoiceItem7.ItemAdded += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAdded);
            this.InvoiceItem7.ItemAltered += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAltered);
            this.InvoiceItem7.ItemDeleted += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemDeleted);
            // 
            // InvoiceItem6
            // 
            this.InvoiceItem6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceItem6.Location = new System.Drawing.Point(10, 210);
            this.InvoiceItem6.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.InvoiceItem6.Name = "InvoiceItem6";
            this.InvoiceItem6.Retail = false;
            this.InvoiceItem6.Size = new System.Drawing.Size(736, 42);
            this.InvoiceItem6.TabIndex = 5;
            this.InvoiceItem6.ItemAdded += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAdded);
            this.InvoiceItem6.ItemAltered += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAltered);
            this.InvoiceItem6.ItemDeleted += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemDeleted);
            // 
            // InvoiceItem5
            // 
            this.InvoiceItem5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceItem5.Location = new System.Drawing.Point(10, 168);
            this.InvoiceItem5.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.InvoiceItem5.Name = "InvoiceItem5";
            this.InvoiceItem5.Retail = false;
            this.InvoiceItem5.Size = new System.Drawing.Size(736, 42);
            this.InvoiceItem5.TabIndex = 4;
            this.InvoiceItem5.ItemAdded += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAdded);
            this.InvoiceItem5.ItemAltered += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAltered);
            this.InvoiceItem5.ItemDeleted += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemDeleted);
            // 
            // InvoiceItem4
            // 
            this.InvoiceItem4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceItem4.Location = new System.Drawing.Point(10, 126);
            this.InvoiceItem4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.InvoiceItem4.Name = "InvoiceItem4";
            this.InvoiceItem4.Retail = false;
            this.InvoiceItem4.Size = new System.Drawing.Size(736, 42);
            this.InvoiceItem4.TabIndex = 3;
            this.InvoiceItem4.ItemAdded += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAdded);
            this.InvoiceItem4.ItemAltered += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAltered);
            this.InvoiceItem4.ItemDeleted += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemDeleted);
            // 
            // InvoiceItem3
            // 
            this.InvoiceItem3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceItem3.Location = new System.Drawing.Point(10, 84);
            this.InvoiceItem3.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.InvoiceItem3.Name = "InvoiceItem3";
            this.InvoiceItem3.Retail = false;
            this.InvoiceItem3.Size = new System.Drawing.Size(736, 42);
            this.InvoiceItem3.TabIndex = 2;
            this.InvoiceItem3.ItemAdded += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAdded);
            this.InvoiceItem3.ItemAltered += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAltered);
            this.InvoiceItem3.ItemDeleted += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemDeleted);
            // 
            // InvoiceItem2
            // 
            this.InvoiceItem2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceItem2.Location = new System.Drawing.Point(10, 42);
            this.InvoiceItem2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.InvoiceItem2.Name = "InvoiceItem2";
            this.InvoiceItem2.Retail = false;
            this.InvoiceItem2.Size = new System.Drawing.Size(736, 42);
            this.InvoiceItem2.TabIndex = 1;
            this.InvoiceItem2.ItemAdded += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAdded);
            this.InvoiceItem2.ItemAltered += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAltered);
            this.InvoiceItem2.ItemDeleted += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemDeleted);
            // 
            // InvoiceItem1
            // 
            this.InvoiceItem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceItem1.Location = new System.Drawing.Point(10, 0);
            this.InvoiceItem1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.InvoiceItem1.Name = "InvoiceItem1";
            this.InvoiceItem1.Retail = false;
            this.InvoiceItem1.Size = new System.Drawing.Size(736, 42);
            this.InvoiceItem1.TabIndex = 0;
            this.InvoiceItem1.ItemAdded += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAdded);
            this.InvoiceItem1.ItemAltered += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemAltered);
            this.InvoiceItem1.ItemDeleted += new OsmingtonMillGarlic.InvoiceItemUserControl.InvoiceItemHandler(this.InvoiceItem_ItemDeleted);
            // 
            // AddEditInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 607);
            this.Controls.Add(this.InvoiceTableLayoutPanel);
            this.Name = "AddEditInvoiceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Invoice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEditInvoiceForm_FormClosing);
            this.Load += new System.EventHandler(this.AddEditInvoiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesDataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceItemsDataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceTypesDataTable)).EndInit();
            this.InvoiceTableLayoutPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.InvoiceItemsTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Controls.NullableDatePicker InvoiceDateNullableDatePicker;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox InvoiceNumberTextBox;
		private System.Windows.Forms.TextBox ToTextBox;
		private System.Windows.Forms.TextBox ReferenceTextBox;
		private System.Windows.Forms.Label label4;
		private System.Data.DataSet InvoicesDataSet;
		private System.Data.DataTable InvoicesDataTable;
		private System.Data.DataColumn dataColumn5;
		private System.Data.DataColumn dataColumn6;
		private System.Data.DataColumn dataColumn7;
		private System.Data.DataColumn dataColumn8;
		private System.Data.DataColumn dataColumn9;
		private System.Data.DataColumn dataColumn20;
		private System.Data.DataColumn dataColumn21;
		private System.Data.DataColumn dataColumn22;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataTable InvoiceItemsDataTable;
		private System.Data.DataColumn dataColumn10;
		private System.Data.DataColumn dataColumn11;
		private System.Data.DataColumn dataColumn12;
		private System.Data.DataColumn dataColumn13;
		private System.Data.DataColumn dataColumn16;
		private System.Windows.Forms.BindingSource InvoicesBindingSource;
		private System.Windows.Forms.TableLayoutPanel InvoiceTableLayoutPanel;
		private System.Windows.Forms.Panel TopPanel;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Panel BottomPanel;
		private System.Windows.Forms.ComboBox InvoiceTypeComboBox;
		private System.Windows.Forms.Label label6;
		private System.Data.DataColumn dataColumn2;
		private System.Windows.Forms.TableLayoutPanel InvoiceItemsTableLayoutPanel;
		private InvoiceItemUserControl InvoiceItem8;
		private InvoiceItemUserControl InvoiceItem7;
		private InvoiceItemUserControl InvoiceItem6;
		private InvoiceItemUserControl InvoiceItem5;
		private InvoiceItemUserControl InvoiceItem4;
		private InvoiceItemUserControl InvoiceItem3;
		private InvoiceItemUserControl InvoiceItem2;
		private InvoiceItemUserControl InvoiceItem1;
		private System.Data.DataColumn dataColumn14;
		private System.Data.DataColumn dataColumn15;
		private System.Data.DataColumn dataColumn17;
		private System.Data.DataColumn dataColumn18;
		private System.Data.DataTable InvoiceTypesDataTable;
		private System.Data.DataColumn dataColumn3;
		private System.Data.DataColumn dataColumn4;
		private System.Windows.Forms.Button CalculateGstButton;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private Controls.NumericTextBox GstNumericTextBox;
		private Controls.NumericTextBox SubTotalNumericTextBox;
		private Controls.NumericTextBox InvoiceTotalNumericTextBox;
		private Controls.NumericTextBox numericTextBox1;
		private System.Data.DataColumn dataColumn19;
		private System.Windows.Forms.Button CreateFileButton;
		private System.Windows.Forms.Button LockInvoiceButton;
		private System.Windows.Forms.CheckBox RetailCheckBox;
		private System.Data.DataColumn dataColumn23;
	}
}