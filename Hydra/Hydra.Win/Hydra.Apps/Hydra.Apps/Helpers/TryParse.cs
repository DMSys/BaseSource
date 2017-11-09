using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydra.Apps.Helpers
{
    public static class TryParse
    {
        public static Int32 ToInt32(string value, Int32 defaultValue = 0)
        {
            if (string.IsNullOrEmpty(value))
            { return defaultValue; }

            int result = defaultValue;
            if (Int32.TryParse(value, out result))
            { return result; }
            else
            { return defaultValue; }
        }

        public static Int32 ToInt32(object value, Int32 defaultValue = 0)
        {
            return (value == null) ? defaultValue : TryParse.ToInt32(value.ToString(), defaultValue);
        }

        public static string ToString(object value, string defaultValue = "")
        {
            return (value == null) ? defaultValue : value.ToString();
        }

        public static Guid ToGuid(string value, Guid defaultValue = new Guid())
        {
            if (string.IsNullOrEmpty(value))
            { return defaultValue; }

            Guid result = defaultValue;
            if (Guid.TryParse(value, out result))
            { return result; }
            else
            { return defaultValue; }
        }

        public static Guid ToGuid(object value, Guid defaultValue = new Guid())
        {
            return (value == null) ? defaultValue : TryParse.ToGuid(value.ToString(), defaultValue);
        }
        
    }
}