using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls.Forms
{
    public partial class FWaitForm_2 : Form
    {
        public FWaitForm_2()
        {
            InitializeComponent();
        }

        public void WF_Open( int lngPrgBar )
        {
            lbMsg.Text = "";
            progressBar.Minimum = 0;
            progressBar.Maximum = lngPrgBar;
            progressBar.Step = 1;
            this.Show();
        }

        public void WF_SetNew(int lngPrgBar)
        {
            lbMsg.Text = "";
            progressBar.Minimum = 0;
            progressBar.Maximum = lngPrgBar;
            progressBar.Step = 1;
        }

        public void WF_Close()
        {
            this.Close();
        }

        public void WF_Message(string Wait_Message)
        {
            WF_Message( Wait_Message, true );
        }

        public void WF_Message(string Wait_Message, bool IsStep )
        {
            if (IsStep)
            {
                progressBar.PerformStep();
            }
            lbMsg.Text = Wait_Message;
            GC.Collect();
            Refresh();
        }

        public void WF_PerformStep()
        {
            progressBar.PerformStep();
            progressBar.Refresh();
        }
    }
}