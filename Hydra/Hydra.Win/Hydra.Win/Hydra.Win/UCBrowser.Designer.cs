namespace Hydra.Win
{
    partial class UCBrowser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvConsole = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsDeveloperMenu = new System.Windows.Forms.ToolStrip();
            this.tsbDock = new System.Windows.Forms.ToolStripButton();
            this.tsbReload = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsole)).BeginInit();
            this.tsDeveloperMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvConsole);
            this.splitContainer.Panel2.Controls.Add(this.tsDeveloperMenu);
            this.splitContainer.Size = new System.Drawing.Size(800, 400);
            this.splitContainer.SplitterDistance = 300;
            this.splitContainer.TabIndex = 0;
            // 
            // dgvConsole
            // 
            this.dgvConsole.AllowUserToAddRows = false;
            this.dgvConsole.AllowUserToDeleteRows = false;
            this.dgvConsole.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsole.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvConsole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.dgvcMessage,
            this.dgvcUrl,
            this.dgvcLineNumber,
            this.dgvcSource});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsole.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsole.Location = new System.Drawing.Point(24, 0);
            this.dgvConsole.Name = "dgvConsole";
            this.dgvConsole.ReadOnly = true;
            this.dgvConsole.RowHeadersWidth = 10;
            this.dgvConsole.RowTemplate.Height = 20;
            this.dgvConsole.Size = new System.Drawing.Size(776, 96);
            this.dgvConsole.TabIndex = 0;
            this.dgvConsole.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvConsole_PreviewKeyDown);
            // 
            // type
            // 
            this.type.HeaderText = "";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // dgvcMessage
            // 
            this.dgvcMessage.FillWeight = 500F;
            this.dgvcMessage.HeaderText = "Message";
            this.dgvcMessage.Name = "dgvcMessage";
            this.dgvcMessage.ReadOnly = true;
            this.dgvcMessage.Width = 500;
            // 
            // dgvcUrl
            // 
            this.dgvcUrl.HeaderText = "Url";
            this.dgvcUrl.Name = "dgvcUrl";
            this.dgvcUrl.ReadOnly = true;
            this.dgvcUrl.Visible = false;
            // 
            // dgvcLineNumber
            // 
            this.dgvcLineNumber.HeaderText = "Line Number";
            this.dgvcLineNumber.Name = "dgvcLineNumber";
            this.dgvcLineNumber.ReadOnly = true;
            this.dgvcLineNumber.Visible = false;
            // 
            // dgvcSource
            // 
            this.dgvcSource.FillWeight = 200F;
            this.dgvcSource.HeaderText = "Source";
            this.dgvcSource.Name = "dgvcSource";
            this.dgvcSource.ReadOnly = true;
            this.dgvcSource.Width = 200;
            // 
            // tsDeveloperMenu
            // 
            this.tsDeveloperMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsDeveloperMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsDeveloperMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDock,
            this.tsbReload});
            this.tsDeveloperMenu.Location = new System.Drawing.Point(0, 0);
            this.tsDeveloperMenu.Name = "tsDeveloperMenu";
            this.tsDeveloperMenu.Size = new System.Drawing.Size(24, 96);
            this.tsDeveloperMenu.TabIndex = 1;
            this.tsDeveloperMenu.Text = "Developer Menu";
            // 
            // tsbDock
            // 
            this.tsbDock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDock.Image = global::Hydra.Win.Properties.Resources.dock_right_16_icon;
            this.tsbDock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDock.Name = "tsbDock";
            this.tsbDock.Size = new System.Drawing.Size(21, 20);
            this.tsbDock.Text = "Dock";
            this.tsbDock.Click += new System.EventHandler(this.tsbDock_Click);
            // 
            // tsbReload
            // 
            this.tsbReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReload.Image = global::Hydra.Win.Properties.Resources.refresh_16_icon;
            this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReload.Name = "tsbReload";
            this.tsbReload.Size = new System.Drawing.Size(21, 20);
            this.tsbReload.Text = "Reload";
            this.tsbReload.ToolTipText = "Reload";
            this.tsbReload.Click += new System.EventHandler(this.tsbReload_Click);
            // 
            // UCBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UCBrowser";
            this.Size = new System.Drawing.Size(800, 400);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsole)).EndInit();
            this.tsDeveloperMenu.ResumeLayout(false);
            this.tsDeveloperMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvConsole;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSource;
        private System.Windows.Forms.ToolStrip tsDeveloperMenu;
        private System.Windows.Forms.ToolStripButton tsbDock;
        private System.Windows.Forms.ToolStripButton tsbReload;
    }
}
