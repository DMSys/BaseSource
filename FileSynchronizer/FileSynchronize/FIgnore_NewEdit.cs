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
    public partial class FIgnore_NewEdit : Form
    {
        private bool _FormResult = false;

        public ConfigIgnoreItem CIgnoreItem = null;

        public FIgnore_NewEdit()
        {
            InitializeComponent();
            //
            cb_Type.DataSource = xDAL.IgnoreItemType();
            cb_Type.ValueMember = "TYPE_ID";
            cb_Type.DisplayMember = "TYPE_NAME";
        }

        public bool ShowForm()
        {
            _FormResult = false;
            //
            if (this.CIgnoreItem != null)
            {
                tb_Ignore.Text = this.CIgnoreItem.Value;
                cb_Type.SelectedValue = this.CIgnoreItem.Type;
                chb_Active.Checked = this.CIgnoreItem.Active;
            }
            //
            ShowDialog();
            return _FormResult;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.CIgnoreItem.Value = tb_Ignore.Text.Trim();
            this.CIgnoreItem.Type = (SynchItemType)cb_Type.SelectedValue;
            this.CIgnoreItem.Active = chb_Active.Checked;

            _FormResult = true;
            Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            _FormResult = false;
            Close();
        }
    }
}
