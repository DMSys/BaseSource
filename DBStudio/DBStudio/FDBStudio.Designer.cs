namespace DBStudio
{
    partial class FDBStudio
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_NewTable = new System.Windows.Forms.ToolStripButton();
            this.sc_Bowler = new System.Windows.Forms.SplitContainer();
            this.tv_Tables = new System.Windows.Forms.TreeView();
            this.tc_DBStudio = new DMSys.Controls.DTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cm_Tables = new System.Windows.Forms.ContextMenu();
            this.mi_TableDesign = new System.Windows.Forms.MenuItem();
            this.mi_TableDelete = new System.Windows.Forms.MenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_Bowler)).BeginInit();
            this.sc_Bowler.Panel1.SuspendLayout();
            this.sc_Bowler.Panel2.SuspendLayout();
            this.sc_Bowler.SuspendLayout();
            this.tc_DBStudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_NewTable});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(978, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_NewTable
            // 
            this.tsb_NewTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_NewTable.Image = global::DBStudio.Properties.Resources._3803_11427_add_table;
            this.tsb_NewTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_NewTable.Name = "tsb_NewTable";
            this.tsb_NewTable.Size = new System.Drawing.Size(23, 22);
            this.tsb_NewTable.Text = "New Table";
            this.tsb_NewTable.Click += new System.EventHandler(this.tsb_NewTable_Click);
            // 
            // sc_Bowler
            // 
            this.sc_Bowler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_Bowler.Location = new System.Drawing.Point(0, 25);
            this.sc_Bowler.Name = "sc_Bowler";
            // 
            // sc_Bowler.Panel1
            // 
            this.sc_Bowler.Panel1.Controls.Add(this.tv_Tables);
            // 
            // sc_Bowler.Panel2
            // 
            this.sc_Bowler.Panel2.Controls.Add(this.tc_DBStudio);
            this.sc_Bowler.Size = new System.Drawing.Size(978, 395);
            this.sc_Bowler.SplitterDistance = 258;
            this.sc_Bowler.TabIndex = 2;
            // 
            // tv_Tables
            // 
            this.tv_Tables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tv_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Tables.Location = new System.Drawing.Point(0, 0);
            this.tv_Tables.Name = "tv_Tables";
            this.tv_Tables.Size = new System.Drawing.Size(258, 395);
            this.tv_Tables.TabIndex = 1;
            this.tv_Tables.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_Tables_NodeMouseDoubleClick);
            // 
            // tc_DBStudio
            // 
            this.tc_DBStudio.Controls.Add(this.tabPage1);
            this.tc_DBStudio.Controls.Add(this.tabPage2);
            this.tc_DBStudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_DBStudio.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tc_DBStudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc_DBStudio.ItemMenu = null;
            this.tc_DBStudio.ItemSize = new System.Drawing.Size(180, 24);
            this.tc_DBStudio.Location = new System.Drawing.Point(0, 0);
            this.tc_DBStudio.Name = "tc_DBStudio";
            this.tc_DBStudio.SelectedIndex = 0;
            this.tc_DBStudio.Size = new System.Drawing.Size(716, 395);
            this.tc_DBStudio.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tc_DBStudio.TabIndex = 0;
            this.tc_DBStudio.TabStop = false;
            this.tc_DBStudio.TabClosed += new DMSys.Controls.DTabControl.OnHeaderCloseDelegate(this.tc_DBStudio_TabClosed);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(708, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(708, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(978, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cm_Tables
            // 
            this.cm_Tables.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mi_TableDesign,
            this.mi_TableDelete});
            // 
            // mi_TableDesign
            // 
            this.mi_TableDesign.Index = 0;
            this.mi_TableDesign.Text = "Design";
            this.mi_TableDesign.Click += new System.EventHandler(this.mi_TableDesign_Click);
            // 
            // mi_TableDelete
            // 
            this.mi_TableDelete.Index = 1;
            this.mi_TableDelete.Text = "Delete";
            this.mi_TableDelete.Click += new System.EventHandler(this.mi_TableDelete_Click);
            // 
            // FDBStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 442);
            this.Controls.Add(this.sc_Bowler);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FDBStudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBStudio";
            this.Load += new System.EventHandler(this.FBowler_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.sc_Bowler.Panel1.ResumeLayout(false);
            this.sc_Bowler.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_Bowler)).EndInit();
            this.sc_Bowler.ResumeLayout(false);
            this.tc_DBStudio.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer sc_Bowler;
        private System.Windows.Forms.TreeView tv_Tables;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton tsb_NewTable;
        private DMSys.Controls.DTabControl tc_DBStudio;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenu cm_Tables;
        private System.Windows.Forms.MenuItem mi_TableDesign;
        private System.Windows.Forms.MenuItem mi_TableDelete;
    }
}

