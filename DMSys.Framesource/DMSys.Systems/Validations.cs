using System;
using System.Collections.Generic;
using System.Text;

namespace DMSys.Systems
{
    /// <summary>
    /// Инструменти за валидация
    /// </summary>
    public static class Validations
    {
        /// <summary>
        /// Валидира IBAN
        /// </summary>
        /// <param name="ibanValue"></param>
        /// <returns></returns>
        public static bool ValidateIBAN(string ibanValue)
        {
            try
            {
                string iban = ibanValue.Substring(4, ibanValue.Length - 4) + ibanValue.Substring(0, 4);
                StringBuilder sb = new StringBuilder();
                foreach (char c in iban)
                {
                    int v;
                    if (Char.IsLetter(c))
                    {
                        v = c - 'A' + 10;
                    }
                    else
                    {
                        v = c - '0';
                    }
                    sb.Append(v);
                }
                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                return checksum == 1;
            }
            catch
            { return false; }
        }
    }
}
