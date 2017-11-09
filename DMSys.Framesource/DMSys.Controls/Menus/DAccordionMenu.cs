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
    public partial class DAccordionMenu : UserControl
    {
        #region Properties

        /// <summary>
        /// Височина на менуто
        /// </summary>
        private int _MenuHeight = 0;

        private string _HeaderText = "";

        private bool _IsExpand = true;
        /// <summary>
        /// Зарширено ли е менюто
        /// </summary>
        public bool IsExpand
        {
            get
            { return _IsExpand; }
        }

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

        public DAccordionMenu(string headerText)
        {
            InitializeComponent();

            _HeaderText = headerText;           
        }

        private void DAccordionMenu_Load(object sender, EventArgs e)
        {
            AddHeader(_HeaderText);
            _IsExpand = true;
        }

        /// <summary>
        /// Добавя заглавната част на менюто
        /// </summary>
        private void AddHeader(string text)
        {
            Label lbl_Header = new Label();
            lbl_Header.AutoSize = false;
            lbl_Header.Top = 0;
            lbl_Header.Left = 0;
            lbl_Header.Text = text;
            lbl_Header.BackColor = _HeaderBackColor;
            lbl_Header.Cursor = Cursors.Hand;
            lbl_Header.Font = _HeaderFont;
            lbl_Header.ForeColor = _HeaderForeColor;
            lbl_Header.Height = _HeaderHeight - 1;
            lbl_Header.Width = this.Width;
            lbl_Header.TextAlign = ContentAlignment.MiddleLeft;
            lbl_Header.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            lbl_Header.Click += new System.EventHandler(this.lbl_Header_Click);

            _MenuHeight = _HeaderHeight;
            this.Controls.Add(lbl_Header);
            this.Height = _MenuHeight;
        }

        /// <summary>
        /// Добавя елемент от менюто
        /// </summary>
        public void AddItem(string text, object value)
        {
            Label lbl_Item = new Label();
            lbl_Item.AutoSize = false;
            lbl_Item.Top = _MenuHeight;
            lbl_Item.Left = 0;
            lbl_Item.Text = text;
            lbl_Item.Height = _ItemHeight - 1;
            lbl_Item.BackColor = _ItemBackColor;
            lbl_Item.Cursor = Cursors.Hand;
            lbl_Item.Font = _ItemFont;
            lbl_Item.ForeColor = _ItemForeColor;
            lbl_Item.Width = this.Width;
            lbl_Item.TextAlign = ContentAlignment.MiddleLeft;
            lbl_Item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            lbl_Item.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            lbl_Item.Click += new System.EventHandler(this.lbl_Item_Click);

            lbl_Item.Tag = value;
            _MenuHeight += _ItemHeight;
            this.Controls.Add(lbl_Item);
            this.Height = _MenuHeight;
        }

        private void lbl_Header_Click(object sender, EventArgs e)
        {
            if (_IsExpand)
            { Collapse(); }
            else
            { Expand(); }
        }

        private void lbl_Item_Click(object sender, EventArgs e)
        {
            Label lbl_Item = ((Label)sender);
            OnChanged(lbl_Item.Tag);
        }

        /// <summary>
        /// Разширява менюто
        /// </summary>
        public void Expand()
        {
            this.Height = _MenuHeight;
            _IsExpand = true;
        }

        /// <summary>
        /// Свива менюто
        /// </summary>
        public void Collapse()
        {
            this.Height = _HeaderHeight;
            _IsExpand = false;
        }
    }
}
