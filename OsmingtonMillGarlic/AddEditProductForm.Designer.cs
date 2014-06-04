namespace OsmingtonMillGarlic
{
	partial class AddEditProductForm
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
			this.ProductsComboBox = new System.Windows.Forms.ComboBox();
			this.SelectProductDataSet = new System.Data.DataSet();
			this.ProductsDataTable = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.OkButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.TheCancelButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.SelectProductDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ProductsDataTable)).BeginInit();
			this.SuspendLayout();
			// 
			// ProductsComboBox
			// 
			this.ProductsComboBox.DataSource = this.SelectProductDataSet;
			this.ProductsComboBox.DisplayMember = "Products.Description";
			this.ProductsComboBox.FormattingEnabled = true;
			this.ProductsComboBox.Location = new System.Drawing.Point(95, 12);
			this.ProductsComboBox.Name = "ProductsComboBox";
			this.ProductsComboBox.Size = new System.Drawing.Size(224, 21);
			this.ProductsComboBox.TabIndex = 0;
			this.ProductsComboBox.ValueMember = "Products.ID";
			// 
			// SelectProductDataSet
			// 
			this.SelectProductDataSet.DataSetName = "NewDataSet";
			this.SelectProductDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.ProductsDataTable});
			// 
			// ProductsDataTable
			// 
			this.ProductsDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
			this.ProductsDataTable.TableName = "Products";
			// 
			// dataColumn1
			// 
			this.dataColumn1.ColumnName = "ID";
			this.dataColumn1.DataType = typeof(int);
			// 
			// dataColumn2
			// 
			this.dataColumn2.ColumnName = "Description";
			// 
			// OkButton
			// 
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(50, 44);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 1;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Select Product";
			// 
			// TheCancelButton
			// 
			this.TheCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TheCancelButton.Location = new System.Drawing.Point(205, 44);
			this.TheCancelButton.Name = "TheCancelButton";
			this.TheCancelButton.Size = new System.Drawing.Size(75, 23);
			this.TheCancelButton.TabIndex = 3;
			this.TheCancelButton.Text = "Cancel";
			this.TheCancelButton.UseVisualStyleBackColor = true;
			// 
			// AddEditProductForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(331, 80);
			this.ControlBox = false;
			this.Controls.Add(this.TheCancelButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.ProductsComboBox);
			this.Name = "AddEditProductForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Product";
			this.Load += new System.EventHandler(this.AddEditProductForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.SelectProductDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ProductsDataTable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox ProductsComboBox;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button TheCancelButton;
		private System.Data.DataSet SelectProductDataSet;
		private System.Data.DataTable ProductsDataTable;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
	}
}