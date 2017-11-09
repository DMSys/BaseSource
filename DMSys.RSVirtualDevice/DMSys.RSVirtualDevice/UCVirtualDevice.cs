using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMSys.RSVirtualDevice
{
    public class UCVirtualDevice : UserControl
    {
        public virtual bool IsOpen
        {
            get { return false; }
        }

        public virtual void Start() { }

        public virtual void Stop() { }
    }

    public class LogDevice
    {
        private RichTextBox _LogBox = null;

        public LogDevice( RichTextBox logBox )
        {
            _LogBox = logBox;
        }

        public void Clear()
        {
            _LogBox.Clear();
        }

        public void Set(string itemKey, string itemValue)
        {
            if ((itemKey == "") && (itemValue == ""))
            { return; }
            try
            {
                _LogBox.AppendText(String.Format("{0}:\t{1}\n", itemKey.Trim(), itemValue.Trim()));
                //_LogBox.SelectionStart = _LogBox.Text.Length;
                _LogBox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
