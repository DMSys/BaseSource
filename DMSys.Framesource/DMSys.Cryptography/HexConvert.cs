using System;
using System.Collections.Generic;
using System.Text;

namespace DMSys.Cryptography
{
    public static class HexConvert
    {
        #region ToString

        /// <summary>
        /// Преобразува char[] в string от Hex стойности
        /// </summary>
        public static string ToString(char[] aValue)
        {
            string sValue = "";
            foreach (char c in aValue)
            {
                sValue += ((byte)c).ToString("X2");
            }
            return sValue;
        }

        /// <summary>
        /// Преобразува byte[] в string от Hex стойности
        /// </summary>
        public static string ToString(byte[] aValue)
        {
            string sValue = "";
            foreach (byte c in aValue)
            {
                sValue += c.ToString("X2");
            }
            return sValue;
        }

        #endregion ToString

        #region ТоByte

        public static string ТоByte(string aValue)
        {
            if (aValue.Length == 0)
                return "";
            if ((aValue.Length % 2) != 0)
                return "";
            //
            string sValue = "";
            for (Int32 i = 0; i < aValue.Length; i += 2)
            { sValue += (char)(byte)((ТоByte((char)aValue[i]) * 16) + ТоByte((char)aValue[i + 1])); }
            //
            return sValue;
        }

        public static byte[] FromString(string aValue)
        {
            if (aValue.Length == 0)
                return null;
            if ((aValue.Length % 2) != 0)
                return null;
            //
            byte[] bValue = new byte[aValue.Length / 2];
            for (Int32 i = 0; i < bValue.Length; i++ )
            {
                bValue[i] = (byte)((ТоByte((char)aValue[(i * 2)]) * 16) + (byte)ТоByte((char)aValue[(i * 2) + 1]));
            }
            //
            return bValue;
        }

        public static byte ТоByte(char aValue)
        {
            switch (aValue)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                default:
                    throw new Exception("Стойноста '"+aValue+"' не е HEX стойност !");
            }
        }

        #endregion ТоByte
    }
}
