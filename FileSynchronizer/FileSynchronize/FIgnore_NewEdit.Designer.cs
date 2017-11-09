namespace FileSynchronizer
{
    partial class FIgnore_NewEdit
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
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_Ignore = new System.Windows.Forms.Label();
            this.tb_Ignore = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lbl_Type = new System.Windows.Forms.Label();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.chb_Active = new System.Windows.Forms.CheckBox();
            this.lbl_Active = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(175, 85);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 7;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_Ignore
            // 
            this.lbl_Ignore.AutoSize = true;
            this.lbl_Ignore.Location = new System.Drawing.Point(12, 15);
            this.lbl_Ignore.Name = "lbl_Ignore";
            this.lbl_Ignore.Size = new System.Drawing.Size(40, 13);
            this.lbl_Ignore.TabIndex = 0;
            this.lbl_Ignore.Text = "Ignore:";
            // 
            // tb_Ignore
            // 
            this.tb_Ignore.Location = new System.Drawing.Point(58, 12);
            this.tb_Ignore.Name = "tb_Ignore";
            this.tb_Ignore.Size = new System.Drawing.Size(192, 20);
            this.tb_Ignore.TabIndex = 1;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(94, 85);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.Location = new System.Drawing.Point(12, 41);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(34, 13);
            this.lbl_Type.TabIndex = 2;
            this.lbl_Type.Text = "Type:";
            // 
            // cb_Type
            // 
            this.cb_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Location = new System.Drawing.Point(58, 38);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(192, 21);
            this.cb_Type.TabIndex = 3;
            // 
            // chb_Active
            // 
            this.chb_Active.AutoSize = true;
            this.chb_Active.Checked = true;
            this.chb_Active.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_Active.Location = new System.Drawing.Point(58, 65);
            this.chb_Active.Name = "chb_Active";
            this.chb_Active.Size = new System.Drawing.Size(15, 14);
            this.chb_Active.TabIndex = 5;
            this.chb_Active.UseVisualStyleBackColor = true;
            // 
            // lbl_Active
            // 
            this.lbl_Active.AutoSize = true;
            this.lbl_Active.Location = new System.Drawing.Point(12, 66);
            this.lbl_Active.Name = "lbl_Active";
            this.lbl_Active.Size = new System.Drawing.Size(40, 13);
            this.lbl_Active.TabIndex = 4;
            this.lbl_Active.Text = "Active:";
            // 
            // FIgnore_NewEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 116);
            this.Controls.Add(this.lbl_Active);
            this.Controls.Add(this.chb_Active);
            this.Controls.Add(this.cb_Type);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.tb_Ignore);
            this.Controls.Add(this.lbl_Ignore);
            this.Controls.Add(this.btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FIgnore_NewEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ignore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_Ignore;
        private System.Windows.Forms.TextBox tb_Ignore;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.ComboBox cb_Type;
        private System.Windows.Forms.CheckBox chb_Active;
        private System.Windows.Forms.Label lbl_Active;
    }
}