using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls.Demo
{
    public partial class FDemo : Form
    {
        public FDemo()
        {
            InitializeComponent();
        }

        private void btn_PrintTable_Click(object sender, EventArgs e)
        {
            try
            {
                using (FPrintTable pt = new FPrintTable())
                {
                    pt.ShowForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_DataGridView_Click(object sender, EventArgs e)
        {
            try
            {
                using (FDataGridView dgv = new FDataGridView())
                {
                    dgv.ShowForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
