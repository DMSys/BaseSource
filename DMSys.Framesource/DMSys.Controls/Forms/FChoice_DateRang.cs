using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls.Forms
{
    public partial class FChoice_DataRang : Form
    {
        private bool bRes = false;

        public FChoice_DataRang()
        {
            InitializeComponent();
        }

        public bool Execute()
        {
            bRes = false;
            ShowDialog();
            return bRes;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bRes = false;
            Close();
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            bRes = true;
            Close();
        }

        public DateTime FromDate
        {
            get
            {
                return new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0, 0);
            }
        }

        public DateTime ToDate
        {
            get
            {
                DateTime dtToDate = dtpToDate.Value.AddDays(1);
                return new DateTime(dtToDate.Year, dtToDate.Month, dtToDate.Day, 0, 0, 0, 0);
            }
        }
    }
}