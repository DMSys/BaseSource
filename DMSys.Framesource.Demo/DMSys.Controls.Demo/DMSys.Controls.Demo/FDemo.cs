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

            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(String));
            dt.Columns.Add("Value", typeof(String));
            dt.Rows.Add("item 1", 100);
            dt.Rows.Add("item 2", 200);
            dt.Rows.Add("item 3", 300);
            dt.Rows.Add("item 4", 400);

            checkedListBox1.DataSource = dt;
            checkedListBox1.DisplayMember = "Text";
            checkedListBox1.ValueMember = "Value";
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

        private void btn_SetCheckedList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void btn_GetCheckedList_Click(object sender, EventArgs e)
        {
            List<string> sel = new List<string>();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                DataRowView v = (DataRowView)checkedListBox1.CheckedItems[i];
                sel.Add(v["Value"].ToString());
            }
        }

        private T CastTo<T>(object value, T targetType)
        {
            // targetType above is just for compiler magic
            // to infer the type to cast value to
            return (T)value;
        }
    }
}
