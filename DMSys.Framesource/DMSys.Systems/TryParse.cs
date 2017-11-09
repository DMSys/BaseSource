using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Systems
{
    public static class TryParse
    {
        public static string ToString(object value, string def = "")
        {
            return (value == null) ? def : value.ToString();
        }

        public static string ToString(string value, string def = "")
        {
            return String.IsNullOrEmpty(value) ? def : value;
        }

        public static Int32 ToInt32(object value, Int32 def = 0)
        {
            if (value == null)
            { return def; }
            return TryParse.ToInt32(value.ToString(), def);
        }

        public static Int32 ToInt32(string value, Int32 def = 0)
        {
            string sValue = value.Trim();
            if (sValue == "")
            { return def; }
            int result = def;
            int.TryParse(sValue, out result);
            return result;
        }

        public static decimal ToDecimal(object value, decimal def = 0)
        {
            if (value == null)
            { return def; }
            return TryParse.ToDecimal(value.ToString(), def);
        }

        public static decimal ToDecimal(string value, decimal def = 0)
        {
            string sValue = value.Trim();
            if (sValue == "")
            { return def; }
            decimal result = def;
            decimal.TryParse(sValue, out result);
            return result;
        }

        public static DateTime ToDateTime(object value, DateTime? def = null)
        {
            if (value == null)
            { return ((def == null) ? DateTime.MinValue : (DateTime)def); }
            return TryParse.ToDateTime(value.ToString(), def);
        }

        public static DateTime ToDateTime(string value, DateTime? def = null)
        {
            string sValue = value.Trim();
            DateTime defValue = ((def == null) ? DateTime.MinValue : (DateTime)def);
            if (sValue == "")
            { return defValue; }
            DateTime result = defValue;
            if (DateTime.TryParse(sValue, out result))
            { return result; }
            else
            { return defValue; }
        }
    }
}
