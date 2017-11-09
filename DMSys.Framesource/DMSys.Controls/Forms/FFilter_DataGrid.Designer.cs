namespace DMSys.Controls.Forms
{
    partial class FFilter_DataGrid
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dgShowFilterData = new System.Windows.Forms.DataGridView();
            this.ColumnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbOperation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ValueData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnWithoutFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgShowFilterData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(335, 269);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Затвори";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Location = new System.Drawing.Point(12, 269);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Филтър";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dgShowFilterData
            // 
            this.dgShowFilterData.AllowUserToAddRows = false;
            this.dgShowFilterData.AllowUserToDeleteRows = false;
            this.dgShowFilterData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgShowFilterData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgShowFilterData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNo,
            this.ColumnName,
            this.ColumnHeader,
            this.cbOperation,
            this.ValueData,
            this.ValueType});
            this.dgShowFilterData.Location = new System.Drawing.Point(12, 12);
            this.dgShowFilterData.Name = "dgShowFilterData";
            this.dgShowFilterData.RowHeadersWidth = 18;
            this.dgShowFilterData.RowTemplate.Height = 18;
            this.dgShowFilterData.Size = new System.Drawing.Size(398, 251);
            this.dgShowFilterData.TabIndex = 6;
            // 
            // ColumnNo
            // 
            this.ColumnNo.DataPropertyName = "ColumnNo";
            this.ColumnNo.HeaderText = "No";
            this.ColumnNo.Name = "ColumnNo";
            this.ColumnNo.ReadOnly = true;
            this.ColumnNo.Width = 40;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "ColumnName";
            this.ColumnName.HeaderText = "ColumnName";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Visible = false;
            this.ColumnName.Width = 120;
            // 
            // ColumnHeader
            // 
            this.ColumnHeader.DataPropertyName = "ColumnHeader";
            this.ColumnHeader.HeaderText = "Име на колона";
            this.ColumnHeader.Name = "ColumnHeader";
            this.ColumnHeader.ReadOnly = true;
            this.ColumnHeader.Width = 120;
            // 
            // cbOperation
            // 
            this.cbOperation.DataPropertyName = "Operation";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cbOperation.DefaultCellStyle = dataGridViewCellStyle1;
            this.cbOperation.HeaderText = "Опер.";
            this.cbOperation.Name = "cbOperation";
            this.cbOperation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbOperation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cbOperation.Width = 60;
            // 
            // ValueData
            // 
            this.ValueData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueData.DataPropertyName = "ValueData";
            this.ValueData.HeaderText = "Стойност";
            this.ValueData.Name = "ValueData";
            // 
            // ValueType
            // 
            this.ValueType.DataPropertyName = "ValueType";
            this.ValueType.HeaderText = "ValueType";
            this.ValueType.Name = "ValueType";
            this.ValueType.Visible = false;
            // 
            // btnWithoutFilter
            // 
            this.btnWithoutFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWithoutFilter.Location = new System.Drawing.Point(93, 269);
            this.btnWithoutFilter.Name = "btnWithoutFilter";
            this.btnWithoutFilter.Size = new System.Drawing.Size(75, 23);
            this.btnWithoutFilter.TabIndex = 7;
            this.btnWithoutFilter.Text = "Без филър";
            this.btnWithoutFilter.UseVisualStyleBackColor = true;
            this.btnWithoutFilter.Click += new System.EventHandler(this.btnWithoutFilter_Click);
            // 
            // FFilter_DataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 298);
            this.Controls.Add(this.btnWithoutFilter);
            this.Controls.Add(this.dgShowFilterData);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FFilter_DataGrid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Филтриране";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FFind_DataGrid_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgShowFilterData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgShowFilterData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHeader;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueType;
        private System.Windows.Forms.Button btnWithoutFilter;
    }
}