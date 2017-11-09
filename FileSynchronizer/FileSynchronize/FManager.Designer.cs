namespace FileSynchronizer
{
    partial class FManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FManager));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ds_Synchronizer = new System.Data.DataSet();
            this.dt_Target = new System.Data.DataTable();
            this.tc_TNo = new System.Data.DataColumn();
            this.tc_TSource = new System.Data.DataColumn();
            this.tc_TDestination = new System.Data.DataColumn();
            this.tc_TName = new System.Data.DataColumn();
            this.dt_LIgnoreList = new System.Data.DataTable();
            this.tc_LINo = new System.Data.DataColumn();
            this.tc_LIType = new System.Data.DataColumn();
            this.tc_LIgnoreItem = new System.Data.DataColumn();
            this.dt_GIgnoreList = new System.Data.DataTable();
            this.tc_GINo = new System.Data.DataColumn();
            this.tc_GIType = new System.Data.DataColumn();
            this.tc_GIgnoreItem = new System.Data.DataColumn();
            this.bs_Targets = new System.Windows.Forms.BindingSource(this.components);
            this.dgv_Targets = new System.Windows.Forms.DataGridView();
            this.gc_TNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_TName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_TSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_TDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms_TargetG = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_SynchTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_EditTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_DeleteTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_NewIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_NewIgnoreLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_NewIgnoreGlobal = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Synchronizer = new System.Windows.Forms.ToolStrip();
            this.tsb_NewTarget = new System.Windows.Forms.ToolStripButton();
            this.tsb_Synch = new System.Windows.Forms.ToolStripButton();
            this.tsb_SynchAll = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv_LIgnoreList = new System.Windows.Forms.DataGridView();
            this.cms_LIgnoreG = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_EditLIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_DeleteLIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.bs_LIgnoreList = new System.Windows.Forms.BindingSource(this.components);
            this.dgv_GIgnoreList = new System.Windows.Forms.DataGridView();
            this.cms_GIgnoreG = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_EditGIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_DeleteGIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.bs_GIgnoreList = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.gc_GINo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_GIType = new System.Windows.Forms.DataGridViewImageColumn();
            this.gc_GIgnoreItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_LINo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_LIType = new System.Windows.Forms.DataGridViewImageColumn();
            this.gc_LIgnoreItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ds_Synchronizer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_LIgnoreList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_GIgnoreList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Targets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Targets)).BeginInit();
            this.cms_TargetG.SuspendLayout();
            this.ts_Synchronizer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LIgnoreList)).BeginInit();
            this.cms_LIgnoreG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_LIgnoreList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GIgnoreList)).BeginInit();
            this.cms_GIgnoreG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_GIgnoreList)).BeginInit();
            this.SuspendLayout();
            // 
            // ds_Synchronizer
            // 
            this.ds_Synchronizer.DataSetName = "Synchronizer";
            this.ds_Synchronizer.Tables.AddRange(new System.Data.DataTable[] {
            this.dt_Target,
            this.dt_LIgnoreList,
            this.dt_GIgnoreList});
            // 
            // dt_Target
            // 
            this.dt_Target.Columns.AddRange(new System.Data.DataColumn[] {
            this.tc_TNo,
            this.tc_TSource,
            this.tc_TDestination,
            this.tc_TName});
            this.dt_Target.TableName = "Target";
            // 
            // tc_TNo
            // 
            this.tc_TNo.Caption = "No";
            this.tc_TNo.ColumnName = "tc_TNo";
            this.tc_TNo.DataType = typeof(int);
            // 
            // tc_TSource
            // 
            this.tc_TSource.Caption = "Source";
            this.tc_TSource.ColumnName = "tc_TSource";
            // 
            // tc_TDestination
            // 
            this.tc_TDestination.Caption = "Destination";
            this.tc_TDestination.ColumnName = "tc_TDestination";
            // 
            // tc_TName
            // 
            this.tc_TName.Caption = "Name";
            this.tc_TName.ColumnName = "tc_TName";
            // 
            // dt_LIgnoreList
            // 
            this.dt_LIgnoreList.Columns.AddRange(new System.Data.DataColumn[] {
            this.tc_LINo,
            this.tc_LIType,
            this.tc_LIgnoreItem});
            this.dt_LIgnoreList.TableName = "LIgnoreList";
            // 
            // tc_LINo
            // 
            this.tc_LINo.Caption = "LINo";
            this.tc_LINo.ColumnName = "LINo";
            this.tc_LINo.DataType = typeof(int);
            // 
            // tc_LIType
            // 
            this.tc_LIType.Caption = "LIType";
            this.tc_LIType.ColumnName = "LIType";
            this.tc_LIType.DataType = typeof(object);
            // 
            // tc_LIgnoreItem
            // 
            this.tc_LIgnoreItem.Caption = "LIgnoreItem";
            this.tc_LIgnoreItem.ColumnName = "LIgnoreItem";
            // 
            // dt_GIgnoreList
            // 
            this.dt_GIgnoreList.Columns.AddRange(new System.Data.DataColumn[] {
            this.tc_GINo,
            this.tc_GIType,
            this.tc_GIgnoreItem});
            this.dt_GIgnoreList.TableName = "GIgnoreList";
            // 
            // tc_GINo
            // 
            this.tc_GINo.Caption = "GINo";
            this.tc_GINo.ColumnName = "GINo";
            this.tc_GINo.DataType = typeof(int);
            // 
            // tc_GIType
            // 
            this.tc_GIType.Caption = "GIType";
            this.tc_GIType.ColumnName = "GIType";
            this.tc_GIType.DataType = typeof(object);
            // 
            // tc_GIgnoreItem
            // 
            this.tc_GIgnoreItem.ColumnName = "GIgnoreItem";
            // 
            // bs_Targets
            // 
            this.bs_Targets.DataMember = "Target";
            this.bs_Targets.DataSource = this.ds_Synchronizer;
            // 
            // dgv_Targets
            // 
            this.dgv_Targets.AllowUserToAddRows = false;
            this.dgv_Targets.AllowUserToDeleteRows = false;
            this.dgv_Targets.AllowUserToResizeRows = false;
            this.dgv_Targets.AutoGenerateColumns = false;
            this.dgv_Targets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Targets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gc_TNo,
            this.gc_TName,
            this.gc_TSource,
            this.gc_TDestination});
            this.dgv_Targets.ContextMenuStrip = this.cms_TargetG;
            this.dgv_Targets.DataSource = this.bs_Targets;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Targets.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Targets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Targets.Location = new System.Drawing.Point(0, 0);
            this.dgv_Targets.MultiSelect = false;
            this.dgv_Targets.Name = "dgv_Targets";
            this.dgv_Targets.ReadOnly = true;
            this.dgv_Targets.RowHeadersVisible = false;
            this.dgv_Targets.RowHeadersWidth = 15;
            this.dgv_Targets.RowTemplate.Height = 20;
            this.dgv_Targets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Targets.Size = new System.Drawing.Size(542, 362);
            this.dgv_Targets.TabIndex = 0;
            this.dgv_Targets.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Targets_CellMouseDoubleClick);
            this.dgv_Targets.SelectionChanged += new System.EventHandler(this.dgv_Targets_SelectionChanged);
            // 
            // gc_TNo
            // 
            this.gc_TNo.DataPropertyName = "tc_TNo";
            this.gc_TNo.HeaderText = "No";
            this.gc_TNo.Name = "gc_TNo";
            this.gc_TNo.ReadOnly = true;
            this.gc_TNo.Width = 30;
            // 
            // gc_TName
            // 
            this.gc_TName.DataPropertyName = "tc_TName";
            this.gc_TName.HeaderText = "Name";
            this.gc_TName.Name = "gc_TName";
            this.gc_TName.ReadOnly = true;
            this.gc_TName.Width = 150;
            // 
            // gc_TSource
            // 
            this.gc_TSource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gc_TSource.DataPropertyName = "tc_TSource";
            this.gc_TSource.HeaderText = "Source";
            this.gc_TSource.Name = "gc_TSource";
            this.gc_TSource.ReadOnly = true;
            // 
            // gc_TDestination
            // 
            this.gc_TDestination.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gc_TDestination.DataPropertyName = "tc_TDestination";
            this.gc_TDestination.HeaderText = "Destination";
            this.gc_TDestination.Name = "gc_TDestination";
            this.gc_TDestination.ReadOnly = true;
            // 
            // cms_TargetG
            // 
            this.cms_TargetG.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_SynchTarget,
            this.tsmi_EditTarget,
            this.tsmi_DeleteTarget,
            this.toolStripMenuItem1,
            this.tsmi_NewIgnore});
            this.cms_TargetG.Name = "cms_TargetG";
            this.cms_TargetG.Size = new System.Drawing.Size(131, 98);
            // 
            // tsmi_SynchTarget
            // 
            this.tsmi_SynchTarget.Name = "tsmi_SynchTarget";
            this.tsmi_SynchTarget.Size = new System.Drawing.Size(130, 22);
            this.tsmi_SynchTarget.Text = "Synch";
            this.tsmi_SynchTarget.Click += new System.EventHandler(this.tsmi_SynchTarget_Click);
            // 
            // tsmi_EditTarget
            // 
            this.tsmi_EditTarget.Name = "tsmi_EditTarget";
            this.tsmi_EditTarget.Size = new System.Drawing.Size(130, 22);
            this.tsmi_EditTarget.Text = "Edit";
            this.tsmi_EditTarget.Click += new System.EventHandler(this.tsmi_EditTarget_Click);
            // 
            // tsmi_DeleteTarget
            // 
            this.tsmi_DeleteTarget.Name = "tsmi_DeleteTarget";
            this.tsmi_DeleteTarget.Size = new System.Drawing.Size(130, 22);
            this.tsmi_DeleteTarget.Text = "Delete";
            this.tsmi_DeleteTarget.Click += new System.EventHandler(this.tsmi_DeleteTarget_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(127, 6);
            // 
            // tsmi_NewIgnore
            // 
            this.tsmi_NewIgnore.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_NewIgnoreLocal,
            this.tsmi_NewIgnoreGlobal});
            this.tsmi_NewIgnore.Name = "tsmi_NewIgnore";
            this.tsmi_NewIgnore.Size = new System.Drawing.Size(130, 22);
            this.tsmi_NewIgnore.Text = "New Ignore";
            // 
            // tsmi_NewIgnoreLocal
            // 
            this.tsmi_NewIgnoreLocal.Name = "tsmi_NewIgnoreLocal";
            this.tsmi_NewIgnoreLocal.Size = new System.Drawing.Size(103, 22);
            this.tsmi_NewIgnoreLocal.Text = "Local";
            this.tsmi_NewIgnoreLocal.Click += new System.EventHandler(this.tsmi_NewIgnoreLocal_Click);
            // 
            // tsmi_NewIgnoreGlobal
            // 
            this.tsmi_NewIgnoreGlobal.Name = "tsmi_NewIgnoreGlobal";
            this.tsmi_NewIgnoreGlobal.Size = new System.Drawing.Size(103, 22);
            this.tsmi_NewIgnoreGlobal.Text = "Global";
            this.tsmi_NewIgnoreGlobal.Click += new System.EventHandler(this.tsmi_NewIgnoreGlobal_Click);
            // 
            // ts_Synchronizer
            // 
            this.ts_Synchronizer.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ts_Synchronizer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_NewTarget,
            this.tsb_Synch,
            this.tsb_SynchAll});
            this.ts_Synchronizer.Location = new System.Drawing.Point(0, 0);
            this.ts_Synchronizer.Name = "ts_Synchronizer";
            this.ts_Synchronizer.Size = new System.Drawing.Size(740, 52);
            this.ts_Synchronizer.TabIndex = 0;
            this.ts_Synchronizer.Text = "ts_Synchronizer";
            // 
            // tsb_NewTarget
            // 
            this.tsb_NewTarget.Image = global::FileSynchronizer.Properties.Resources.folder_add_32;
            this.tsb_NewTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_NewTarget.Name = "tsb_NewTarget";
            this.tsb_NewTarget.Size = new System.Drawing.Size(67, 49);
            this.tsb_NewTarget.Text = "New Target";
            this.tsb_NewTarget.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_NewTarget.Click += new System.EventHandler(this.tsb_NewTarget_Click);
            // 
            // tsb_Synch
            // 
            this.tsb_Synch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsb_Synch.Image = global::FileSynchronizer.Properties.Resources.recycle_32;
            this.tsb_Synch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Synch.Name = "tsb_Synch";
            this.tsb_Synch.Size = new System.Drawing.Size(45, 49);
            this.tsb_Synch.Text = "Synch";
            this.tsb_Synch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Synch.Click += new System.EventHandler(this.tsb_Synch_Click);
            // 
            // tsb_SynchAll
            // 
            this.tsb_SynchAll.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SynchAll.Image")));
            this.tsb_SynchAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SynchAll.Name = "tsb_SynchAll";
            this.tsb_SynchAll.Size = new System.Drawing.Size(54, 49);
            this.tsb_SynchAll.Text = "Synch All";
            this.tsb_SynchAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_SynchAll.Click += new System.EventHandler(this.tsb_SynchAll_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Targets);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(740, 362);
            this.splitContainer1.SplitterDistance = 542;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv_LIgnoreList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_GIgnoreList);
            this.splitContainer2.Size = new System.Drawing.Size(194, 362);
            this.splitContainer2.SplitterDistance = 168;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgv_LIgnoreList
            // 
            this.dgv_LIgnoreList.AllowUserToAddRows = false;
            this.dgv_LIgnoreList.AllowUserToDeleteRows = false;
            this.dgv_LIgnoreList.AllowUserToResizeRows = false;
            this.dgv_LIgnoreList.AutoGenerateColumns = false;
            this.dgv_LIgnoreList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LIgnoreList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gc_LINo,
            this.gc_LIType,
            this.gc_LIgnoreItem});
            this.dgv_LIgnoreList.ContextMenuStrip = this.cms_LIgnoreG;
            this.dgv_LIgnoreList.DataSource = this.bs_LIgnoreList;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_LIgnoreList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_LIgnoreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_LIgnoreList.Location = new System.Drawing.Point(0, 0);
            this.dgv_LIgnoreList.MultiSelect = false;
            this.dgv_LIgnoreList.Name = "dgv_LIgnoreList";
            this.dgv_LIgnoreList.ReadOnly = true;
            this.dgv_LIgnoreList.RowHeadersVisible = false;
            this.dgv_LIgnoreList.RowHeadersWidth = 15;
            this.dgv_LIgnoreList.RowTemplate.Height = 20;
            this.dgv_LIgnoreList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LIgnoreList.Size = new System.Drawing.Size(194, 168);
            this.dgv_LIgnoreList.TabIndex = 0;
            this.dgv_LIgnoreList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_LIgnoreList_CellMouseDoubleClick);
            // 
            // cms_LIgnoreG
            // 
            this.cms_LIgnoreG.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_EditLIgnore,
            this.tsmi_DeleteLIgnore});
            this.cms_LIgnoreG.Name = "cms_LIgnoreG";
            this.cms_LIgnoreG.Size = new System.Drawing.Size(106, 48);
            this.cms_LIgnoreG.Opening += new System.ComponentModel.CancelEventHandler(this.cms_LIgnoreG_Opening);
            // 
            // tsmi_EditLIgnore
            // 
            this.tsmi_EditLIgnore.Name = "tsmi_EditLIgnore";
            this.tsmi_EditLIgnore.Size = new System.Drawing.Size(105, 22);
            this.tsmi_EditLIgnore.Text = "Edit";
            this.tsmi_EditLIgnore.Click += new System.EventHandler(this.tsmi_EditLIgnore_Click);
            // 
            // tsmi_DeleteLIgnore
            // 
            this.tsmi_DeleteLIgnore.Name = "tsmi_DeleteLIgnore";
            this.tsmi_DeleteLIgnore.Size = new System.Drawing.Size(105, 22);
            this.tsmi_DeleteLIgnore.Text = "Delete";
            this.tsmi_DeleteLIgnore.Click += new System.EventHandler(this.tsmi_DeleteLIgnore_Click);
            // 
            // bs_LIgnoreList
            // 
            this.bs_LIgnoreList.DataMember = "LIgnoreList";
            this.bs_LIgnoreList.DataSource = this.ds_Synchronizer;
            // 
            // dgv_GIgnoreList
            // 
            this.dgv_GIgnoreList.AllowUserToAddRows = false;
            this.dgv_GIgnoreList.AllowUserToDeleteRows = false;
            this.dgv_GIgnoreList.AllowUserToResizeRows = false;
            this.dgv_GIgnoreList.AutoGenerateColumns = false;
            this.dgv_GIgnoreList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GIgnoreList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gc_GINo,
            this.gc_GIType,
            this.gc_GIgnoreItem});
            this.dgv_GIgnoreList.ContextMenuStrip = this.cms_GIgnoreG;
            this.dgv_GIgnoreList.DataSource = this.bs_GIgnoreList;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_GIgnoreList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_GIgnoreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_GIgnoreList.Location = new System.Drawing.Point(0, 0);
            this.dgv_GIgnoreList.MultiSelect = false;
            this.dgv_GIgnoreList.Name = "dgv_GIgnoreList";
            this.dgv_GIgnoreList.ReadOnly = true;
            this.dgv_GIgnoreList.RowHeadersVisible = false;
            this.dgv_GIgnoreList.RowHeadersWidth = 15;
            this.dgv_GIgnoreList.RowTemplate.Height = 20;
            this.dgv_GIgnoreList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_GIgnoreList.Size = new System.Drawing.Size(194, 190);
            this.dgv_GIgnoreList.TabIndex = 0;
            this.dgv_GIgnoreList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_GIgnoreList_CellMouseDoubleClick);
            // 
            // cms_GIgnoreG
            // 
            this.cms_GIgnoreG.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_EditGIgnore,
            this.tsmi_DeleteGIgnore});
            this.cms_GIgnoreG.Name = "cms_GIgnoreG";
            this.cms_GIgnoreG.Size = new System.Drawing.Size(106, 48);
            this.cms_GIgnoreG.Opening += new System.ComponentModel.CancelEventHandler(this.cms_GIgnoreG_Opening);
            // 
            // tsmi_EditGIgnore
            // 
            this.tsmi_EditGIgnore.Name = "tsmi_EditGIgnore";
            this.tsmi_EditGIgnore.Size = new System.Drawing.Size(105, 22);
            this.tsmi_EditGIgnore.Text = "Edit";
            this.tsmi_EditGIgnore.Click += new System.EventHandler(this.tsmi_EditGIgnore_Click);
            // 
            // tsmi_DeleteGIgnore
            // 
            this.tsmi_DeleteGIgnore.Name = "tsmi_DeleteGIgnore";
            this.tsmi_DeleteGIgnore.Size = new System.Drawing.Size(105, 22);
            this.tsmi_DeleteGIgnore.Text = "Delete";
            this.tsmi_DeleteGIgnore.Click += new System.EventHandler(this.tsmi_DeleteGIgnore_Click);
            // 
            // bs_GIgnoreList
            // 
            this.bs_GIgnoreList.AllowNew = true;
            this.bs_GIgnoreList.DataMember = "GIgnoreList";
            this.bs_GIgnoreList.DataSource = this.ds_Synchronizer;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(740, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "GIType";
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "LIType";
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 25;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.DataPropertyName = "GIType";
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Width = 25;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.DataPropertyName = "LIType";
            this.dataGridViewImageColumn4.HeaderText = "";
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.ReadOnly = true;
            this.dataGridViewImageColumn4.Width = 25;
            // 
            // dataGridViewImageColumn5
            // 
            this.dataGridViewImageColumn5.DataPropertyName = "GIType";
            this.dataGridViewImageColumn5.HeaderText = "";
            this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
            this.dataGridViewImageColumn5.ReadOnly = true;
            this.dataGridViewImageColumn5.Width = 25;
            // 
            // gc_GINo
            // 
            this.gc_GINo.DataPropertyName = "GINo";
            this.gc_GINo.HeaderText = "No";
            this.gc_GINo.Name = "gc_GINo";
            this.gc_GINo.ReadOnly = true;
            this.gc_GINo.Width = 30;
            // 
            // gc_GIType
            // 
            this.gc_GIType.DataPropertyName = "GIType";
            this.gc_GIType.HeaderText = "";
            this.gc_GIType.Name = "gc_GIType";
            this.gc_GIType.ReadOnly = true;
            this.gc_GIType.Width = 25;
            // 
            // gc_GIgnoreItem
            // 
            this.gc_GIgnoreItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gc_GIgnoreItem.DataPropertyName = "GIgnoreItem";
            this.gc_GIgnoreItem.HeaderText = "Global Ignore";
            this.gc_GIgnoreItem.Name = "gc_GIgnoreItem";
            this.gc_GIgnoreItem.ReadOnly = true;
            // 
            // gc_LINo
            // 
            this.gc_LINo.DataPropertyName = "LINo";
            this.gc_LINo.HeaderText = "No";
            this.gc_LINo.Name = "gc_LINo";
            this.gc_LINo.ReadOnly = true;
            this.gc_LINo.Width = 30;
            // 
            // gc_LIType
            // 
            this.gc_LIType.DataPropertyName = "LIType";
            this.gc_LIType.HeaderText = "";
            this.gc_LIType.Name = "gc_LIType";
            this.gc_LIType.ReadOnly = true;
            this.gc_LIType.Width = 25;
            // 
            // gc_LIgnoreItem
            // 
            this.gc_LIgnoreItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gc_LIgnoreItem.DataPropertyName = "LIgnoreItem";
            this.gc_LIgnoreItem.HeaderText = "Ignore";
            this.gc_LIgnoreItem.Name = "gc_LIgnoreItem";
            this.gc_LIgnoreItem.ReadOnly = true;
            // 
            // FManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 436);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ts_Synchronizer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Synchronizer";
            this.Load += new System.EventHandler(this.FManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds_Synchronizer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_LIgnoreList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_GIgnoreList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Targets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Targets)).EndInit();
            this.cms_TargetG.ResumeLayout(false);
            this.ts_Synchronizer.ResumeLayout(false);
            this.ts_Synchronizer.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LIgnoreList)).EndInit();
            this.cms_LIgnoreG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bs_LIgnoreList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GIgnoreList)).EndInit();
            this.cms_GIgnoreG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bs_GIgnoreList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet ds_Synchronizer;
        private System.Data.DataTable dt_Target;
        private System.Windows.Forms.BindingSource bs_Targets;
        private System.Windows.Forms.DataGridView dgv_Targets;
        private System.Data.DataColumn tc_TNo;
        private System.Data.DataColumn tc_TSource;
        private System.Data.DataColumn tc_TDestination;
        private System.Windows.Forms.ToolStrip ts_Synchronizer;
        private System.Windows.Forms.ToolStripButton tsb_Synch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Data.DataTable dt_LIgnoreList;
        private System.Windows.Forms.DataGridView dgv_LIgnoreList;
        private System.Windows.Forms.BindingSource bs_LIgnoreList;
        private System.Windows.Forms.ToolStripButton tsb_NewTarget;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgv_GIgnoreList;
        private System.Data.DataColumn tc_LINo;
        private System.Data.DataColumn tc_LIgnoreItem;
        private System.Data.DataTable dt_GIgnoreList;
        private System.Data.DataColumn tc_GINo;
        private System.Data.DataColumn tc_GIgnoreItem;
        private System.Windows.Forms.ContextMenuStrip cms_TargetG;
        private System.Windows.Forms.ToolStripMenuItem tsmi_EditTarget;
        private System.Windows.Forms.ToolStripMenuItem tsmi_NewIgnore;
        private System.Windows.Forms.ToolStripMenuItem tsmi_NewIgnoreLocal;
        private System.Windows.Forms.ToolStripMenuItem tsmi_NewIgnoreGlobal;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DeleteTarget;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cms_LIgnoreG;
        private System.Windows.Forms.ContextMenuStrip cms_GIgnoreG;
        private System.Windows.Forms.ToolStripMenuItem tsmi_EditLIgnore;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DeleteLIgnore;
        private System.Windows.Forms.ToolStripMenuItem tsmi_EditGIgnore;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DeleteGIgnore;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SynchTarget;
        private System.Windows.Forms.ToolStripButton tsb_SynchAll;
        private System.Data.DataColumn tc_TName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_TNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_TName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_TSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_TDestination;
        private System.Data.DataColumn tc_LIType;
        private System.Data.DataColumn tc_GIType;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn5;
        private System.Windows.Forms.BindingSource bs_GIgnoreList;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_LINo;
        private System.Windows.Forms.DataGridViewImageColumn gc_LIType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_LIgnoreItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_GINo;
        private System.Windows.Forms.DataGridViewImageColumn gc_GIType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_GIgnoreItem;
    }
}

