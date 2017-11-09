using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Systems
{
    public class ConvertValue
    {
        /// <summary>
        /// Конвертира минути в милисекунди
        /// </summary>
        public static Int32 MinuteToMilliseconds(Int32 aMin)
        {
            return (aMin * 60000);
        }

        #region CyrillicToLatin

        private static string[] mCyrS = { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я" };
        private static string[] mCyrU = { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ь", "Ю", "Я" };

        private static string[] mLatS = { "a", "b", "v", "g", "d", "e", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h", "ts", "ch", "sh", "sht", "a", "y", "yu", "ya" };
        private static string[] mLatU = { "A", "B", "V", "G", "D", "E", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "H", "Ts", "Ch", "Sh", "Sht", "A", "Y", "Yu", "Ya" };

        /// <summary>
        /// Конвертира кирилица на латиница
        /// </summary>
        public static string CyrillicToLatin(string aValue)
        {
            string sValue = aValue;
            // Големи букви
            for (int i = 0; i < mCyrU.Length; i++)
            {
                sValue = sValue.Replace(mCyrU[i], mLatU[i]);
            }
            // Малки букви
            for (int i = 0; i < mCyrS.Length; i++)
            {
                sValue = sValue.Replace(mCyrS[i], mLatS[i]);
            }
            return sValue;
        }

        #endregion CyrillicToLatin

        public static string ToStringHex(System.Drawing.Color aColor)
        {
            string sRes = "#";
            string sHex = "";
            //
            sHex = ToStringHex(aColor.R);
            if (sHex.Length == 2)
                sRes += sHex;
            else
                sRes += "0" + sHex;
            //
            sHex = ToStringHex(aColor.G);
            if (sHex.Length == 2)
                sRes += sHex;
            else
                sRes += "0" + sHex;
            //
            sHex = ToStringHex(aColor.B);
            if (sHex.Length == 2)
                sRes += sHex;
            else
                sRes += "0" + sHex;

            return sRes;
        }

        public static string ToStringHex(Int32 aInt)
        {
            Int32 iRes = aInt;
            Int32 iHex = 0;
            string sHex = "";

            while (iRes > 15)
            {
                iHex = iRes / 16;
                iRes = iRes - (iHex * 16);
                if (iHex < 16)
                    sHex += ToCharHex(iHex);
                else
                    sHex += ToStringHex(iHex);
            }
            sHex += ToCharHex(iRes);

            return sHex;
        }

        public static char ToCharHex(Int32 aInt)
        {
            switch (aInt)
            {
                case 0: return '0';
                case 1: return '1';
                case 2: return '2';
                case 3: return '3';
                case 4: return '4';
                case 5: return '5';
                case 6: return '6';
                case 7: return '7';
                case 8: return '8';
                case 9: return '9';
                case 10: return 'A';
                case 11: return 'B';
                case 12: return 'C';
                case 13: return 'D';
                case 14: return 'E';
                case 15: return 'F';
                default: return '0';
            }
        }

        public static Int16 ToInt16(object aInt)
        {
            if (aInt.ToString().Equals(""))
                return 0;
            else
                return Convert.ToInt16(aInt);
        }

        public static DateTime ToDate_Begin(DateTime aValue)
        {
            return new DateTime(aValue.Year, aValue.Month, aValue.Day, 0, 0, 0);
        }

        public static DateTime ToDate_End(DateTime aValue)
        {
            return new DateTime(aValue.Year, aValue.Month, aValue.Day, 23, 59, 59);
        }
    }
}
