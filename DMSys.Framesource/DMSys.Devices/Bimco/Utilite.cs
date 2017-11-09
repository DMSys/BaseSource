using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Devices.Bimco
{
    public static class Utilite
    {
        public static void StrToMas(string s1, byte[] mas)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                mas[i] = (byte)s1[i];
            }
        }

        public static int HexToBase(string hex)
        {
            hex = hex.ToLower();
            int dec = 0;
            for (int i = hex.Length - 1, power = 0; i >= 0; i--, power++)
            {
                char c = hex[i];
                if (c >= 'a' && c <= 'z')
                {
                    int temp = 0;
                    switch (c)
                    {
                        case 'a': temp = 10; break;
                        case 'b': temp = 11; break;
                        case 'c': temp = 12; break;
                        case 'd': temp = 13; break;
                        case 'e': temp = 14; break;
                        case 'f': temp = 15; break;
                    }
                    dec += temp * (int)Math.Pow(16, power);
                }
                else
                {
                    dec += Convert.ToInt32(c.ToString()) * (int)Math.Pow(16, power);
                }
            }
            return dec;
        }
    }
}
