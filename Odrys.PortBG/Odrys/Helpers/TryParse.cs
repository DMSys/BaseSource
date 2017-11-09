using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odrys.Helpers
{
    public static class TryParse
    {
        public static Int32 ToInt32(object value, Int32 defaultValue = 0)
        {
            if (value == null)
            { return defaultValue; }
            return TryParse.ToInt32(value.ToString());
        }

        public static Int32 ToInt32(string value, Int32 defaultValue = 0)
        {
            string strValue = value.Trim();
            if (strValue == "")
            { return defaultValue; }
            Int32 intValue = 0;
            Int32.TryParse(strValue, out intValue);
            return intValue;
        }
    }
}