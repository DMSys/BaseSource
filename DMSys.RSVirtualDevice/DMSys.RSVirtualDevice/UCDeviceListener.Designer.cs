namespace DMSys.RSVirtualDevice
{
    partial class UCDeviceListener
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
            this.lblComNo = new System.Windows.Forms.Label();
            this.nudComNo = new System.Windows.Forms.NumericUpDown();
            this.bgwReader = new System.ComponentModel.BackgroundWorker();
            this.sPort = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudComNo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblComNo
            // 
            this.lblComNo.AutoSize = true;
            this.lblComNo.Location = new System.Drawing.Point(3, 5);
            this.lblComNo.Name = "lblComNo";
            this.lblComNo.Size = new System.Drawing.Size(45, 13);
            this.lblComNo.TabIndex = 4;
            this.lblComNo.Text = "Com No";
            // 
            // nudComNo
            // 
            this.nudComNo.Location = new System.Drawing.Point(120, 3);
            this.nudComNo.Name = "nudComNo";
            this.nudComNo.Size = new System.Drawing.Size(120, 20);
            this.nudComNo.TabIndex = 3;
            this.nudComNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bgwReader
            // 
            this.bgwReader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwReader_DoWork);
            this.bgwReader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwReader_RunWorkerCompleted);
            // 
            // UCDeviceListener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblComNo);
            this.Controls.Add(this.nudComNo);
            this.Name = "UCDeviceListener";
            this.Size = new System.Drawing.Size(544, 137);
            ((System.ComponentModel.ISupportInitialize)(this.nudComNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComNo;
        private System.Windows.Forms.NumericUpDown nudComNo;
        private System.ComponentModel.BackgroundWorker bgwReader;
        private System.IO.Ports.SerialPort sPort;
    }
}
