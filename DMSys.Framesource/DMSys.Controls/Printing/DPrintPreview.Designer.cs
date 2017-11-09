namespace DMSys.Controls.Printing
{
    partial class DPrintPreview
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_QuickPrint = new System.Windows.Forms.ToolStripButton();
            this.tsb_Print = new System.Windows.Forms.ToolStripButton();
            this.tsb_PageSetup = new System.Windows.Forms.ToolStripButton();
            this.tscb_Zoom = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.pPreviewControl = new System.Windows.Forms.PrintPreviewControl();
            this.pDocument = new System.Drawing.Printing.PrintDocument();
            this.nud_Page = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Page)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_QuickPrint,
            this.tsb_Print,
            this.tsb_PageSetup,
            this.tscb_Zoom,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(605, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_QuickPrint
            // 
            this.tsb_QuickPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_QuickPrint.Image = global::DMSys.Controls.Properties.Resources.misc_printer_default_32;
            this.tsb_QuickPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_QuickPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_QuickPrint.Name = "tsb_QuickPrint";
            this.tsb_QuickPrint.Size = new System.Drawing.Size(36, 36);
            this.tsb_QuickPrint.Text = "Quick Print";
            this.tsb_QuickPrint.Click += new System.EventHandler(this.tsb_QuickPrint_Click);
            // 
            // tsb_Print
            // 
            this.tsb_Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Print.Image = global::DMSys.Controls.Properties.Resources.hardware_printer_on_32;
            this.tsb_Print.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Print.Name = "tsb_Print";
            this.tsb_Print.Size = new System.Drawing.Size(36, 36);
            this.tsb_Print.Text = "Print";
            this.tsb_Print.Click += new System.EventHandler(this.tsb_Print_Click);
            // 
            // tsb_PageSetup
            // 
            this.tsb_PageSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_PageSetup.Image = global::DMSys.Controls.Properties.Resources.page_process_icon_32;
            this.tsb_PageSetup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_PageSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_PageSetup.Name = "tsb_PageSetup";
            this.tsb_PageSetup.Size = new System.Drawing.Size(36, 36);
            this.tsb_PageSetup.Text = "Page Setup";
            this.tsb_PageSetup.Visible = false;
            this.tsb_PageSetup.Click += new System.EventHandler(this.tsb_PageSetup_Click);
            // 
            // tscb_Zoom
            // 
            this.tscb_Zoom.Items.AddRange(new object[] {
            "Auto Zoom",
            "20%",
            "25%",
            "50%",
            "75%",
            "100%",
            "150%",
            "200%"});
            this.tscb_Zoom.Name = "tscb_Zoom";
            this.tscb_Zoom.Size = new System.Drawing.Size(121, 39);
            this.tscb_Zoom.SelectedIndexChanged += new System.EventHandler(this.tscb_Zoom_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 36);
            this.toolStripLabel1.Text = "Страница";
            // 
            // pPreviewControl
            // 
            this.pPreviewControl.AutoZoom = false;
            this.pPreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPreviewControl.Location = new System.Drawing.Point(0, 39);
            this.pPreviewControl.Name = "pPreviewControl";
            this.pPreviewControl.Size = new System.Drawing.Size(605, 340);
            this.pPreviewControl.TabIndex = 1;
            this.pPreviewControl.Zoom = 0.29769033361847735D;
            // 
            // pDocument
            // 
            this.pDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pDocument_PrintPage);
            // 
            // nud_Page
            // 
            this.nud_Page.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nud_Page.Location = new System.Drawing.Point(269, 7);
            this.nud_Page.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Page.Name = "nud_Page";
            this.nud_Page.Size = new System.Drawing.Size(54, 22);
            this.nud_Page.TabIndex = 2;
            this.nud_Page.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Page.ValueChanged += new System.EventHandler(this.nud_Page_ValueChanged);
            // 
            // DPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nud_Page);
            this.Controls.Add(this.pPreviewControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DPrintPreview";
            this.Size = new System.Drawing.Size(605, 379);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Page)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PrintPreviewControl pPreviewControl;
        private System.Drawing.Printing.PrintDocument pDocument;
        private System.Windows.Forms.ToolStripComboBox tscb_Zoom;
        private System.Windows.Forms.ToolStripButton tsb_QuickPrint;
        private System.Windows.Forms.ToolStripButton tsb_Print;
        private System.Windows.Forms.ToolStripButton tsb_PageSetup;
        private System.Windows.Forms.NumericUpDown nud_Page;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}
