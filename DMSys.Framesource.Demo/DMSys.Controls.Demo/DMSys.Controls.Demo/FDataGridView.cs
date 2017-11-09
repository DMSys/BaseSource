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
    public partial class FDataGridView : Form
    {
        public FDataGridView()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DDataGridViewBookmark bm = dDataGridView1.Bookmark;
            dDataGridView1.DataSource = GetTable1();
            dDataGridView1.Bookmark = bm;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DDataGridViewBookmark bm = dDataGridView1.Bookmark;
            dDataGridView1.DataSource = GetTable2();
            dDataGridView1.Bookmark = bm;
        }

        private DataTable GetTable1()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("col_1");
            dt.Columns.Add("col_2");

            for (int i = 1; i < 100; i++)
            {
                dt.Rows.Add("col_1_" + i.ToString(), "col_2_" + i.ToString());
            }
            return dt;
        }

        private DataTable GetTable2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("col_1");
            dt.Columns.Add("col_2");
            dt.Columns.Add("col_3");
            dt.Columns.Add("col_4");

            for (int i = 1; i < 200; i++)
            {
                dt.Rows.Add("col_1_" + i.ToString(), "col_2_" + i.ToString()
                    , "col_3_" + i.ToString(), "col_4_" + i.ToString());
            }
            return dt;
        }
    }
}
