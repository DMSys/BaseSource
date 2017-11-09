using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls
{
    public class DCheckBox : CheckBox
    {
        private bool readOnly;

        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (readOnly)
                e.Handled = true;
            else
                base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (readOnly)
                e.Handled = true;
            else
                base.OnKeyPress(e);
        }

        protected override void WndProc(ref Message m)
        {
            // WM_LBUTTONDOWN && WM_LBUTTONDBLCLK
            if ((m.Msg != 0x201 && m.Msg != 0x203) || !readOnly)
                base.WndProc(ref m);
            else if (base.CanFocus)
                base.Focus();
        }
    }
}
