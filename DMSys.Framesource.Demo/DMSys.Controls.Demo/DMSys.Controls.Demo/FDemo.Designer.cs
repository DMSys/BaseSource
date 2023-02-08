namespace DMSys.Controls.Demo
{
    partial class FDemo
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
            this.btn_PrintTable = new System.Windows.Forms.Button();
            this.btn_DataGridView = new System.Windows.Forms.Button();
            this.btn_SetCheckedList = new System.Windows.Forms.Button();
            this.btn_GetCheckedList = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btn_PrintTable
            // 
            this.btn_PrintTable.Location = new System.Drawing.Point(12, 12);
            this.btn_PrintTable.Name = "btn_PrintTable";
            this.btn_PrintTable.Size = new System.Drawing.Size(100, 23);
            this.btn_PrintTable.TabIndex = 0;
            this.btn_PrintTable.Text = "Print Table";
            this.btn_PrintTable.UseVisualStyleBackColor = true;
            this.btn_PrintTable.Click += new System.EventHandler(this.btn_PrintTable_Click);
            // 
            // btn_DataGridView
            // 
            this.btn_DataGridView.Location = new System.Drawing.Point(12, 41);
            this.btn_DataGridView.Name = "btn_DataGridView";
            this.btn_DataGridView.Size = new System.Drawing.Size(100, 23);
            this.btn_DataGridView.TabIndex = 1;
            this.btn_DataGridView.Text = "DataGridView";
            this.btn_DataGridView.UseVisualStyleBackColor = true;
            this.btn_DataGridView.Click += new System.EventHandler(this.btn_DataGridView_Click);
            // 
            // btn_SetCheckedList
            // 
            this.btn_SetCheckedList.Location = new System.Drawing.Point(398, 13);
            this.btn_SetCheckedList.Name = "btn_SetCheckedList";
            this.btn_SetCheckedList.Size = new System.Drawing.Size(133, 23);
            this.btn_SetCheckedList.TabIndex = 3;
            this.btn_SetCheckedList.Text = "Set CheckedList";
            this.btn_SetCheckedList.UseVisualStyleBackColor = true;
            this.btn_SetCheckedList.Click += new System.EventHandler(this.btn_SetCheckedList_Click);
            // 
            // btn_GetCheckedList
            // 
            this.btn_GetCheckedList.Location = new System.Drawing.Point(398, 43);
            this.btn_GetCheckedList.Name = "btn_GetCheckedList";
            this.btn_GetCheckedList.Size = new System.Drawing.Size(133, 23);
            this.btn_GetCheckedList.TabIndex = 4;
            this.btn_GetCheckedList.Text = "Get CheckedList";
            this.btn_GetCheckedList.UseVisualStyleBackColor = true;
            this.btn_GetCheckedList.Click += new System.EventHandler(this.btn_GetCheckedList_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "line 1",
            "line 2",
            "line 3",
            "line 4",
            "line 5"});
            this.checkedListBox1.Location = new System.Drawing.Point(210, 13);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(182, 49);
            this.checkedListBox1.TabIndex = 5;
            // 
            // FDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 341);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btn_GetCheckedList);
            this.Controls.Add(this.btn_SetCheckedList);
            this.Controls.Add(this.btn_DataGridView);
            this.Controls.Add(this.btn_PrintTable);
            this.Name = "FDemo";
            this.Text = "Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_PrintTable;
        private System.Windows.Forms.Button btn_DataGridView;
        private System.Windows.Forms.Button btn_SetCheckedList;
        private System.Windows.Forms.Button btn_GetCheckedList;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

