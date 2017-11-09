using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBStudio.Generate;

namespace DBStudio
{
    public partial class UCTable : UCDBStudio
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

        public UCTable(DBStudioData studioData)
        {
            InitializeComponent();
            _SData = studioData;
        }

        /// <summary>
        /// Нова таблица
        /// </summary>
        public void Init()
        {
            _TableID = 0;
            LoadVisualComponent();
            LoadDDL_DBTables();
        }

        /// <summary>
        /// Редакция на таблица записана в БД
        /// </summary>
        public void Init(int tableID)
        {
            _TableID = tableID;
            LoadVisualComponent();
            // Зарежда основните данни на таблицата
            DBTable table = _SData.DBConfig.GetTable(tableID);
            base.Caption = table.Caption;
            // Колонките на таблицата
            LoadDDL_Tables(table.Name);
            LoadGrid_TableColumns(table.Columns);
        }

        #region Private Method

        /// <summary>
        /// Зарежда таблицата с визуални компоненти
        /// </summary>
        private void LoadVisualComponent()
        {
            string[] names = Enum.GetNames(typeof(VisualComponent));
            for (int i = 0; i < names.Length; i++)
            {
                DataRow drTVC = dtTVComponent.NewRow();
                drTVC["VComponentID"] = i;
                drTVC["VComponentName"] = names[i];
                dtTVComponent.Rows.Add(drTVC);
            }
        }

        /// <summary>
        /// Зарежда списък на таблиците
        /// </summary>
        private void LoadDDL_DBTables()
        {
            cb_Table.Enabled = true;
            cb_Table.Items.Clear();
            List<string> tables = _SData.DBSys.GetTables();
            foreach (string table in tables)
            {
                cb_Table.Items.Add(table);
            }
        }

        /// <summary>
        /// Зарежда таблицата в ComboBox-a
        /// </summary>
        private void LoadDDL_Tables(string tableName)
        {
            cb_Table.Enabled = false;
            cb_Table.Items.Clear();
            cb_Table.Items.Add(tableName);
            cb_Table.SelectedIndex = 0;

            LoadGridDDL_DBTableColumns(tableName);
        }

        /// <summary>
        /// Зарежда грида с колонките на таблицата
        /// </summary
        private void LoadGrid_DBTableColumns(string tableName)
        {
            List<DBTableColumn> columns = _SData.DBSys.GetTableColumns(tableName);
            LoadGrid_TableColumns(columns);
        }

        /// <summary>
        /// Зарежда ComboBox-a на грида с колонките на избраната таблица
        /// </summary
        private void LoadGridDDL_DBTableColumns(string tableName)
        {
            List<DBTableColumn> columns = _SData.DBSys.GetTableColumns(tableName);
            LoadGridDDL_TableColumns(columns);
        }

        /// <summary>
        /// Зарежда грида с колонките на таблицата
        /// </summary>
        /// <param name="columns"></param>
        private void LoadGrid_TableColumns(List<DBTableColumn> columns)
        {
            dtTColumns.Rows.Clear();
            foreach (DBTableColumn col in columns)
            {
                DataRow drRow = dtTColumns.NewRow();
                drRow["CID"] = col.Id;
                drRow["CName"] = col.Name;
                drRow["CText"] = col.Caption;
                drRow["CDataType"] = col.DataType;
                drRow["CVComponent"] = (int)col.VComponent;
                dtTColumns.Rows.Add(drRow);
            }
        }

        /// <summary>
        /// Зарежда ComboBox-a на грида с колонките на избраната таблица
        /// </summary
        private void LoadGridDDL_TableColumns(List<DBTableColumn> columns)
        {
            dtTColumnNames.Rows.Clear();
            foreach (DBTableColumn col in columns)
            {
                DataRow drCol = dtTColumnNames.NewRow();
                drCol["ColumnName"] = col.Name;
                dtTColumnNames.Rows.Add(drCol);
            }
        }

        #endregion Private Method

        private void cb_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_TableID == 0)
                {
                    dtTColumns.Rows.Clear();
                    string tebleName = cb_Table.Text.Trim();
                    tb_Caption.Text = tebleName;
                    LoadGridDDL_DBTableColumns(tebleName);
                    LoadGrid_DBTableColumns(tebleName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Записва таблицата в БД
        /// </summary>
        private void tsb_Save_Click(object sender, EventArgs e)
        {
            DBTable table = new DBTable();
            table.Caption = tb_Caption.Text;
            table.Name = cb_Table.Text;

            foreach(DataRow drColumn in dtTColumns.Rows)
            {
                DBTableColumn column = new DBTableColumn();
                Int32.TryParse(drColumn["CID"].ToString(), out column.Id);
                column.Name = drColumn["CName"].ToString();
                column.Caption = drColumn["CText"].ToString();
                column.DataType = drColumn["CDataType"].ToString();
                int CVComponent = 0;
                Int32.TryParse(drColumn["CVComponent"].ToString(), out CVComponent);
                column.VComponent = (VisualComponent)CVComponent;
                table.Columns.Add(column);
            }
            _SData.DBConfig.SetTable(_SData.DBSysID, _TableID, table); 
        }

        private void dgv_TColumns_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
            {
                DataGridViewComboBoxEditingControl combo = e.Control as DataGridViewComboBoxEditingControl;
                combo.DropDownStyle = ComboBoxStyle.DropDown;
                combo.TextChanged += new EventHandler(combo_TextChanged);
            }
        }

        private void combo_TextChanged(object sender, EventArgs e)
        {
            this.dgv_TColumns.NotifyCurrentCellDirty(true);
        }

        private void dgv_TColumns_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (dgv_TColumns.Columns[e.ColumnIndex].Name == "CName")
            {
                string eValue = e.Value.ToString().Trim().ToUpper();
                // Проверява дали колона с такова име съществува
                bool isExist = false;
                foreach (DataRow drCName in dtTColumnNames.Rows)
                {
                    if (drCName["ColumnName"].ToString().Trim().ToUpper().Equals(eValue))
                    { isExist = true; }
                }
                // Ако не същесвува се добавя
                if (!isExist)
                {
                    DataRow dr = dtTColumnNames.NewRow();
                    dr["ColumnName"] = e.Value.ToString().Trim();
                    dtTColumnNames.Rows.Add(dr);
                }
            }
        }

        /// <summary>
        /// Изтрива ред от таблицата
        /// </summary>
        private void tsb_DeleteRow_Click(object sender, EventArgs e)
        {
            if (dgv_TColumns.CurrentRow != null)
            {
                int currentRowIndex = dgv_TColumns.CurrentRow.Index;
                dtTColumns.Rows.RemoveAt(currentRowIndex);
            }
        }

        /// <summary>
        /// Премесва реда нагоре
        /// </summary>
        private void tsb_UpRow_Click(object sender, EventArgs e)
        {
            if (dgv_TColumns.CurrentRow != null)
            {
                int currentRowIndex = dgv_TColumns.CurrentRow.Index;
                if ( (currentRowIndex > 0)
                   && (currentRowIndex < dtTColumns.Rows.Count))
                {
                    MoveRow(currentRowIndex, currentRowIndex - 1);
                }
            }
        }

        /// <summary>
        /// Премесва реда надолу
        /// </summary>
        private void tsb_DownRow_Click(object sender, EventArgs e)
        {
            if (dgv_TColumns.CurrentRow != null)
            {
                int currentRowIndex = dgv_TColumns.CurrentRow.Index;
                if (currentRowIndex < dtTColumns.Rows.Count - 1)
                {
                    MoveRow(currentRowIndex, currentRowIndex + 1);
                }
            }
        }

        /// <summary>
        /// Премесва ред
        /// </summary>
        private void MoveRow(int fromIndex, int toIndex)
        {
            DataRow drNew = dtTColumns.NewRow();
            drNew.ItemArray = dtTColumns.Rows[fromIndex].ItemArray;
            dtTColumns.Rows.RemoveAt(fromIndex);
            dtTColumns.Rows.InsertAt(drNew, toIndex);

            dgv_TColumns.CurrentCell = dgv_TColumns.Rows[toIndex].Cells[dgv_TColumns.CurrentCell.ColumnIndex];
        }
    }
}
