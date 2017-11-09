using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls.Forms
{
    public partial class FFilter_DataGrid : Form
    {
        private DataTable FilterDataTable = new DataTable();
        private DataTable dtOper = new DataTable();
        private DataView dvFilter = null;
        private BindingSource bsFilter = null;

        public FFilter_DataGrid(DataView aFilter, DataGridView aFilterDataGrid)
        {
            InitializeComponent(aFilterDataGrid);
            dvFilter = aFilter;
        }

        public FFilter_DataGrid(BindingSource aFilter, DataGridView aFilterDataGrid)
        {
            InitializeComponent(aFilterDataGrid);
            bsFilter = aFilter;
        }

        public void InitializeComponent( DataGridView aFilterDataGrid )
        {
            InitializeComponent();
            //
            dtOper.Columns.Add("OperValue", System.Type.GetType("System.String"));
            dtOper.Columns.Add("OperText", System.Type.GetType("System.String"));
            dtOper.Rows.Add("LIKE", "LIKE");
            dtOper.Rows.Add("=", "=");
            dtOper.Rows.Add(">", ">");
            dtOper.Rows.Add(">=", ">=");
            dtOper.Rows.Add("<", "<");
            dtOper.Rows.Add("<=", "<=");
            dtOper.Rows.Add("<>", "<>");
            //
            cbOperation.DisplayMember = "OperText";
            cbOperation.ValueMember = "OperValue";
            cbOperation.DataSource = dtOper;
            //
            FilterDataTable.Columns.Add("ColumnNo", System.Type.GetType("System.Int32"));
            FilterDataTable.Columns.Add("ColumnName", System.Type.GetType("System.String"));
            FilterDataTable.Columns.Add("ColumnHeader", System.Type.GetType("System.String"));
            FilterDataTable.Columns.Add("Operation", System.Type.GetType("System.String"));
            FilterDataTable.Columns.Add("ValueData", System.Type.GetType("System.String"));
            FilterDataTable.Columns.Add("ValueType", System.Type.GetType("System.Type"));
            //
            foreach( DataGridViewColumn ColData in aFilterDataGrid.Columns )
            {
                if ( ColData.Visible && (!ColData.DataPropertyName.Equals("")) )
                    FilterDataTable.Rows.Add(ColData.DisplayIndex, ColData.DataPropertyName, ColData.HeaderText, "LIKE", "", ColData.ValueType);
            }
            dgShowFilterData.DataSource = FilterDataTable;
        }

        public void Execute()
        {            
            Show();
        }

        private void FFind_DataGrid_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        /// <summary>
        /// Скрива формата за филтриране
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// Филтрива грида
        /// </summary>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string sOperation = "";
            string sValueData = "";
            string sRowFilter = "";

            foreach (DataRow FilterRow in FilterDataTable.Rows)
            {
                sOperation = FilterRow["Operation"].ToString();
                sValueData = FilterRow["ValueData"].ToString();

                if ((sValueData != string.Empty) && (sOperation != string.Empty))
                {
                    if (sOperation.Equals("LIKE"))
                    {
                        if (FilterRow["ValueType"].ToString().Equals("System.String"))
                        {
                            if (sRowFilter == string.Empty)
                            {
                                sRowFilter = FilterRow["ColumnName"].ToString() + " " + sOperation + " '%" + sValueData + "%'";
                            }
                            else
                            {
                                sRowFilter += " AND " + FilterRow["ColumnName"].ToString() + " " + sOperation + " '%" + sValueData + "%'";
                            }
                        }
                    }
                    else
                    {
                        if (sRowFilter == string.Empty)
                        {
                            sRowFilter = FilterRow["ColumnName"].ToString() + " " + sOperation + " '" + sValueData + "'";
                        }
                        else
                        {
                            sRowFilter += " AND " + FilterRow["ColumnName"].ToString() + " " + sOperation + " '" + sValueData + "'";
                        }
                    }
                }
            }
            //
            if ( dvFilter!=null )
                dvFilter.RowFilter = sRowFilter;
            if (bsFilter != null)
                bsFilter.Filter = sRowFilter;
        }

        /// <summary>
        /// Маха филтъра на грида
        /// </summary>
        private void btnWithoutFilter_Click(object sender, EventArgs e)
        {
            if (dvFilter != null)
                dvFilter.RowFilter = "";
            if (bsFilter != null)
                bsFilter.Filter = "";
        }
    }
}