using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBStudio
{
    public class UCDBStudio : UserControl
    {
        private bool _CanClosed = true;
        public virtual bool CanClosed
        {
            get
            { return _CanClosed; }
        }

        public string Caption { get; set; }
    }
}
