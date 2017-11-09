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

namespace DBStudio
{
    public partial class FConnections : Form
    {
        private DBStudioData _SData = null;

        public FConnections(DBStudioData studioData)
        {
            InitializeComponent();
            _SData = studioData;
        }

        public DialogResult ShowForm()
        {
            try
            {
                _SData.DBConfig.FillConnections(dt_Connections);
                return ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return System.Windows.Forms.DialogResult.Abort;
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dgvrConnection = dgv_Connections.CurrentRow;
                if (!CreateConnect(dgvrConnection))
                { return; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_Connections_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvrConnection = dgv_Connections.Rows[e.RowIndex];
                if (!CreateConnect(dgvrConnection))
                { return; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private bool CreateConnect(DataGridViewRow dgvrConnection)
        {
            _SData.DBSysID = Int32.Parse(dgvrConnection.Cells["gc_C_ID"].Value.ToString());
            int typeID = Int32.Parse(dgvrConnection.Cells["gc_C_TYPE_ID"].Value.ToString());

            DataRow drConnection = _SData.DBConfig.GetConnection(_SData.DBSysID);

            // Няма откит запис
            if (drConnection == null)
            { return false; }
            // сиздава инстанция от избрания тип
            switch (typeID)
            {
                case 1:
                    _SData.DBSys = ConnectSQLite(drConnection);
                    return true;
                case 2:
                    _SData.DBSys = ConnectMSSQL(drConnection);
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Създава инстанция на SQLite
        /// </summary>
        private IDBSys ConnectSQLite(DataRow dataConnection)
        {
            int version = Int32.Parse(dataConnection["CS_PROVIDER"].ToString());
            string uriFile = dataConnection["CS_DATA_SOURCE"].ToString();
            string connectionString = DBUtilsSQLite.ConnectionString(uriFile, version);

            IDBSys dbSys = new DBSysSQLite(connectionString);
            return dbSys;
        }

        /// <summary>
        /// Създава инстанция на MSSQL
        /// </summary>
        private IDBSys ConnectMSSQL(DataRow dataConnection)
        {
            string dataSource = dataConnection["CS_DATA_SOURCE"].ToString();
            string initialCatalog = dataConnection["CS_CATALOG"].ToString();
            string securityInfo = dataConnection["CS_SECURITY"].ToString();
            string userID = dataConnection["CS_USERNAME"].ToString();
            string password = dataConnection["CS_PASSWORD"].ToString();

            string connectionString = DBUtilsMSSQL.ConnectionString(dataSource, initialCatalog
                                                                , securityInfo, userID, password);

            IDBSys dbSys = new DBSysMSSQL(connectionString);
            return dbSys;
        }
    }
}
