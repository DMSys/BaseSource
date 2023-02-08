using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMSys.Data.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                NpgsqlConnection con = new NpgsqlConnection();
                con.ConnectionString = "Server=26.185.37.127;Port=5433;Database=postgres;User Id=postgres;Password=12345678;";
                con.Open();

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
