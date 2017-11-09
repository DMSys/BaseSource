namespace DMSys.Controls.Demo
{
    partial class FPrintTable
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
            this.docPreview = new DMSys.Controls.Printing.DPrintPreview();
            this.SuspendLayout();
            // 
            // docPreview
            // 
            this.docPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docPreview.DocumentName = "document";
            this.docPreview.Location = new System.Drawing.Point(0, 0);
            this.docPreview.Name = "docPreview";
            this.docPreview.Size = new System.Drawing.Size(758, 385);
            this.docPreview.TabIndex = 0;
            // 
            // FPrintTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 385);
            this.Controls.Add(this.docPreview);
            this.Name = "FPrintTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FPrintTable";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Printing.DPrintPreview docPreview;
    }
}