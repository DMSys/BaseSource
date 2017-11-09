using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBStudio.Generate
{
    public partial class UCListView : UCDBStudio
    {
        #region Properties

        private DBStudioData _SData = null;

        private bool _CanClosed = true;
        public override bool CanClosed
        {
            get
            { return _CanClosed; }
        }

        /// <summary>
        /// ID на таблица
        /// </summary>
        private int _TableID = 0;

        #endregion Properties

        public UCListView(DBStudioData studioData)
        {
            InitializeComponent();
            dgv_DataList.AutoGenerateColumns = false;
            _SData = studioData;
        }

        public void LoadData(int tableID)
        {
            _TableID = tableID;
            DBTable table = _SData.DBConfig.GetTable(_TableID);
            base.Caption = table.Caption;

            DataTable dtColumns = new DataTable();
            string sqlColumns = "";
            foreach (DBTableColumn column in table.Columns)
            {
                // Добавя колони към таблицата
                DataColumn dColumn = new DataColumn();
                dColumn.ColumnName = column.Name;
                dColumn.Caption = column.Caption;
                dtColumns.Columns.Add(dColumn);
                // Добавя колони към грида
                DataGridViewColumn dgvColumn = new DataGridViewTextBoxColumn();
                dgvColumn.Name = column.Name;
                dgvColumn.HeaderText = column.Caption;
                dgvColumn.DataPropertyName = column.Name;
                dgv_DataList.Columns.Add(dgvColumn);
                // Добавя колони към селекта
                if (sqlColumns == "")
                { sqlColumns = column.Name; }
                else
                { sqlColumns += " ," + column.Name; }
            }
            _SData.DBSys.FillTable(dtColumns, sqlColumns, table.Name);
            dgv_DataList.DataSource = dtColumns;
        }

        private void tsb_RowEdit_Click(object sender, EventArgs e)
        {
            using (FEditTable fEdit = new FEditTable(_SData))
            {
                fEdit.ShowForm(_TableID);
            }
        }
    }
}
