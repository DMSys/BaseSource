namespace Hydra.Win.QuickMenu
{
    partial class UCQuickMenuItem
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
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppAuthor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAppName
            // 
            this.lblAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAppName.Location = new System.Drawing.Point(0, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(322, 21);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "___";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAppName.Click += new System.EventHandler(this.lblAppName_Click);
            this.lblAppName.MouseEnter += new System.EventHandler(this.lblAppName_MouseEnter);
            this.lblAppName.MouseLeave += new System.EventHandler(this.lblAppName_MouseLeave);
            // 
            // lblAppAuthor
            // 
            this.lblAppAuthor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAppAuthor.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAppAuthor.Location = new System.Drawing.Point(0, 21);
            this.lblAppAuthor.Name = "lblAppAuthor";
            this.lblAppAuthor.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblAppAuthor.Size = new System.Drawing.Size(322, 16);
            this.lblAppAuthor.TabIndex = 1;
            this.lblAppAuthor.Text = "___";
            this.lblAppAuthor.Click += new System.EventHandler(this.lblAppAuthor_Click);
            this.lblAppAuthor.MouseEnter += new System.EventHandler(this.lblAppAuthor_MouseEnter);
            this.lblAppAuthor.MouseLeave += new System.EventHandler(this.lblAppAuthor_MouseLeave);
            // 
            // UCQuickMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.lblAppAuthor);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UCQuickMenuItem";
            this.Size = new System.Drawing.Size(322, 37);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppAuthor;
    }
}
