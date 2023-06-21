namespace Mini_Case_Study
{
    partial class AdminMaster
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addRestaurantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRestaurantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRestaurantToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRestaurantToolStripMenuItem,
            this.deleteRestaurantToolStripMenuItem,
            this.deleteRestaurantToolStripMenuItem1,
            this.logOutToolStripMenuItem,
            this.displayToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addRestaurantToolStripMenuItem
            // 
            this.addRestaurantToolStripMenuItem.Name = "addRestaurantToolStripMenuItem";
            this.addRestaurantToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.addRestaurantToolStripMenuItem.Text = "Add Restaurant";
            this.addRestaurantToolStripMenuItem.Click += new System.EventHandler(this.addRestaurantToolStripMenuItem_Click);
            // 
            // deleteRestaurantToolStripMenuItem
            // 
            this.deleteRestaurantToolStripMenuItem.Name = "deleteRestaurantToolStripMenuItem";
            this.deleteRestaurantToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.deleteRestaurantToolStripMenuItem.Text = "Update Restaurant";
            this.deleteRestaurantToolStripMenuItem.Click += new System.EventHandler(this.deleteRestaurantToolStripMenuItem_Click);
            // 
            // deleteRestaurantToolStripMenuItem1
            // 
            this.deleteRestaurantToolStripMenuItem1.Name = "deleteRestaurantToolStripMenuItem1";
            this.deleteRestaurantToolStripMenuItem1.Size = new System.Drawing.Size(73, 20);
            this.deleteRestaurantToolStripMenuItem1.Text = "Edit Menu";
            this.deleteRestaurantToolStripMenuItem1.Click += new System.EventHandler(this.deleteRestaurantToolStripMenuItem1_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.displayToolStripMenuItem.Text = "Display";
            this.displayToolStripMenuItem.Click += new System.EventHandler(this.displayToolStripMenuItem_Click);
            // 
            // AdminMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mini_Case_Study.Properties.Resources.Admin_Master;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminMaster";
            this.Text = "AdminMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addRestaurantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRestaurantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRestaurantToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
    }
}