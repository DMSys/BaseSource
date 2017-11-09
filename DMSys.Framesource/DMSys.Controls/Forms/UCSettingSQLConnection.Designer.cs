namespace DMSys.Controls.Forms
{
    partial class UCSettingSQLConnection
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
            this.lbl_Server = new System.Windows.Forms.Label();
            this.tb_Server = new System.Windows.Forms.TextBox();
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.tb_Database = new System.Windows.Forms.TextBox();
            this.lbl_Database = new System.Windows.Forms.Label();
            this.tb_UserId = new System.Windows.Forms.TextBox();
            this.lbl_UserId = new System.Windows.Forms.Label();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.tb_CommandTimeout = new System.Windows.Forms.TextBox();
            this.lbl_CommandTimeout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Server
            // 
            this.lbl_Server.AutoSize = true;
            this.lbl_Server.Location = new System.Drawing.Point(3, 6);
            this.lbl_Server.Name = "lbl_Server";
            this.lbl_Server.Size = new System.Drawing.Size(41, 13);
            this.lbl_Server.TabIndex = 0;
            this.lbl_Server.Text = "Server:";
            // 
            // tb_Server
            // 
            this.tb_Server.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Server.Location = new System.Drawing.Point(65, 3);
            this.tb_Server.Name = "tb_Server";
            this.tb_Server.Size = new System.Drawing.Size(232, 20);
            this.tb_Server.TabIndex = 1;
            // 
            // tb_Port
            // 
            this.tb_Port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Port.Location = new System.Drawing.Point(65, 29);
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.Size = new System.Drawing.Size(232, 20);
            this.tb_Port.TabIndex = 3;
            this.tb_Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Port_KeyPress);
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(3, 32);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(29, 13);
            this.lbl_Port.TabIndex = 2;
            this.lbl_Port.Text = "Port:";
            // 
            // tb_Database
            // 
            this.tb_Database.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Database.Location = new System.Drawing.Point(65, 55);
            this.tb_Database.Name = "tb_Database";
            this.tb_Database.Size = new System.Drawing.Size(232, 20);
            this.tb_Database.TabIndex = 5;
            // 
            // lbl_Database
            // 
            this.lbl_Database.AutoSize = true;
            this.lbl_Database.Location = new System.Drawing.Point(3, 58);
            this.lbl_Database.Name = "lbl_Database";
            this.lbl_Database.Size = new System.Drawing.Size(56, 13);
            this.lbl_Database.TabIndex = 4;
            this.lbl_Database.Text = "Database:";
            // 
            // tb_UserId
            // 
            this.tb_UserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_UserId.Location = new System.Drawing.Point(65, 107);
            this.tb_UserId.Name = "tb_UserId";
            this.tb_UserId.Size = new System.Drawing.Size(232, 20);
            this.tb_UserId.TabIndex = 9;
            // 
            // lbl_UserId
            // 
            this.lbl_UserId.AutoSize = true;
            this.lbl_UserId.Location = new System.Drawing.Point(3, 110);
            this.lbl_UserId.Name = "lbl_UserId";
            this.lbl_UserId.Size = new System.Drawing.Size(44, 13);
            this.lbl_UserId.TabIndex = 8;
            this.lbl_UserId.Text = "User Id:";
            // 
            // tb_Password
            // 
            this.tb_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Password.Location = new System.Drawing.Point(65, 133);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(232, 20);
            this.tb_Password.TabIndex = 11;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(3, 136);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(56, 13);
            this.lbl_Password.TabIndex = 10;
            this.lbl_Password.Text = "Password:";
            // 
            // tb_CommandTimeout
            // 
            this.tb_CommandTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_CommandTimeout.Location = new System.Drawing.Point(65, 81);
            this.tb_CommandTimeout.Name = "tb_CommandTimeout";
            this.tb_CommandTimeout.Size = new System.Drawing.Size(232, 20);
            this.tb_CommandTimeout.TabIndex = 7;
            this.tb_CommandTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_CommandTimeout_KeyPress);
            // 
            // lbl_CommandTimeout
            // 
            this.lbl_CommandTimeout.AutoSize = true;
            this.lbl_CommandTimeout.Location = new System.Drawing.Point(3, 84);
            this.lbl_CommandTimeout.Name = "lbl_CommandTimeout";
            this.lbl_CommandTimeout.Size = new System.Drawing.Size(48, 13);
            this.lbl_CommandTimeout.TabIndex = 6;
            this.lbl_CommandTimeout.Text = "Timeout:";
            // 
            // UCSettingSQLConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb_CommandTimeout);
            this.Controls.Add(this.lbl_CommandTimeout);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.tb_UserId);
            this.Controls.Add(this.lbl_UserId);
            this.Controls.Add(this.tb_Database);
            this.Controls.Add(this.lbl_Database);
            this.Controls.Add(this.tb_Port);
            this.Controls.Add(this.lbl_Port);
            this.Controls.Add(this.tb_Server);
            this.Controls.Add(this.lbl_Server);
            this.Name = "UCSettingSQLConnection";
            this.Size = new System.Drawing.Size(308, 159);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Server;
        private System.Windows.Forms.TextBox tb_Server;
        private System.Windows.Forms.TextBox tb_Port;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.TextBox tb_Database;
        private System.Windows.Forms.Label lbl_Database;
        private System.Windows.Forms.TextBox tb_UserId;
        private System.Windows.Forms.Label lbl_UserId;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox tb_CommandTimeout;
        private System.Windows.Forms.Label lbl_CommandTimeout;
    }
}
