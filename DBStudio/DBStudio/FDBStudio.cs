using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBStudio.Generate;
using System.IO;

namespace DBStudio
{
    public partial class FDBStudio : Form
    {
        private DBStudioData _SData = new DBStudioData();

        public FDBStudio()
        {
            InitializeComponent();

            _SData.ApplicationPath = Path.GetDirectoryName(Application.ExecutablePath);
            // SQLite
            string dbPathStructure = Path.Combine(_SData.ApplicationPath, "Structure.db");
            string connectionString = DBUtilsSQLite.ConnectionString(dbPathStructure, 3); 
            _SData.DBConfig = new DBConfigSQLite(connectionString);
        }

        private void FBowler_Load(object sender, EventArgs e)
        {
            // Избира база за работа
            using (FConnections fConnections = new FConnections(_SData))
            {
                if (fConnections.ShowForm() != System.Windows.Forms.DialogResult.OK)
                { return; }
            }
            // Премахва старите табове
            tc_DBStudio.TabPages.Clear();
            // Зарежда данните за базата
            LoadTVTables();
        }

        /// <summary>
        /// Зарежда дървото с таблици
        /// </summary>
        private void LoadTVTables()
        {
            tv_Tables.Nodes.Clear();
            DataTable dtTables = _SData.DBConfig.GetTables(_SData.DBSysID);
            foreach(DataRow dr in dtTables.Rows)
            {
                TreeNode tn_Table = new TreeNode();
                tn_Table.Text = dr["T_CAPTION"].ToString();
                tn_Table.Name = dr["T_NAME"].ToString();
                tn_Table.Tag = dr["ID"].ToString();
                tn_Table.ContextMenu = cm_Tables;

                tv_Tables.Nodes.Add(tn_Table);
            }
        }

        private void tv_Tables_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Int32 tableID = 0;
            Int32.TryParse(e.Node.Tag.ToString(), out tableID);

            UCListView listView = new UCListView(_SData);
            listView.LoadData(tableID);
            
            // _LoadedControl = listView;
            AddTabControl("Преглед", listView);
        }

        private void tsb_NewTable_Click(object sender, EventArgs e)
        {
            try
            {
                UCTable newTable = new UCTable(_SData);
                newTable.Init();

                AddTabControl("Нова таблица", newTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Добавя нов таб
        /// </summary>
        private void AddTabControl(string tabText, UCDBStudio ucDBStudio)
        {
            TabPage tabPage = new TabPage();
            if (ucDBStudio.Caption == "")
            { tabPage.Text = tabText; }
            else
            { tabPage.Text = ucDBStudio.Caption; }
            // Добавя контрола
            if (ucDBStudio != null)
            {
                tabPage.Controls.Add(ucDBStudio);
                ucDBStudio.Dock = DockStyle.Fill;
            }
            // Добавя таба и го селектира
            tc_DBStudio.TabPages.Add(tabPage);
            tc_DBStudio.SelectedTab = tabPage;
        }

        private void tc_DBStudio_TabClosed(object sender, DMSys.Controls.TabClosedEventArgs e)
        {
            // Може ли да се затвори
        }

        #region Table Menu

        private void mi_TableDesign_Click(object sender, EventArgs e)
        {
            try
            {
                string tableText = tv_Tables.SelectedNode.Text;
                string tableName = tv_Tables.SelectedNode.Name;
                Int32 tableID = 0;
                Int32.TryParse(tv_Tables.SelectedNode.Tag.ToString(), out tableID);

                UCTable editTable = new UCTable(_SData);
                editTable.Init(tableID);

                AddTabControl(tableText, editTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mi_TableDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string tableText = tv_Tables.SelectedNode.Text;
                string tableName = tv_Tables.SelectedNode.Name;
                Int32 tableID = 0;
                Int32.TryParse(tv_Tables.SelectedNode.Tag.ToString(), out tableID);

                string msgText = "Таблица '"+tableText+"/"+tableName+"' да бъде ли изтрита?";
                if (MessageBox.Show(msgText, "Изтриване на таблица", MessageBoxButtons.YesNo) 
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    if (_SData.DBConfig.DeleteTable(tableID))
                    {
                        LoadTVTables();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion Table Menu
    }
}
