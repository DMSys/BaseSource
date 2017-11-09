namespace DBStudio.Generate
{
    partial class UCListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCListView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_RowEdit = new System.Windows.Forms.ToolStripButton();
            this.dgv_DataList = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_RowEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(768, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_RowEdit
            // 
            this.tsb_RowEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_RowEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsb_RowEdit.Image")));
            this.tsb_RowEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_RowEdit.Name = "tsb_RowEdit";
            this.tsb_RowEdit.Size = new System.Drawing.Size(23, 22);
            this.tsb_RowEdit.Text = "toolStripButton1";
            this.tsb_RowEdit.Click += new System.EventHandler(this.tsb_RowEdit_Click);
            // 
            // dgv_DataList
            // 
            this.dgv_DataList.AllowUserToAddRows = false;
            this.dgv_DataList.AllowUserToDeleteRows = false;
            this.dgv_DataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DataList.Location = new System.Drawing.Point(0, 25);
            this.dgv_DataList.Name = "dgv_DataList";
            this.dgv_DataList.ReadOnly = true;
            this.dgv_DataList.Size = new System.Drawing.Size(768, 305);
            this.dgv_DataList.TabIndex = 2;
            // 
            // UCListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_DataList);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UCListView";
            this.Size = new System.Drawing.Size(768, 330);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_RowEdit;
        private System.Windows.Forms.DataGridView dgv_DataList;

    }
}
