namespace DMSys.RSVirtualDevice
{
    partial class FRSVirtualDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRSVirtualDevice));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbRSLog = new System.Windows.Forms.RichTextBox();
            this.pnlDevice = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tscbTypeDevice = new System.Windows.Forms.ToolStripComboBox();
            this.tsbStartStop = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtbRSLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 117);
            this.panel1.TabIndex = 0;
            // 
            // rtbRSLog
            // 
            this.rtbRSLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRSLog.Location = new System.Drawing.Point(0, 0);
            this.rtbRSLog.Name = "rtbRSLog";
            this.rtbRSLog.Size = new System.Drawing.Size(674, 117);
            this.rtbRSLog.TabIndex = 0;
            this.rtbRSLog.Text = "";
            // 
            // pnlDevice
            // 
            this.pnlDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDevice.Location = new System.Drawing.Point(0, 25);
            this.pnlDevice.Name = "pnlDevice";
            this.pnlDevice.Size = new System.Drawing.Size(674, 197);
            this.pnlDevice.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbTypeDevice,
            this.tsbStartStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(674, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tscbTypeDevice
            // 
            this.tscbTypeDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbTypeDevice.Items.AddRange(new object[] {
            "-= None =-",
            "Listener"});
            this.tscbTypeDevice.Name = "tscbTypeDevice";
            this.tscbTypeDevice.Size = new System.Drawing.Size(121, 25);
            this.tscbTypeDevice.SelectedIndexChanged += new System.EventHandler(this.tscbTypeDevice_SelectedIndexChanged);
            // 
            // tsbStartStop
            // 
            this.tsbStartStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStartStop.Image")));
            this.tsbStartStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStartStop.Name = "tsbStartStop";
            this.tsbStartStop.Size = new System.Drawing.Size(51, 22);
            this.tsbStartStop.Text = "Start";
            this.tsbStartStop.Click += new System.EventHandler(this.tsbStartStop_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 219);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(674, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // FRSVirtualDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 339);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlDevice);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "FRSVirtualDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RS Virtual Device";
            this.Load += new System.EventHandler(this.FRSVirtualDevice_Load);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbRSLog;
        private System.Windows.Forms.Panel pnlDevice;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbStartStop;
        private System.Windows.Forms.ToolStripComboBox tscbTypeDevice;
        private System.Windows.Forms.Splitter splitter1;
    }
}

