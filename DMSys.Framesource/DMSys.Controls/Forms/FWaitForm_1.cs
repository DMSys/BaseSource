using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls.Forms
{
    public partial class FWaitForm_1 : Form
    {
        public FWaitForm_1()
        {
            InitializeComponent();
        }

        public void Wait_Start()
        {
            Show();
            this.Refresh();
        }

        public void Wait_Stop()
        {
            Hide();
        }

        public void Set_Message( string sMsg )
        {
            lbMsg.Text = sMsg;
            lbMsg.Refresh();
        }
    }
}