namespace DMSys.Controls.Demo
{
    partial class FDemo
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
            this.btn_PrintTable = new System.Windows.Forms.Button();
            this.btn_DataGridView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_PrintTable
            // 
            this.btn_PrintTable.Location = new System.Drawing.Point(12, 12);
            this.btn_PrintTable.Name = "btn_PrintTable";
            this.btn_PrintTable.Size = new System.Drawing.Size(100, 23);
            this.btn_PrintTable.TabIndex = 0;
            this.btn_PrintTable.Text = "Print Table";
            this.btn_PrintTable.UseVisualStyleBackColor = true;
            this.btn_PrintTable.Click += new System.EventHandler(this.btn_PrintTable_Click);
            // 
            // btn_DataGridView
            // 
            this.btn_DataGridView.Location = new System.Drawing.Point(12, 41);
            this.btn_DataGridView.Name = "btn_DataGridView";
            this.btn_DataGridView.Size = new System.Drawing.Size(100, 23);
            this.btn_DataGridView.TabIndex = 1;
            this.btn_DataGridView.Text = "DataGridView";
            this.btn_DataGridView.UseVisualStyleBackColor = true;
            this.btn_DataGridView.Click += new System.EventHandler(this.btn_DataGridView_Click);
            // 
            // FDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 341);
            this.Controls.Add(this.btn_DataGridView);
            this.Controls.Add(this.btn_PrintTable);
            this.Name = "FDemo";
            this.Text = "Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_PrintTable;
        private System.Windows.Forms.Button btn_DataGridView;
    }
}

