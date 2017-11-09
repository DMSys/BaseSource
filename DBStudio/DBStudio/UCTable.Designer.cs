namespace DBStudio
{
    partial class UCTable
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
            this.components = new System.ComponentModel.Container();
            this.bs_TColumns = new System.Windows.Forms.BindingSource(this.components);
            this.ds_Table = new System.Data.DataSet();
            this.dtTColumns = new System.Data.DataTable();
            this.t_CName = new System.Data.DataColumn();
            this.t_CVComponent = new System.Data.DataColumn();
            this.t_CDataType = new System.Data.DataColumn();
            this.t_CID = new System.Data.DataColumn();
            this.t_CText = new System.Data.DataColumn();
            this.dtTVComponent = new System.Data.DataTable();
            this.t_VComponentID = new System.Data.DataColumn();
            this.t_VComponentName = new System.Data.DataColumn();
            this.dtTColumnNames = new System.Data.DataTable();
            this.t_ColumnName = new System.Data.DataColumn();
            this.cb_Table = new System.Windows.Forms.ComboBox();
            this.lbl_Table = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_Save = new System.Windows.Forms.ToolStripButton();
            this.tsb_DeleteRow = new System.Windows.Forms.ToolStripButton();
            this.tsb_UpRow = new System.Windows.Forms.ToolStripButton();
            this.tsb_DownRow = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_Caption = new System.Windows.Forms.TextBox();
            this.lbl_Text = new System.Windows.Forms.Label();
            this.dgv_TColumns = new System.Windows.Forms.DataGridView();
            this.CName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bs_TColumnNames = new System.Windows.Forms.BindingSource(this.components);
            this.CText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CVComponent = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bs_TVComponent = new System.Windows.Forms.BindingSource(this.components);
            this.cNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVComponentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDataTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bs_TColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_Table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTVComponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTColumnNames)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_TColumnNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_TVComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // bs_TColumns
            // 
            this.bs_TColumns.AllowNew = true;
            this.bs_TColumns.DataMember = "TColumns";
            this.bs_TColumns.DataSource = this.ds_Table;
            // 
            // ds_Table
            // 
            this.ds_Table.DataSetName = "NewDataSet";
            this.ds_Table.Tables.AddRange(new System.Data.DataTable[] {
            this.dtTColumns,
            this.dtTVComponent,
            this.dtTColumnNames});
            // 
            // dtTColumns
            // 
            this.dtTColumns.Columns.AddRange(new System.Data.DataColumn[] {
            this.t_CName,
            this.t_CVComponent,
            this.t_CDataType,
            this.t_CID,
            this.t_CText});
            this.dtTColumns.TableName = "TColumns";
            // 
            // t_CName
            // 
            this.t_CName.Caption = "CName";
            this.t_CName.ColumnName = "CName";
            // 
            // t_CVComponent
            // 
            this.t_CVComponent.Caption = "CVComponent";
            this.t_CVComponent.ColumnName = "CVComponent";
            this.t_CVComponent.DataType = typeof(int);
            // 
            // t_CDataType
            // 
            this.t_CDataType.Caption = "CDataType";
            this.t_CDataType.ColumnName = "CDataType";
            // 
            // t_CID
            // 
            this.t_CID.Caption = "CID";
            this.t_CID.ColumnName = "CID";
            this.t_CID.DataType = typeof(int);
            // 
            // t_CText
            // 
            this.t_CText.Caption = "CText";
            this.t_CText.ColumnName = "CText";
            // 
            // dtTVComponent
            // 
            this.dtTVComponent.Columns.AddRange(new System.Data.DataColumn[] {
            this.t_VComponentID,
            this.t_VComponentName});
            this.dtTVComponent.TableName = "TVComponent";
            // 
            // t_VComponentID
            // 
            this.t_VComponentID.Caption = "VComponentID";
            this.t_VComponentID.ColumnName = "VComponentID";
            this.t_VComponentID.DataType = typeof(int);
            // 
            // t_VComponentName
            // 
            this.t_VComponentName.Caption = "VComponentName";
            this.t_VComponentName.ColumnName = "VComponentName";
            // 
            // dtTColumnNames
            // 
            this.dtTColumnNames.Columns.AddRange(new System.Data.DataColumn[] {
            this.t_ColumnName});
            this.dtTColumnNames.TableName = "TColumnNames";
            // 
            // t_ColumnName
            // 
            this.t_ColumnName.Caption = "ColumnName";
            this.t_ColumnName.ColumnName = "ColumnName";
            // 
            // cb_Table
            // 
            this.cb_Table.BackColor = System.Drawing.SystemColors.Window;
            this.cb_Table.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Table.FormattingEnabled = true;
            this.cb_Table.Location = new System.Drawing.Point(55, 3);
            this.cb_Table.Name = "cb_Table";
            this.cb_Table.Size = new System.Drawing.Size(300, 21);
            this.cb_Table.TabIndex = 3;
            this.cb_Table.SelectedIndexChanged += new System.EventHandler(this.cb_Table_SelectedIndexChanged);
            // 
            // lbl_Table
            // 
            this.lbl_Table.AutoSize = true;
            this.lbl_Table.Location = new System.Drawing.Point(3, 6);
            this.lbl_Table.Name = "lbl_Table";
            this.lbl_Table.Size = new System.Drawing.Size(37, 13);
            this.lbl_Table.TabIndex = 2;
            this.lbl_Table.Text = "Table:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Save,
            this.tsb_DeleteRow,
            this.tsb_UpRow,
            this.tsb_DownRow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(768, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_Save
            // 
            this.tsb_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Save.Image = global::DBStudio.Properties.Resources._8703_22102_save;
            this.tsb_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Save.Name = "tsb_Save";
            this.tsb_Save.Size = new System.Drawing.Size(23, 22);
            this.tsb_Save.Text = "Save";
            this.tsb_Save.Click += new System.EventHandler(this.tsb_Save_Click);
            // 
            // tsb_DeleteRow
            // 
            this.tsb_DeleteRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_DeleteRow.Image = global::DBStudio.Properties.Resources._22887_50038_delete_table_row;
            this.tsb_DeleteRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_DeleteRow.Name = "tsb_DeleteRow";
            this.tsb_DeleteRow.Size = new System.Drawing.Size(23, 22);
            this.tsb_DeleteRow.Text = "Delete row";
            this.tsb_DeleteRow.ToolTipText = "Delete row";
            this.tsb_DeleteRow.Click += new System.EventHandler(this.tsb_DeleteRow_Click);
            // 
            // tsb_UpRow
            // 
            this.tsb_UpRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_UpRow.Image = global::DBStudio.Properties.Resources._3777_11375_arrow_up;
            this.tsb_UpRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_UpRow.Name = "tsb_UpRow";
            this.tsb_UpRow.Size = new System.Drawing.Size(23, 22);
            this.tsb_UpRow.Text = "Up row";
            this.tsb_UpRow.Click += new System.EventHandler(this.tsb_UpRow_Click);
            // 
            // tsb_DownRow
            // 
            this.tsb_DownRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_DownRow.Image = global::DBStudio.Properties.Resources._3781_11383_arrow_down;
            this.tsb_DownRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_DownRow.Name = "tsb_DownRow";
            this.tsb_DownRow.Size = new System.Drawing.Size(23, 22);
            this.tsb_DownRow.Text = "Down row";
            this.tsb_DownRow.Click += new System.EventHandler(this.tsb_DownRow_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_Caption);
            this.panel1.Controls.Add(this.lbl_Text);
            this.panel1.Controls.Add(this.cb_Table);
            this.panel1.Controls.Add(this.lbl_Table);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 55);
            this.panel1.TabIndex = 5;
            // 
            // tb_Caption
            // 
            this.tb_Caption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Caption.Location = new System.Drawing.Point(55, 29);
            this.tb_Caption.Name = "tb_Caption";
            this.tb_Caption.Size = new System.Drawing.Size(300, 20);
            this.tb_Caption.TabIndex = 5;
            // 
            // lbl_Text
            // 
            this.lbl_Text.AutoSize = true;
            this.lbl_Text.Location = new System.Drawing.Point(3, 31);
            this.lbl_Text.Name = "lbl_Text";
            this.lbl_Text.Size = new System.Drawing.Size(46, 13);
            this.lbl_Text.TabIndex = 4;
            this.lbl_Text.Text = "Caption:";
            // 
            // dgv_TColumns
            // 
            this.dgv_TColumns.AutoGenerateColumns = false;
            this.dgv_TColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CName,
            this.CText,
            this.CDataType,
            this.CVComponent,
            this.cNameDataGridViewTextBoxColumn,
            this.cVComponentDataGridViewTextBoxColumn,
            this.cDataTypeDataGridViewTextBoxColumn});
            this.dgv_TColumns.DataSource = this.bs_TColumns;
            this.dgv_TColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_TColumns.Location = new System.Drawing.Point(0, 80);
            this.dgv_TColumns.MultiSelect = false;
            this.dgv_TColumns.Name = "dgv_TColumns";
            this.dgv_TColumns.RowHeadersWidth = 20;
            this.dgv_TColumns.RowTemplate.Height = 20;
            this.dgv_TColumns.Size = new System.Drawing.Size(768, 265);
            this.dgv_TColumns.TabIndex = 6;
            this.dgv_TColumns.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgv_TColumns_CellParsing);
            this.dgv_TColumns.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_TColumns_EditingControlShowing);
            // 
            // CName
            // 
            this.CName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CName.DataPropertyName = "CName";
            this.CName.DataSource = this.bs_TColumnNames;
            this.CName.DisplayMember = "ColumnName";
            this.CName.HeaderText = "CName";
            this.CName.Name = "CName";
            // 
            // bs_TColumnNames
            // 
            this.bs_TColumnNames.DataMember = "TColumnNames";
            this.bs_TColumnNames.DataSource = this.ds_Table;
            // 
            // CText
            // 
            this.CText.DataPropertyName = "CText";
            this.CText.FillWeight = 150F;
            this.CText.HeaderText = "CText";
            this.CText.Name = "CText";
            this.CText.Width = 150;
            // 
            // CDataType
            // 
            this.CDataType.DataPropertyName = "CDataType";
            this.CDataType.HeaderText = "DataType";
            this.CDataType.Name = "CDataType";
            // 
            // CVComponent
            // 
            this.CVComponent.DataPropertyName = "CVComponent";
            this.CVComponent.DataSource = this.bs_TVComponent;
            this.CVComponent.DisplayMember = "VComponentName";
            this.CVComponent.FillWeight = 130F;
            this.CVComponent.HeaderText = "VComponent";
            this.CVComponent.Name = "CVComponent";
            this.CVComponent.ValueMember = "VComponentID";
            this.CVComponent.Width = 130;
            // 
            // bs_TVComponent
            // 
            this.bs_TVComponent.DataMember = "TVComponent";
            this.bs_TVComponent.DataSource = this.ds_Table;
            // 
            // cNameDataGridViewTextBoxColumn
            // 
            this.cNameDataGridViewTextBoxColumn.DataPropertyName = "CName";
            this.cNameDataGridViewTextBoxColumn.HeaderText = "CName";
            this.cNameDataGridViewTextBoxColumn.Name = "cNameDataGridViewTextBoxColumn";
            this.cNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // cVComponentDataGridViewTextBoxColumn
            // 
            this.cVComponentDataGridViewTextBoxColumn.DataPropertyName = "CVComponent";
            this.cVComponentDataGridViewTextBoxColumn.HeaderText = "CVComponent";
            this.cVComponentDataGridViewTextBoxColumn.Name = "cVComponentDataGridViewTextBoxColumn";
            this.cVComponentDataGridViewTextBoxColumn.Visible = false;
            // 
            // cDataTypeDataGridViewTextBoxColumn
            // 
            this.cDataTypeDataGridViewTextBoxColumn.DataPropertyName = "CDataType";
            this.cDataTypeDataGridViewTextBoxColumn.HeaderText = "CDataType";
            this.cDataTypeDataGridViewTextBoxColumn.Name = "cDataTypeDataGridViewTextBoxColumn";
            this.cDataTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // UCTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_TColumns);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UCTable";
            this.Size = new System.Drawing.Size(768, 345);
            ((System.ComponentModel.ISupportInitialize)(this.bs_TColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_Table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTVComponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTColumnNames)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_TColumnNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_TVComponent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Table;
        private System.Windows.Forms.Label lbl_Table;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_TColumns;
        private System.Data.DataSet ds_Table;
        private System.Data.DataTable dtTColumns;
        private System.Data.DataColumn t_CName;
        private System.Windows.Forms.BindingSource bs_TVComponent;
        private System.Data.DataColumn t_CVComponent;
        private System.Data.DataTable dtTVComponent;
        private System.Data.DataColumn t_VComponentID;
        private System.Data.DataColumn t_VComponentName;
        private System.Data.DataColumn t_CDataType;
        private System.Windows.Forms.TextBox tb_Caption;
        private System.Windows.Forms.Label lbl_Text;
        private System.Windows.Forms.BindingSource bs_TColumnNames;
        private System.Data.DataTable dtTColumnNames;
        private System.Data.DataColumn t_ColumnName;
        private System.Windows.Forms.BindingSource bs_TColumns;
        private System.Windows.Forms.ToolStripButton tsb_DeleteRow;
        private System.Data.DataColumn t_CID;
        private System.Windows.Forms.ToolStripButton tsb_UpRow;
        private System.Windows.Forms.ToolStripButton tsb_DownRow;
        private System.Data.DataColumn t_CText;
        private System.Windows.Forms.DataGridViewComboBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CText;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDataType;
        private System.Windows.Forms.DataGridViewComboBoxColumn CVComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVComponentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDataTypeDataGridViewTextBoxColumn;
    }
}
