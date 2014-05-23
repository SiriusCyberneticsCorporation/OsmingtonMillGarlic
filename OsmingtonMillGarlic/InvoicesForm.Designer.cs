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
			this.InvoicesDataSet = new System.Data.DataSet();
			((System.ComponentModel.ISupportInitialize)(this.InvoicesDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// InvoicesDataSet
			// 
			this.InvoicesDataSet.DataSetName = "NewDataSet";
			// 
			// InvoicesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 402);
			this.Name = "InvoicesForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Invoices";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InvoicesForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.InvoicesDataSet)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Data.DataSet InvoicesDataSet;
	}
}