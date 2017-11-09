namespace DMSys.Controls.Forms
{
    partial class FAppRegistration
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
            this.tb_ApplicationID = new System.Windows.Forms.TextBox();
            this.lbl_ApplicationID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_RegistrationNumber = new System.Windows.Forms.TextBox();
            this.btn_Register = new System.Windows.Forms.Button();
            this.crypto = new DMSys.Cryptography.CryptoSymmetric(this.components);
            this.SuspendLayout();
            // 
            // tb_ApplicationID
            // 
            this.tb_ApplicationID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ApplicationID.Location = new System.Drawing.Point(122, 12);
            this.tb_ApplicationID.Name = "tb_ApplicationID";
            this.tb_ApplicationID.ReadOnly = true;
            this.tb_ApplicationID.Size = new System.Drawing.Size(370, 20);
            this.tb_ApplicationID.TabIndex = 0;
            // 
            // lbl_ApplicationID
            // 
            this.lbl_ApplicationID.AutoSize = true;
            this.lbl_ApplicationID.Location = new System.Drawing.Point(12, 15);
            this.lbl_ApplicationID.Name = "lbl_ApplicationID";
            this.lbl_ApplicationID.Size = new System.Drawing.Size(76, 13);
            this.lbl_ApplicationID.TabIndex = 1;
            this.lbl_ApplicationID.Text = "Application ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Registration number:";
            // 
            // tb_RegistrationNumber
            // 
            this.tb_RegistrationNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_RegistrationNumber.Location = new System.Drawing.Point(122, 38);
            this.tb_RegistrationNumber.Name = "tb_RegistrationNumber";
            this.tb_RegistrationNumber.Size = new System.Drawing.Size(370, 20);
            this.tb_RegistrationNumber.TabIndex = 3;
            // 
            // btn_Register
            // 
            this.btn_Register.Location = new System.Drawing.Point(417, 64);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(75, 23);
            this.btn_Register.TabIndex = 4;
            this.btn_Register.Text = "Register";
            this.btn_Register.UseVisualStyleBackColor = true;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // crypto
            // 
            this.crypto.CalculateKey = false;
            this.crypto.CryptoType = DMSys.Cryptography.CryptoSymmetric.CryptoTypes.TripleDES_192;
            this.crypto.InitializationVector = "";
            this.crypto.Password = "abcd!@#";
            this.crypto.StringFormat = DMSys.Cryptography.StringFormats.HEX;
            // 
            // FAppRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 98);
            this.Controls.Add(this.btn_Register);
            this.Controls.Add(this.tb_RegistrationNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_ApplicationID);
            this.Controls.Add(this.tb_ApplicationID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FAppRegistration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_ApplicationID;
        private System.Windows.Forms.Label lbl_ApplicationID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_RegistrationNumber;
        private System.Windows.Forms.Button btn_Register;
        private Cryptography.CryptoSymmetric crypto;
    }
}