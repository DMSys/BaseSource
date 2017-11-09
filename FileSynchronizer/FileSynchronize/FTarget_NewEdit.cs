using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMSys.Systems.SynchronizerFile;

namespace FileSynchronizer
{
    /// <summary>
    /// Форма за добавяне/редакция на цел за синхронизиране
    /// </summary>
    public partial class FTarget_NewEdit : Form
    {
        /// <summary>
        /// Резултат от действията във формата
        /// </summary>
        private bool _FormResult = false;

        /// <summary>
        /// Целта за синхронизация
        /// </summary>
        public ConfigTarget CTarget = null;

        public FTarget_NewEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отваря формата
        /// </summary>
        /// <returns></returns>
        public bool ShowForm()
        {
            _FormResult = false;
            // Зарежда формата с данни, ако е редакция
            if (this.CTarget != null)
            {
                tb_Name.Text = this.CTarget.Name;
                tb_Source.Text = this.CTarget.Source;
                tb_Destination.Text = this.CTarget.Destination;
            }
            // Отваря формата
            this.ShowDialog();
            // Резултат от действията
            return _FormResult;
        }

        /// <summary>
        /// Променя данните и затваря формата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.CTarget.Name = tb_Name.Text.Trim();
            this.CTarget.Source = tb_Source.Text.Trim();
            this.CTarget.Destination = tb_Destination.Text.Trim();
            _FormResult = true;
            Close();
        }

        /// <summary>
        /// Затваря формата без промяна на данните
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            _FormResult = false;
            Close();
        }

        private void btn_BrowserSource_Click(object sender, EventArgs e)
        {
            fBrowserDlg.SelectedPath = tb_Source.Text.Trim();
            if (fBrowserDlg.ShowDialog() == DialogResult.OK)
            { tb_Source.Text = fBrowserDlg.SelectedPath; }
        }

        private void btn_BrowserDestination_Click(object sender, EventArgs e)
        {
            fBrowserDlg.SelectedPath = tb_Destination.Text.Trim();
            if (fBrowserDlg.ShowDialog() == DialogResult.OK)
            { tb_Destination.Text = fBrowserDlg.SelectedPath; }
        }
    }
}
