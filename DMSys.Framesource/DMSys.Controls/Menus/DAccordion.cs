using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls.Menus
{
    public delegate void ChangedEventHandler(object sender, object value);

    public partial class DAccordion : UserControl
    {
        #region Properties

        private int _HeaderHeight = 30;
        public int HeaderHeight
        {
            get
            { return _HeaderHeight; }
            set
            { _HeaderHeight = value; }
        }

        private Font _HeaderFont = new Font(FontFamily.GenericSansSerif, 12F, FontStyle.Bold);
        public Font HeaderFont
        {
            get
            { return _HeaderFont; }
            set
            { _HeaderFont = value; }
        }

        private Color _HeaderBackColor = Color.FromArgb(66, 66, 66);
        public Color HeaderBackColor
        {
            get
            { return _HeaderBackColor; }
            set
            { _HeaderBackColor = value; }
        }

        private Color _HeaderForeColor = Color.White;
        public Color HeaderForeColor
        {
            get
            { return _HeaderForeColor; }
            set
            { _HeaderForeColor = value; }
        }

        private int _ItemHeight = 30;
        public int ItemHeight
        {
            get
            { return _ItemHeight; }
            set
            { _ItemHeight = value; }
        }

        private Font _ItemFont = new Font(FontFamily.GenericSansSerif, 12F, FontStyle.Bold);
        public Font ItemFont
        {
            get
            { return _ItemFont; }
            set
            { _ItemFont = value; }
        }

        private Color _ItemBackColor = Color.FromArgb(213, 213, 213);
        public Color ItemBackColor
        {
            get
            { return _ItemBackColor; }
            set
            { _ItemBackColor = value; }
        }

        private Color _ItemForeColor = Color.Black;
        public Color ItemForeColor
        {
            get
            { return _ItemForeColor; }
            set
            { _ItemForeColor = value; }
        }
        
        #endregion Properties

        #region Events

        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(object value)
        {
            if (Changed != null)
                Changed(this, value);
        }

        #endregion Events

        public DAccordion()
        {
            InitializeComponent();
        }

        public DAccordionMenu AddMenu(string text)
        {
            DAccordionMenu daMenu = new DAccordionMenu(text);
            daMenu.HeaderHeight = _HeaderHeight;
            daMenu.HeaderFont = _HeaderFont;
            daMenu.HeaderBackColor = _HeaderBackColor;
            daMenu.HeaderForeColor = _HeaderForeColor;
            daMenu.ItemHeight = _ItemHeight;
            daMenu.ItemFont = _ItemFont;
            daMenu.ItemBackColor = _ItemBackColor;
            daMenu.ItemForeColor = _ItemForeColor;

            daMenu.Changed += new ChangedEventHandler(this.daMenu_Changed);
            daMenu.Dock = DockStyle.Top;

            this.Controls.Add(daMenu);
            this.Controls.SetChildIndex(daMenu, 0);
            return daMenu;
        }

        private void daMenu_Changed(object sender, object value)
        {
            OnChanged(value);
        }
    }
}
