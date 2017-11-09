namespace DBStudio
{
    partial class FConnections
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.dgv_Connections = new System.Windows.Forms.DataGridView();
            this.gc_C_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_C_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_C_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gc_C_TYPE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ds_Connections = new System.Data.DataSet();
            this.dt_Connections = new System.Data.DataTable();
            this.tc_C_TYPE = new System.Data.DataColumn();
            this.tc_C_NAME = new System.Data.DataColumn();
            this.tc_C_ID = new System.Data.DataColumn();
            this.tc_C_TYPE_ID = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Connections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_Connections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Connections)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Connect.Location = new System.Drawing.Point(271, 153);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 0;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Location = new System.Drawing.Point(352, 153);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // dgv_Connections
            // 
            this.dgv_Connections.AllowUserToAddRows = false;
            this.dgv_Connections.AllowUserToDeleteRows = false;
            this.dgv_Connections.AllowUserToResizeColumns = false;
            this.dgv_Connections.AllowUserToResizeRows = false;
            this.dgv_Connections.AutoGenerateColumns = false;
            this.dgv_Connections.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Connections.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Connections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Connections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Connections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gc_C_TYPE,
            this.gc_C_NAME,
            this.gc_C_ID,
            this.gc_C_TYPE_ID});
            this.dgv_Connections.DataMember = "Connections";
            this.dgv_Connections.DataSource = this.ds_Connections;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Connections.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Connections.Location = new System.Drawing.Point(12, 12);
            this.dgv_Connections.MultiSelect = false;
            this.dgv_Connections.Name = "dgv_Connections";
            this.dgv_Connections.ReadOnly = true;
            this.dgv_Connections.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_Connections.RowHeadersVisible = false;
            this.dgv_Connections.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Connections.RowTemplate.Height = 20;
            this.dgv_Connections.RowTemplate.ReadOnly = true;
            this.dgv_Connections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Connections.Size = new System.Drawing.Size(415, 135);
            this.dgv_Connections.TabIndex = 2;
            this.dgv_Connections.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Connections_CellDoubleClick);
            // 
            // gc_C_TYPE
            // 
            this.gc_C_TYPE.DataPropertyName = "C_TYPE";
            this.gc_C_TYPE.HeaderText = "Type";
            this.gc_C_TYPE.Name = "gc_C_TYPE";
            this.gc_C_TYPE.ReadOnly = true;
            // 
            // gc_C_NAME
            // 
            this.gc_C_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gc_C_NAME.DataPropertyName = "C_NAME";
            this.gc_C_NAME.HeaderText = "Name";
            this.gc_C_NAME.Name = "gc_C_NAME";
            this.gc_C_NAME.ReadOnly = true;
            // 
            // gc_C_ID
            // 
            this.gc_C_ID.DataPropertyName = "C_ID";
            this.gc_C_ID.HeaderText = "C_ID";
            this.gc_C_ID.Name = "gc_C_ID";
            this.gc_C_ID.ReadOnly = true;
            this.gc_C_ID.Visible = false;
            // 
            // gc_C_TYPE_ID
            // 
            this.gc_C_TYPE_ID.DataPropertyName = "C_TYPE_ID";
            this.gc_C_TYPE_ID.HeaderText = "C_TYPE_ID";
            this.gc_C_TYPE_ID.Name = "gc_C_TYPE_ID";
            this.gc_C_TYPE_ID.ReadOnly = true;
            this.gc_C_TYPE_ID.Visible = false;
            // 
            // ds_Connections
            // 
            this.ds_Connections.DataSetName = "NewDataSet";
            this.ds_Connections.Tables.AddRange(new System.Data.DataTable[] {
            this.dt_Connections});
            // 
            // dt_Connections
            // 
            this.dt_Connections.Columns.AddRange(new System.Data.DataColumn[] {
            this.tc_C_TYPE,
            this.tc_C_NAME,
            this.tc_C_ID,
            this.tc_C_TYPE_ID});
            this.dt_Connections.TableName = "Connections";
            // 
            // tc_C_TYPE
            // 
            this.tc_C_TYPE.Caption = "C_TYPE";
            this.tc_C_TYPE.ColumnName = "C_TYPE";
            // 
            // tc_C_NAME
            // 
            this.tc_C_NAME.Caption = "C_NAME";
            this.tc_C_NAME.ColumnName = "C_NAME";
            // 
            // tc_C_ID
            // 
            this.tc_C_ID.Caption = "C_ID";
            this.tc_C_ID.ColumnName = "C_ID";
            this.tc_C_ID.DataType = typeof(int);
            // 
            // tc_C_TYPE_ID
            // 
            this.tc_C_TYPE_ID.Caption = "C_TYPE_ID";
            this.tc_C_TYPE_ID.ColumnName = "C_TYPE_ID";
            this.tc_C_TYPE_ID.DataType = typeof(int);
            // 
            // FConnections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 188);
            this.Controls.Add(this.dgv_Connections);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FConnections";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connections";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Connections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_Connections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Connections)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dgv_Connections;
        private System.Data.DataSet ds_Connections;
        private System.Data.DataTable dt_Connections;
        private System.Data.DataColumn tc_C_TYPE;
        private System.Data.DataColumn tc_C_NAME;
        private System.Data.DataColumn tc_C_ID;
        private System.Data.DataColumn tc_C_TYPE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_C_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_C_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_C_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gc_C_TYPE_ID;
    }
}