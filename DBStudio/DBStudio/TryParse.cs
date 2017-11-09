using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBStudio
{
    public static class Utility
    {
        public static string ToString(object value)
        {
            if ((value == null) || (value == DBNull.Value))
            { return ""; }
            else
            { return value.ToString(); }
        }
    }
}
