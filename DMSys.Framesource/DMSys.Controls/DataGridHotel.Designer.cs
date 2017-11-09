namespace DMSys.Controls
{
    partial class DataGridHotel
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
            this.cntxtMnStrp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRoomReserve = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRoomRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRoomProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.tsmiRoomClean = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtMnStrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // cntxtMnStrp
            // 
            this.cntxtMnStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRoomReserve,
            this.tsmiRoomRegister,
            this.toolStripMenuItem1,
            this.tsmiRoomClean,
            this.tsmiRoomProperty});
            this.cntxtMnStrp.Name = "contextMenuStrip1";
            this.cntxtMnStrp.Size = new System.Drawing.Size(169, 120);
            this.cntxtMnStrp.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtMnStrp_Opening);
            // 
            // tsmiRoomReserve
            // 
            this.tsmiRoomReserve.Name = "tsmiRoomReserve";
            this.tsmiRoomReserve.Size = new System.Drawing.Size(168, 22);
            this.tsmiRoomReserve.Text = "Резервация";
            this.tsmiRoomReserve.Click += new System.EventHandler(this.tsmiRoomReserve_Click);
            // 
            // tsmiRoomRegister
            // 
            this.tsmiRoomRegister.Name = "tsmiRoomRegister";
            this.tsmiRoomRegister.Size = new System.Drawing.Size(168, 22);
            this.tsmiRoomRegister.Text = "Регистрация";
            this.tsmiRoomRegister.Click += new System.EventHandler(this.tsmiRoomRegister_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 6);
            // 
            // tsmiRoomProperty
            // 
            this.tsmiRoomProperty.Name = "tsmiRoomProperty";
            this.tsmiRoomProperty.Size = new System.Drawing.Size(168, 22);
            this.tsmiRoomProperty.Text = "Характеристика";
            this.tsmiRoomProperty.Click += new System.EventHandler(this.tsmiRoomProperty_Click);
            // 
            // tsmiRoomClean
            // 
            this.tsmiRoomClean.Name = "tsmiRoomClean";
            this.tsmiRoomClean.Size = new System.Drawing.Size(168, 22);
            this.tsmiRoomClean.Text = "Почистена";
            this.tsmiRoomClean.Click += new System.EventHandler(this.tsmiRoomClean_Click);
            // 
            // DataGridHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Name = "DataGridHotel";
            this.Size = new System.Drawing.Size(565, 170);
            this.Resize += new System.EventHandler(this.ReservationGrid_Resize);
            this.cntxtMnStrp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cntxtMnStrp;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoomReserve;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoomRegister;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoomProperty;
        private System.Windows.Forms.ToolTip tTip;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoomClean;

    }
}
