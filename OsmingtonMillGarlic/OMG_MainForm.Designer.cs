namespace OsmingtonMillGarlic
{
	partial class OMG_MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OMG_MainForm));
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ListAllProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.marketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ListAllMarketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newMarketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.invoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ListAllInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ProductsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.MarketsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.NewMarketToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.InvoicesToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.MainMenu.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.marketsToolStripMenuItem,
            this.invoicesToolStripMenuItem,
            this.windowToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.MdiWindowListItem = this.windowToolStripMenuItem;
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(954, 24);
			this.MainMenu.TabIndex = 1;
			this.MainMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// productsToolStripMenuItem
			// 
			this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListAllProductsToolStripMenuItem});
			this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
			this.productsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.productsToolStripMenuItem.Text = "Products";
			// 
			// ListAllProductsToolStripMenuItem
			// 
			this.ListAllProductsToolStripMenuItem.Name = "ListAllProductsToolStripMenuItem";
			this.ListAllProductsToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.ListAllProductsToolStripMenuItem.Text = "List All";
			this.ListAllProductsToolStripMenuItem.Click += new System.EventHandler(this.ListAllProductsToolStripMenuItem_Click);
			// 
			// marketsToolStripMenuItem
			// 
			this.marketsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListAllMarketsToolStripMenuItem,
            this.newMarketToolStripMenuItem});
			this.marketsToolStripMenuItem.Name = "marketsToolStripMenuItem";
			this.marketsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.marketsToolStripMenuItem.Text = "Markets";
			// 
			// ListAllMarketsToolStripMenuItem
			// 
			this.ListAllMarketsToolStripMenuItem.Name = "ListAllMarketsToolStripMenuItem";
			this.ListAllMarketsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.ListAllMarketsToolStripMenuItem.Text = "List All";
			this.ListAllMarketsToolStripMenuItem.Click += new System.EventHandler(this.ListAllMarketsToolStripMenuItem_Click);
			// 
			// newMarketToolStripMenuItem
			// 
			this.newMarketToolStripMenuItem.Name = "newMarketToolStripMenuItem";
			this.newMarketToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.newMarketToolStripMenuItem.Text = "New Market";
			this.newMarketToolStripMenuItem.Click += new System.EventHandler(this.newMarketToolStripMenuItem_Click);
			// 
			// invoicesToolStripMenuItem
			// 
			this.invoicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListAllInvoicesToolStripMenuItem});
			this.invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
			this.invoicesToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
			this.invoicesToolStripMenuItem.Text = "Invoices";
			// 
			// ListAllInvoicesToolStripMenuItem
			// 
			this.ListAllInvoicesToolStripMenuItem.Name = "ListAllInvoicesToolStripMenuItem";
			this.ListAllInvoicesToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.ListAllInvoicesToolStripMenuItem.Text = "List All";
			this.ListAllInvoicesToolStripMenuItem.Click += new System.EventHandler(this.ListAllInvoicesToolStripMenuItem_Click);
			// 
			// windowToolStripMenuItem
			// 
			this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileHorizontallyToolStripMenuItem,
            this.tileVerticallyToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.toolStripMenuItem1});
			this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
			this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.windowToolStripMenuItem.Text = "Window";
			// 
			// cascadeToolStripMenuItem
			// 
			this.cascadeToolStripMenuItem.Image = global::OsmingtonMillGarlic.Properties.Resources.CascadeWindowsHS;
			this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
			this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.cascadeToolStripMenuItem.Text = "&Cascade";
			this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
			// 
			// tileHorizontallyToolStripMenuItem
			// 
			this.tileHorizontallyToolStripMenuItem.Image = global::OsmingtonMillGarlic.Properties.Resources.TileWindowsHorizontallyHS;
			this.tileHorizontallyToolStripMenuItem.Name = "tileHorizontallyToolStripMenuItem";
			this.tileHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.tileHorizontallyToolStripMenuItem.Text = "Tile &Horizontally";
			this.tileHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontallyToolStripMenuItem_Click);
			// 
			// tileVerticallyToolStripMenuItem
			// 
			this.tileVerticallyToolStripMenuItem.Image = global::OsmingtonMillGarlic.Properties.Resources.TileWindowsVerticallyHS;
			this.tileVerticallyToolStripMenuItem.Name = "tileVerticallyToolStripMenuItem";
			this.tileVerticallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.tileVerticallyToolStripMenuItem.Text = "Tile &Vertically";
			this.tileVerticallyToolStripMenuItem.Click += new System.EventHandler(this.tileVerticallyToolStripMenuItem_Click);
			// 
			// closeAllToolStripMenuItem
			// 
			this.closeAllToolStripMenuItem.Image = global::OsmingtonMillGarlic.Properties.Resources.CloseAllWindowsHS;
			this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
			this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.closeAllToolStripMenuItem.Text = "Close &All";
			this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProductsToolStripButton,
            this.MarketsToolStripButton,
            this.NewMarketToolStripButton,
            this.InvoicesToolStripButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(954, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// ProductsToolStripButton
			// 
			this.ProductsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ProductsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ProductsToolStripButton.Image")));
			this.ProductsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ProductsToolStripButton.Name = "ProductsToolStripButton";
			this.ProductsToolStripButton.Size = new System.Drawing.Size(58, 22);
			this.ProductsToolStripButton.Text = "Products";
			this.ProductsToolStripButton.Click += new System.EventHandler(this.ProductsToolStripButton_Click);
			// 
			// MarketsToolStripButton
			// 
			this.MarketsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MarketsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("MarketsToolStripButton.Image")));
			this.MarketsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MarketsToolStripButton.Name = "MarketsToolStripButton";
			this.MarketsToolStripButton.Size = new System.Drawing.Size(53, 22);
			this.MarketsToolStripButton.Text = "Markets";
			this.MarketsToolStripButton.Click += new System.EventHandler(this.MarketsToolStripButton_Click);
			// 
			// NewMarketToolStripButton
			// 
			this.NewMarketToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.NewMarketToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NewMarketToolStripButton.Image")));
			this.NewMarketToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.NewMarketToolStripButton.Name = "NewMarketToolStripButton";
			this.NewMarketToolStripButton.Size = new System.Drawing.Size(75, 22);
			this.NewMarketToolStripButton.Text = "New Market";
			this.NewMarketToolStripButton.Click += new System.EventHandler(this.NewMarketToolStripButton_Click);
			// 
			// InvoicesToolStripButton
			// 
			this.InvoicesToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.InvoicesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.InvoicesToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("InvoicesToolStripButton.Image")));
			this.InvoicesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.InvoicesToolStripButton.Name = "InvoicesToolStripButton";
			this.InvoicesToolStripButton.Size = new System.Drawing.Size(54, 22);
			this.InvoicesToolStripButton.Text = "Invoices";
			this.InvoicesToolStripButton.Click += new System.EventHandler(this.InvoicesToolStripButton_Click);
			// 
			// OMG_MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(954, 680);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.MainMenu);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.MainMenu;
			this.Name = "OMG_MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Osmington Mill Garlic";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OMG_MainForm_FormClosing);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ListAllProductsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem marketsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ListAllMarketsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem invoicesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ListAllInvoicesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tileHorizontallyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tileVerticallyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton ProductsToolStripButton;
		private System.Windows.Forms.ToolStripButton MarketsToolStripButton;
		private System.Windows.Forms.ToolStripButton NewMarketToolStripButton;
		private System.Windows.Forms.ToolStripButton InvoicesToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem newMarketToolStripMenuItem;
	}
}

