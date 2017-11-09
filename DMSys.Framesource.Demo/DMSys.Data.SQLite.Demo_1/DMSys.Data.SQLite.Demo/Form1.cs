using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace DMSys.Data.SQLite.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string file = @"D:\DProjects\DAndreev\OSGamePlayer\OSGamePlayer\bin\Release\OSGamePlayer.db";
            //string file = @"D:\DProjects\TestPrjcts\WindowsFormsApplication_SQLite\WindowsFormsApplication_SQLite\bin\Debug\SqliteTest3.db";
            string password = "test123";
            string file = @"D:\DProjects\DMSys.SourceForge\DMSys.Framesource.Demo\DMSys.Data.SQLite.Demo_\DMSys.Data.SQLite.Demo\bin\OSGamePlayer.db";
            
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection())
                {
                    // Data Source=filename;Version=3;Password=myPassword;
                    conn.ConnectionString =
                        "Data Source="+file+";Version=3";
                        //",password=" + password + ";";

                    conn.SetPassword(password);

                    conn.Open();

                    conn.ChangePassword("");
                    /*
                    using (SqliteCommand command = new SqliteCommand())
                    {
                        command.Connection = conn;
                        
                        //command.CommandText = "pragma key = '" + password + "';";
                        command.CommandText = "pragma key = 'test123';";
                        command.ExecuteNonQuery();

                        /*
                        command.CommandText = "PRAGMA cipher = 'aes-256-cfb';";
                        command.ExecuteNonQuery();

                        command.CommandText = "PRAGMA kdf_iter = '10000';";
                        command.ExecuteNonQuery();

                        command.CommandText = "PRAGMA cipher_default_kdf_iter = 4000;";
                        command.ExecuteNonQuery();

                        command.CommandText = "PRAGMA cipher_page_size = 4096;";
                        command.ExecuteNonQuery();
                        
                        * /

                        command.CommandText = 
@"ATTACH DATABASE 'OSGamePlayer.db' AS plaintext KEY '';
-- SELECT sqlcipher_export('plaintext');
DETACH DATABASE plaintext; ";
                        command.ExecuteNonQuery();

                        //command.CommandText = "pragma lic = '';";
                        //command.ExecuteNonQuery();
                        
                        //command.CommandText = "pragma rekey = '" + password + "';";
                        //command.CommandText = "pragma rekey = '';";
                        //command.CommandText = "pragma rekey = 'test123';";
                        //command.ExecuteNonQuery();
                        
                        command.CommandText = "SELECT COUNT(*) FROM dispbills";
                        MessageBox.Show(command.ExecuteScalar().ToString());
                    }*/
                    conn.Close();
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
