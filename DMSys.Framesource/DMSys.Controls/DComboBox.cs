using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls
{
    public class DComboBox : ComboBox
    {
        private bool _ReadOnly;
        /// <summary>
        /// Прави ComboBox-а ReadOnly
        /// </summary>
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set { _ReadOnly = value; }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Прави ComboBox-а ReadOnly
            if (_ReadOnly)
            { e.Handled = true; }

            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // Прави ComboBox-а ReadOnly
            if (_ReadOnly)
            { e.Handled = true; }

            base.OnKeyPress(e);
        }

        protected override void WndProc(ref Message m)
        {
            // Прави ComboBox-а ReadOnly
            // WM_LBUTTONDOWN && WM_LBUTTONDBLCLK
            if ((m.Msg != 0x201 && m.Msg != 0x203) || !_ReadOnly)
            { base.WndProc(ref m); }
            else if (base.CanFocus)
            { base.Focus(); }
        }

        /// <summary>
        /// Добавя елемент към списъка
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AddItem(string name, object value)
        {
            return this.Items.Add(new DComboBoxItem(name, value));
        }
    }

    public class DComboBoxItem
    {
        public string Name;
        public object Value;

        public DComboBoxItem(string name, object value)
        {
            Name = name; Value = value;
        }

        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Name;
        }
    }
}
