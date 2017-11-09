namespace FileSynchronizer
{
    partial class FTarget_NewEdit
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
            this.btn_Close = new System.Windows.Forms.Button();
            this.tb_Source = new System.Windows.Forms.TextBox();
            this.tb_Destination = new System.Windows.Forms.TextBox();
            this.lbl_Source = new System.Windows.Forms.Label();
            this.lbl_Destination = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_BrowserSource = new System.Windows.Forms.Button();
            this.btn_BrowserDestination = new System.Windows.Forms.Button();
            this.fBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(435, 90);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 9;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tb_Source
            // 
            this.tb_Source.Location = new System.Drawing.Point(81, 38);
            this.tb_Source.Name = "tb_Source";
            this.tb_Source.Size = new System.Drawing.Size(429, 20);
            this.tb_Source.TabIndex = 3;
            // 
            // tb_Destination
            // 
            this.tb_Destination.Location = new System.Drawing.Point(81, 64);
            this.tb_Destination.Name = "tb_Destination";
            this.tb_Destination.Size = new System.Drawing.Size(429, 20);
            this.tb_Destination.TabIndex = 6;
            // 
            // lbl_Source
            // 
            this.lbl_Source.AutoSize = true;
            this.lbl_Source.Location = new System.Drawing.Point(12, 41);
            this.lbl_Source.Name = "lbl_Source";
            this.lbl_Source.Size = new System.Drawing.Size(44, 13);
            this.lbl_Source.TabIndex = 2;
            this.lbl_Source.Text = "Source:";
            // 
            // lbl_Destination
            // 
            this.lbl_Destination.AutoSize = true;
            this.lbl_Destination.Location = new System.Drawing.Point(12, 67);
            this.lbl_Destination.Name = "lbl_Destination";
            this.lbl_Destination.Size = new System.Drawing.Size(63, 13);
            this.lbl_Destination.TabIndex = 5;
            this.lbl_Destination.Text = "Destination:";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(354, 90);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_BrowserSource
            // 
            this.btn_BrowserSource.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_BrowserSource.Location = new System.Drawing.Point(521, 36);
            this.btn_BrowserSource.Name = "btn_BrowserSource";
            this.btn_BrowserSource.Size = new System.Drawing.Size(24, 23);
            this.btn_BrowserSource.TabIndex = 4;
            this.btn_BrowserSource.Text = "...";
            this.btn_BrowserSource.UseVisualStyleBackColor = true;
            this.btn_BrowserSource.Click += new System.EventHandler(this.btn_BrowserSource_Click);
            // 
            // btn_BrowserDestination
            // 
            this.btn_BrowserDestination.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_BrowserDestination.Location = new System.Drawing.Point(521, 62);
            this.btn_BrowserDestination.Name = "btn_BrowserDestination";
            this.btn_BrowserDestination.Size = new System.Drawing.Size(24, 23);
            this.btn_BrowserDestination.TabIndex = 7;
            this.btn_BrowserDestination.Text = "...";
            this.btn_BrowserDestination.UseVisualStyleBackColor = true;
            this.btn_BrowserDestination.Click += new System.EventHandler(this.btn_BrowserDestination_Click);
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(12, 15);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(38, 13);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name:";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(81, 12);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(429, 20);
            this.tb_Name.TabIndex = 1;
            // 
            // FTarget_NewEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 124);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.btn_BrowserDestination);
            this.Controls.Add(this.btn_BrowserSource);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lbl_Destination);
            this.Controls.Add(this.lbl_Source);
            this.Controls.Add(this.tb_Destination);
            this.Controls.Add(this.tb_Source);
            this.Controls.Add(this.btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTarget_NewEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Target";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TextBox tb_Source;
        private System.Windows.Forms.TextBox tb_Destination;
        private System.Windows.Forms.Label lbl_Source;
        private System.Windows.Forms.Label lbl_Destination;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_BrowserSource;
        private System.Windows.Forms.Button btn_BrowserDestination;
        private System.Windows.Forms.FolderBrowserDialog fBrowserDlg;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox tb_Name;
    }
}