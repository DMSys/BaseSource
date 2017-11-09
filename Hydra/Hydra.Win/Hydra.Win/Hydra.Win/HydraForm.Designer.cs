namespace Hydra.Win
{
    partial class FHydraForm
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbMenu = new System.Windows.Forms.ToolStripButton();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.pnlWorkplace = new System.Windows.Forms.Panel();
            this.splitterToolBar = new System.Windows.Forms.Splitter();
            this.pnlToolBar = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.pnlWorkplace.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowser.Location = new System.Drawing.Point(175, 0);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(659, 393);
            this.pnlBrowser.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMenu,
            this.tsbOptions});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(834, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbMenu
            // 
            this.tsbMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMenu.Image = global::Hydra.Win.Properties.Resources.show_menu_32_icon;
            this.tsbMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMenu.Name = "tsbMenu";
            this.tsbMenu.Size = new System.Drawing.Size(36, 36);
            this.tsbMenu.Text = "Menu";
            this.tsbMenu.Click += new System.EventHandler(this.tsbMenu_Click);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOptions.Image = global::Hydra.Win.Properties.Resources.options_32_icon;
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(36, 36);
            this.tsbOptions.Text = "Options";
            this.tsbOptions.Click += new System.EventHandler(this.tsbOptions_Click);
            // 
            // pnlWorkplace
            // 
            this.pnlWorkplace.Controls.Add(this.pnlBrowser);
            this.pnlWorkplace.Controls.Add(this.splitterToolBar);
            this.pnlWorkplace.Controls.Add(this.pnlToolBar);
            this.pnlWorkplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkplace.Location = new System.Drawing.Point(0, 39);
            this.pnlWorkplace.Name = "pnlWorkplace";
            this.pnlWorkplace.Size = new System.Drawing.Size(834, 393);
            this.pnlWorkplace.TabIndex = 4;
            // 
            // splitterToolBar
            // 
            this.splitterToolBar.Location = new System.Drawing.Point(172, 0);
            this.splitterToolBar.Name = "splitterToolBar";
            this.splitterToolBar.Size = new System.Drawing.Size(3, 393);
            this.splitterToolBar.TabIndex = 4;
            this.splitterToolBar.TabStop = false;
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(172, 393);
            this.pnlToolBar.TabIndex = 3;
            // 
            // FHydraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 432);
            this.Controls.Add(this.pnlWorkplace);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FHydraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hydra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FHydraForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlWorkplace.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbMenu;
        private System.Windows.Forms.Panel pnlWorkplace;
        private System.Windows.Forms.Splitter splitterToolBar;
        private System.Windows.Forms.Panel pnlToolBar;
        private System.Windows.Forms.ToolStripButton tsbOptions;
    }
}

