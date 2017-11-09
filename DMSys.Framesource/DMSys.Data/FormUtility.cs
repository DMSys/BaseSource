using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DMSys.Data
{
    public static class FormUtility
    {
        /// <summary>
        /// Зарежда ComboBox с данни от DataTable
        /// </summary>
        public static void Load(ComboBox cBox, DataTable dTable, string valueMember, string displayMember)
        {
            cBox.DisplayMember = displayMember;
            cBox.ValueMember = valueMember;
            cBox.DataSource = dTable;
        }

        /// <summary>
        /// Зарежда ComboBox с данни от DataTable и довя първи ред
        /// </summary>
        public static void Load(ComboBox cBox, DataTable dTable, string valueMember, string displayMember
            , string valueFirst, string displayFirst)
        {
            DataRow dRow = dTable.NewRow();
            dRow[valueMember] = valueFirst;
            dRow[displayMember] = displayFirst;
            dTable.Rows.InsertAt(dRow, 0);

            cBox.DisplayMember = displayMember;
            cBox.ValueMember = valueMember;
            cBox.DataSource = dTable;
        }

        /// <summary>
        /// Избира елемент от ComboBox
        /// </summary>
        public static void SelectedValue(ComboBox cBox, object value, object defValue = null)
        {
            // Ако има ст-ст за избиране
            if (value != null)
            {
                cBox.SelectedValue = value;
            }
            // Ако няма избрана ст-ст и има деф.
            if ((defValue != null) && (cBox.SelectedValue == null))
            {
                cBox.SelectedValue = defValue;
            }
        }
    }
}
