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
    public partial class FTargetSynchList : Form
    {
        #region Properties

        /// <summary>
        /// Резултат от действията във формата
        /// </summary>
        private bool _FormResult = false;

        /// <summary>
        /// Списък за синхронизиране
        /// </summary>
        public FSynchList TSynchList = null;

        #endregion Properties

        public FTargetSynchList()
        {
            InitializeComponent();
        }

        public bool ShowForm()
        {
            _FormResult = false;
            lbl_FromDirName.Text = this.TSynchList.Source;
            lbl_ToDirName.Text = this.TSynchList.Destination;
            if (this.TSynchList != null)
            { 
                foreach(FSynchItem si in this.TSynchList.Items )
                {
                    dt_SynchList.Rows.Add(si.Value, si.Type, si, si.Active, si.Status);
                }
            }
            //
            ShowDialog();
            return _FormResult;
        }

        private void dgv_SynchList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_SynchList.Columns[e.ColumnIndex].Name.Equals("gc_SIActive"))
            {
                DataGridViewRow dgvr = dgv_SynchList.Rows[e.RowIndex];
                FSynchItem si = (FSynchItem)dgvr.Cells["gc_SItem"].Value;
                si.Active = (Boolean)dgvr.Cells["gc_SIActive"].Value;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            _FormResult = true;
            Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            _FormResult = false;
            Close();
        }

        private void mi_CheckAll_Click(object sender, EventArgs e)
        {
            dgv_SynchList.EndEdit();
            foreach (DataGridViewRow dgvr in dgv_SynchList.Rows)
            {
                dgvr.Cells["gc_SIActive"].Value = true;
            }
        }

        private void mi_UncheckAll_Click(object sender, EventArgs e)
        {
            dgv_SynchList.EndEdit();
            foreach (DataGridViewRow dgvr in dgv_SynchList.Rows)
            {
                dgvr.Cells["gc_SIActive"].Value = false;
            }
        }
    }
}
