using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls.Forms
{
    public partial class FEnterPassword : Form
    {
        public FEnterPassword()
        {
            InitializeComponent();
        }

        public string Value
        {
            set
            { tb_Password.Text = value; }
            get
            { return tb_Password.Text.Trim(); }
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void tb_Password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
