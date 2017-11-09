using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls.Forms
{
    public partial class UCSettingSQLConnection : UserControl
    {
        #region Properties

        public string Server
        {
            get
            { return tb_Server.Text.Trim(); }
            set
            { tb_Server.Text = value; }
        }

        public Int32 Port
        {
            get
            {
                Int32 port = 0;
                return (Int32.TryParse(tb_Port.Text.Trim(), out port) ? port : 5432);
            }
            set
            { tb_Port.Text = value.ToString(); }
        }

        public string Database
        {
            get
            { return tb_Database.Text.Trim(); }
            set
            { tb_Database.Text = value; }
        }

        public Int32 CommandTimeout
        {
            get
            {
                Int32 commandTimeout = 0;
                return (Int32.TryParse(tb_CommandTimeout.Text.Trim(), out commandTimeout) ? commandTimeout : 20);
            }
            set
            { tb_CommandTimeout.Text = value.ToString(); }
        }

        public string UserId
        {
            get
            { return tb_UserId.Text.Trim(); }
            set
            { tb_UserId.Text = value; }
        }

        private string _Password = "";
        public string Password
        {
            get
            {
                string newPassword = tb_Password.Text.Trim();
                return (newPassword.Equals("") ? _Password : newPassword);
            }
            set
            {
                _Password = value;
                tb_Password.Text = "";
            }
        }

        public char PasswordChar
        {
            get
            { return tb_Password.PasswordChar; }
            set
            { tb_Password.PasswordChar = value; }
        }

        #endregion Properties

        public UCSettingSQLConnection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Формира ConnectionString
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            string connectionString = "Server={0};Port={1};Database={2};User Id={3};Password={4};CommandTimeout={5};";

            return string.Format(connectionString, this.Server, this.Port,
                this.Database, this.UserId, this.Password,
                this.CommandTimeout);
        }

        private void tb_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tb_CommandTimeout_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
