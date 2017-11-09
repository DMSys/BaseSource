using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Utility
{
    public static class WForm
    {
        /// <summary>
        /// Задава дата на DateTimePicker с ограничение за MAX дата
        /// </summary>
        public static void SetValue(DateTimePicker dtp, DateTime date, DateTime maxDate)
        {
            dtp.MaxDate = maxDate;
            if (maxDate > date)
            { dtp.Value = date; }
            else
            { dtp.Value = maxDate; }
        }
    }
}
