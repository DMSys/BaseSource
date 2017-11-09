using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls.Forms
{
    public partial class FFind_DataGrid : Form
    {
        private DataGridView gDataView = null;
        private DataTable tDataView = null;
        private DataTable dtHeaderCol = new DataTable();
        private string sFindValue = "";

        public FFind_DataGrid()
        {
            InitializeComponent();
            //
            dtHeaderCol.Columns.Add("HeaderText");
            dtHeaderCol.Columns.Add("ColumnIndex");
            cbHeaderCol.DisplayMember = "HeaderText";
            cbHeaderCol.ValueMember = "ColumnIndex";
        }

        public void Execute( DataGridView aDGridView )
        {
            gDataView = aDGridView;

            if (gDataView.DataSource != null)
            {
                if (gDataView.DataSource.GetType().Equals(typeof(BindingSource)))
                {
                    BindingSource bs = ((BindingSource)gDataView.DataSource);
                    tDataView = ((DataTable)((DataSet)bs.DataSource).Tables[bs.DataMember]);
                }
                else if (gDataView.DataSource.GetType().Equals(typeof(DataView)))
                {
                    tDataView = ((DataTable)((DataView)gDataView.DataSource).Table);
                }
                else
                {
                    MessageBox.Show("Грешен тип на данните '" + gDataView.DataSource.GetType() + "' !");
                    return;
                }
            }
            else
                tDataView = null;
            //
            dtHeaderCol.Rows.Clear();
            foreach (DataGridViewColumn DataCol in gDataView.Columns)
            {
                if (DataCol.Visible && (!DataCol.DataPropertyName.Equals("")) )
                {
                    dtHeaderCol.Rows.Add(DataCol.HeaderText, DataCol.Index);
                }
            }
            cbHeaderCol.DataSource = dtHeaderCol;
            if (dtHeaderCol.Rows.Count > 0)
            {
                cbHeaderCol.SelectedValue = gDataView.CurrentCell.ColumnIndex;
            }
            //
            Show();
        }

        private void FFind_DataGrid_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //
            if (cbHeaderCol.SelectedIndex == -1)
            {
                MessageBox.Show("Избери колона за търсене !");
                return;
            }
            //
            sFindValue = tbFindValue.Text.Trim().ToUpper();
            if (sFindValue.Length == 0 )
            {
                MessageBox.Show("Въведи критерий за търсене !");
                return;
            }
            //
            Int32 ColId = Convert.ToInt32(cbHeaderCol.SelectedValue);
            Int32 RowId = Find_String(gDataView.Columns[ColId].DataPropertyName);
            if ( RowId!=-1 )
                gDataView.CurrentCell = gDataView[ColId, RowId];
        }

        private Int32 Find_String(string ColName)
        {
            // Търси от маркираната позиция към края
            for (int i = (gDataView.CurrentRow.Index+1); i < tDataView.Rows.Count; i++)
            {
                if (Exist_Value(tDataView.Rows[i][ColName].ToString().ToUpper()))
                    return i;
            }
            // От началото към маркираната позиция
            for (int i = 0; i < gDataView.CurrentRow.Index; i++)
            {
                if (Exist_Value(tDataView.Rows[i][ColName].ToString().ToUpper()))
                    return i;
            }
            return -1;
        }

        private bool Exist_Value( string sValue )
        {
            for (int y = 0; y < ((sValue.Length - sFindValue.Length) + 1); y++)
            {
                if (sValue.Substring(y, sFindValue.Length).Equals(sFindValue))
                    return true;
            }            
            return false;
        }
    }
}