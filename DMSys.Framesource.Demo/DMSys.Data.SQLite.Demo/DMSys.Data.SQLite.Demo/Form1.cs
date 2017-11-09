using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DMSys.Data.SQLiteClient;

namespace DMSys.Data.SQLite.Demo
{
    public partial class Form1 : Form
    {
        private string _ApplicationPath = "";
        private string _DatabaseFilePath = "";
        private string _ConnectionString = "";

        public Form1()
        {
            InitializeComponent();
            _ApplicationPath = Path.GetDirectoryName(Application.ExecutablePath);
            _DatabaseFilePath = Path.Combine(_ApplicationPath, "test.db");
            _ConnectionString = string.Format("Version=3,uri=file:{0}", _DatabaseFilePath);
        }

        private void btn_TestSQLite_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection())
                {
                    connection.ConnectionString = _ConnectionString;
                    connection.Open();

                    var command = connection.CreateCommand();
                    
                    //command.CommandText = "PRAGMA key = 'passphrase';";
                   // command.ExecuteNonQuery();

                    command.CommandText = "PRAGMA rekey = '';";
                    //command.CommandText = "PRAGMA rekey = 'passphrase';";
                    command.ExecuteNonQuery();
                 
                    command.CommandText = "INSERT INTO t1(a, b) VALUES(1, '"+DateTime.Now.ToString()+"');";
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                MessageBox.Show("ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
