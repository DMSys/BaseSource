namespace FileSynchronizer
{
    partial class FTargetSynchList
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
            this.dgv_SynchList = new System.Windows.Forms.DataGridView();
            this.gc_SIActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gc_SIValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_SIType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_SIStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bs_SynchList = new System.Windows.Forms.BindingSource(this.components);
            this.dSet = new System.Data.DataSet();
            this.dt_SynchList = new System.Data.DataTable();
            this.dc_SIValue = new System.Data.DataColumn();
            this.dc_SIType = new System.Data.DataColumn();
            this.dc_SIActive = new System.Data.DataColumn();
            this.dc_SIStatus = new System.Data.DataColumn();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_From = new System.Windows.Forms.Label();
            this.lbl_FromDirName = new System.Windows.Forms.Label();
            this.lbl_To = new System.Windows.Forms.Label();
            this.lbl_ToDirName = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_SItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dc_SItem = new System.Data.DataColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_CheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_UncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SynchList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_SynchList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_SynchList)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_SynchList
            // 
            this.dgv_SynchList.AllowUserToAddRows = false;
            this.dgv_SynchList.AllowUserToDeleteRows = false;
            this.dgv_SynchList.AutoGenerateColumns = false;
            this.dgv_SynchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SynchList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gc_SIActive,
            this.gc_SIValue,
            this.gc_SIType,
            this.gc_SIStatus,
            this.gc_SItem});
            this.dgv_SynchList.DataSource = this.bs_SynchList;
            this.dgv_SynchList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SynchList.Location = new System.Drawing.Point(0, 24);
            this.dgv_SynchList.Name = "dgv_SynchList";
            this.dgv_SynchList.RowHeadersWidth = 20;
            this.dgv_SynchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SynchList.Size = new System.Drawing.Size(647, 266);
            this.dgv_SynchList.TabIndex = 1;
            this.dgv_SynchList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SynchList_CellValueChanged);
            // 
            // gc_SIActive
            // 
            this.gc_SIActive.DataPropertyName = "SIActive";
            this.gc_SIActive.HeaderText = "";
            this.gc_SIActive.Name = "gc_SIActive";
            this.gc_SIActive.Width = 30;
            // 
            // gc_SIValue
            // 
            this.gc_SIValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gc_SIValue.DataPropertyName = "SIValue";
            this.gc_SIValue.HeaderText = "Value";
            this.gc_SIValue.Name = "gc_SIValue";
            this.gc_SIValue.ReadOnly = true;
            // 
            // gc_SIType
            // 
            this.gc_SIType.DataPropertyName = "SIType";
            this.gc_SIType.HeaderText = "Type";
            this.gc_SIType.Name = "gc_SIType";
            this.gc_SIType.ReadOnly = true;
            // 
            // gc_SIStatus
            // 
            this.gc_SIStatus.DataPropertyName = "SIStatus";
            this.gc_SIStatus.HeaderText = "Status";
            this.gc_SIStatus.Name = "gc_SIStatus";
            this.gc_SIStatus.ReadOnly = true;
            // 
            // bs_SynchList
            // 
            this.bs_SynchList.DataMember = "SynchList";
            this.bs_SynchList.DataSource = this.dSet;
            // 
            // dSet
            // 
            this.dSet.DataSetName = "NewDataSet";
            this.dSet.Tables.AddRange(new System.Data.DataTable[] {
            this.dt_SynchList});
            // 
            // dt_SynchList
            // 
            this.dt_SynchList.Columns.AddRange(new System.Data.DataColumn[] {
            this.dc_SIValue,
            this.dc_SIType,
            this.dc_SItem,
            this.dc_SIActive,
            this.dc_SIStatus});
            this.dt_SynchList.TableName = "SynchList";
            // 
            // dc_SIValue
            // 
            this.dc_SIValue.Caption = "SIValue";
            this.dc_SIValue.ColumnName = "SIValue";
            // 
            // dc_SIType
            // 
            this.dc_SIType.Caption = "SIType";
            this.dc_SIType.ColumnName = "SIType";
            // 
            // dc_SIActive
            // 
            this.dc_SIActive.Caption = "SIActive";
            this.dc_SIActive.ColumnName = "SIActive";
            this.dc_SIActive.DataType = typeof(bool);
            // 
            // dc_SIStatus
            // 
            this.dc_SIStatus.Caption = "SIStatus";
            this.dc_SIStatus.ColumnName = "SIStatus";
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(479, 8);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(560, 8);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_ToDirName);
            this.panel1.Controls.Add(this.btn_OK);
            this.panel1.Controls.Add(this.lbl_To);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.lbl_FromDirName);
            this.panel1.Controls.Add(this.lbl_From);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 39);
            this.panel1.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SItem";
            this.dataGridViewTextBoxColumn1.HeaderText = "SItem";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SItem";
            this.dataGridViewTextBoxColumn2.HeaderText = "SItem";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // lbl_From
            // 
            this.lbl_From.AutoSize = true;
            this.lbl_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_From.Location = new System.Drawing.Point(12, 3);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(33, 13);
            this.lbl_From.TabIndex = 0;
            this.lbl_From.Text = "From:";
            // 
            // lbl_FromDirName
            // 
            this.lbl_FromDirName.AutoSize = true;
            this.lbl_FromDirName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_FromDirName.Location = new System.Drawing.Point(51, 3);
            this.lbl_FromDirName.Name = "lbl_FromDirName";
            this.lbl_FromDirName.Size = new System.Drawing.Size(19, 13);
            this.lbl_FromDirName.TabIndex = 1;
            this.lbl_FromDirName.Text = "...";
            // 
            // lbl_To
            // 
            this.lbl_To.AutoSize = true;
            this.lbl_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_To.Location = new System.Drawing.Point(22, 21);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(23, 13);
            this.lbl_To.TabIndex = 2;
            this.lbl_To.Text = "To:";
            // 
            // lbl_ToDirName
            // 
            this.lbl_ToDirName.AutoSize = true;
            this.lbl_ToDirName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_ToDirName.Location = new System.Drawing.Point(51, 21);
            this.lbl_ToDirName.Name = "lbl_ToDirName";
            this.lbl_ToDirName.Size = new System.Drawing.Size(19, 13);
            this.lbl_ToDirName.TabIndex = 3;
            this.lbl_ToDirName.Text = "...";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SItem";
            this.dataGridViewTextBoxColumn3.HeaderText = "SItem";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // gc_SItem
            // 
            this.gc_SItem.DataPropertyName = "SItem";
            this.gc_SItem.HeaderText = "SItem";
            this.gc_SItem.Name = "gc_SItem";
            this.gc_SItem.ReadOnly = true;
            this.gc_SItem.Visible = false;
            // 
            // dc_SItem
            // 
            this.dc_SItem.Caption = "SItem";
            this.dc_SItem.ColumnName = "SItem";
            this.dc_SItem.DataType = typeof(object);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_CheckAll,
            this.mi_UncheckAll});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // mi_CheckAll
            // 
            this.mi_CheckAll.Name = "mi_CheckAll";
            this.mi_CheckAll.Size = new System.Drawing.Size(152, 22);
            this.mi_CheckAll.Text = "Check All";
            this.mi_CheckAll.Click += new System.EventHandler(this.mi_CheckAll_Click);
            // 
            // mi_UncheckAll
            // 
            this.mi_UncheckAll.Name = "mi_UncheckAll";
            this.mi_UncheckAll.Size = new System.Drawing.Size(152, 22);
            this.mi_UncheckAll.Text = "Uncheck All";
            this.mi_UncheckAll.Click += new System.EventHandler(this.mi_UncheckAll_Click);
            // 
            // FTargetSynchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 329);
            this.Controls.Add(this.dgv_SynchList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "FTargetSynchList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Target Synch List";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SynchList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_SynchList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_SynchList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_SynchList;
        private System.Data.DataSet dSet;
        private System.Windows.Forms.BindingSource bs_SynchList;
        private System.Data.DataTable dt_SynchList;
        private System.Data.DataColumn dc_SIValue;
        private System.Data.DataColumn dc_SIType;
        private System.Data.DataColumn dc_SItem;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Data.DataColumn dc_SIActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Data.DataColumn dc_SIStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gc_SIActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_SIValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_SIType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_SItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_SIStatus;
        private System.Windows.Forms.Label lbl_ToDirName;
        private System.Windows.Forms.Label lbl_To;
        private System.Windows.Forms.Label lbl_FromDirName;
        private System.Windows.Forms.Label lbl_From;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mi_CheckAll;
        private System.Windows.Forms.ToolStripMenuItem mi_UncheckAll;
    }
}