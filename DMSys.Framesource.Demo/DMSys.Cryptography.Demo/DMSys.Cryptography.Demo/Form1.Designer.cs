namespace DMSys.Cryptography.Demo
{
    partial class Form1
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
            this.btn_Encrypt3DES192 = new System.Windows.Forms.Button();
            this.lbl_Text = new System.Windows.Forms.Label();
            this.tb_Text = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.tb_InitializationVector = new System.Windows.Forms.TextBox();
            this.lbl_InitializationVector = new System.Windows.Forms.Label();
            this.tb_EncryptText = new System.Windows.Forms.TextBox();
            this.btn_Decrypt3DES192 = new System.Windows.Forms.Button();
            this.tb_DecryptText = new System.Windows.Forms.TextBox();
            this.btn_Encrypt3DES = new System.Windows.Forms.Button();
            this.btn_Decrypt3DES = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Encrypt3DES192
            // 
            this.btn_Encrypt3DES192.Location = new System.Drawing.Point(12, 90);
            this.btn_Encrypt3DES192.Name = "btn_Encrypt3DES192";
            this.btn_Encrypt3DES192.Size = new System.Drawing.Size(120, 23);
            this.btn_Encrypt3DES192.TabIndex = 6;
            this.btn_Encrypt3DES192.Text = "Encrypt 3DES 192";
            this.btn_Encrypt3DES192.UseVisualStyleBackColor = true;
            this.btn_Encrypt3DES192.Click += new System.EventHandler(this.btn_Encrypt3DES192_Click);
            // 
            // lbl_Text
            // 
            this.lbl_Text.AutoSize = true;
            this.lbl_Text.Location = new System.Drawing.Point(9, 15);
            this.lbl_Text.Name = "lbl_Text";
            this.lbl_Text.Size = new System.Drawing.Size(28, 13);
            this.lbl_Text.TabIndex = 0;
            this.lbl_Text.Text = "Text";
            // 
            // tb_Text
            // 
            this.tb_Text.Location = new System.Drawing.Point(68, 12);
            this.tb_Text.Name = "tb_Text";
            this.tb_Text.Size = new System.Drawing.Size(300, 20);
            this.tb_Text.TabIndex = 1;
            this.tb_Text.Text = "20151201TpNDlGYSavVnv7x";
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(68, 38);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(300, 20);
            this.tb_Password.TabIndex = 3;
            this.tb_Password.Text = "DispBills9211";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(9, 41);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 2;
            this.lbl_Password.Text = "Password";
            // 
            // tb_InitializationVector
            // 
            this.tb_InitializationVector.Location = new System.Drawing.Point(118, 64);
            this.tb_InitializationVector.Name = "tb_InitializationVector";
            this.tb_InitializationVector.Size = new System.Drawing.Size(250, 20);
            this.tb_InitializationVector.TabIndex = 5;
            this.tb_InitializationVector.Text = "password";
            // 
            // lbl_InitializationVector
            // 
            this.lbl_InitializationVector.AutoSize = true;
            this.lbl_InitializationVector.Location = new System.Drawing.Point(9, 67);
            this.lbl_InitializationVector.Name = "lbl_InitializationVector";
            this.lbl_InitializationVector.Size = new System.Drawing.Size(94, 13);
            this.lbl_InitializationVector.TabIndex = 4;
            this.lbl_InitializationVector.Text = "Initialization vector";
            // 
            // tb_EncryptText
            // 
            this.tb_EncryptText.Location = new System.Drawing.Point(12, 119);
            this.tb_EncryptText.Name = "tb_EncryptText";
            this.tb_EncryptText.Size = new System.Drawing.Size(356, 20);
            this.tb_EncryptText.TabIndex = 7;
            // 
            // btn_Decrypt3DES192
            // 
            this.btn_Decrypt3DES192.Location = new System.Drawing.Point(12, 145);
            this.btn_Decrypt3DES192.Name = "btn_Decrypt3DES192";
            this.btn_Decrypt3DES192.Size = new System.Drawing.Size(120, 23);
            this.btn_Decrypt3DES192.TabIndex = 8;
            this.btn_Decrypt3DES192.Text = "Decrypt 3DES 192";
            this.btn_Decrypt3DES192.UseVisualStyleBackColor = true;
            this.btn_Decrypt3DES192.Click += new System.EventHandler(this.btn_Decrypt3DES192_Click);
            // 
            // tb_DecryptText
            // 
            this.tb_DecryptText.Location = new System.Drawing.Point(12, 174);
            this.tb_DecryptText.Name = "tb_DecryptText";
            this.tb_DecryptText.Size = new System.Drawing.Size(356, 20);
            this.tb_DecryptText.TabIndex = 9;
            // 
            // btn_Encrypt3DES
            // 
            this.btn_Encrypt3DES.Location = new System.Drawing.Point(138, 90);
            this.btn_Encrypt3DES.Name = "btn_Encrypt3DES";
            this.btn_Encrypt3DES.Size = new System.Drawing.Size(100, 23);
            this.btn_Encrypt3DES.TabIndex = 10;
            this.btn_Encrypt3DES.Text = "Encrypt 3DES";
            this.btn_Encrypt3DES.UseVisualStyleBackColor = true;
            this.btn_Encrypt3DES.Click += new System.EventHandler(this.btn_Encrypt3DES_Click);
            // 
            // btn_Decrypt3DES
            // 
            this.btn_Decrypt3DES.Location = new System.Drawing.Point(138, 145);
            this.btn_Decrypt3DES.Name = "btn_Decrypt3DES";
            this.btn_Decrypt3DES.Size = new System.Drawing.Size(100, 23);
            this.btn_Decrypt3DES.TabIndex = 11;
            this.btn_Decrypt3DES.Text = "Decrypt 3DES";
            this.btn_Decrypt3DES.UseVisualStyleBackColor = true;
            this.btn_Decrypt3DES.Click += new System.EventHandler(this.btn_Decrypt3DES_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 253);
            this.Controls.Add(this.btn_Decrypt3DES);
            this.Controls.Add(this.btn_Encrypt3DES);
            this.Controls.Add(this.tb_DecryptText);
            this.Controls.Add(this.btn_Decrypt3DES192);
            this.Controls.Add(this.tb_EncryptText);
            this.Controls.Add(this.tb_InitializationVector);
            this.Controls.Add(this.lbl_InitializationVector);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.tb_Text);
            this.Controls.Add(this.lbl_Text);
            this.Controls.Add(this.btn_Encrypt3DES192);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Encrypt3DES192;
        private System.Windows.Forms.Label lbl_Text;
        private System.Windows.Forms.TextBox tb_Text;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox tb_InitializationVector;
        private System.Windows.Forms.Label lbl_InitializationVector;
        private System.Windows.Forms.TextBox tb_EncryptText;
        private System.Windows.Forms.Button btn_Decrypt3DES192;
        private System.Windows.Forms.TextBox tb_DecryptText;
        private System.Windows.Forms.Button btn_Encrypt3DES;
        private System.Windows.Forms.Button btn_Decrypt3DES;
    }
}

