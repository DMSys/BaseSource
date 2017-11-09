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

namespace DMSys.Data.SQLite.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestSqlite_Click(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.GetDirectoryName(Application.ExecutablePath);

                var db = new Mono.Data.Sqlite.SqliteConnection("URI=file:" + Path.Combine(dbPath, "test.db"));

                db.Open();

                db.Close();

                MessageBox.Show("ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public class Stock
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            [MaxLength(8)]
            public string Symbol { get; set; }
        }
    }
}
