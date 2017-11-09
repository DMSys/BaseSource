using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for xDateFormat
/// </summary>
public static class xDateFormat
{
	/// <summary>
    /// Форматва стринга в дата
	/// </summary>
	/// <param name="inDate"></param>
	/// <returns></returns>
    public static DateTime StringToData(string inDate)
    {
        return Convert.ToDateTime(inDate);
    }

    public static string DateToStr(DateTime dt)
    {
        string res = dt.Day + "." + dt.Month + "." + dt.Year;

        return res;
    }
    public static string DateStrToSQLDateStr(string s)
    {
        DateTime dt = StrToDate(s);
        string res = dt.Year + "-" + dt.Month + "-" + dt.Day;

        return res;
    }
    public static DateTime StrToDate(string s)
    {
        int cWhat = 0;
        string cDay = "";
        string cMonth = "";
        string cYear = "";

        for (int i = 0; i < s.Length; i++)
        {
            if ((s[i] >= '0') && (s[i] <= '9'))
            {
                if (cWhat == 0) cWhat = 1;
                if (cWhat == 1) cDay = cDay + s[i];
                if (cWhat == 2) cMonth = cMonth + s[i];
                if (cWhat == 3) cYear = cYear + s[i];
            }
            else
            {
                if ((s[i] != '.')
                   && (s[i] != '/')
                   && (s[i] != '\\'))
                    throw new Exception("Невалиден символ в дата"
                       + " - \"" + s + "\"!");

                if (cDay != "")
                    cWhat = 2;
                if (cMonth != "")
                    cWhat = 3;
            }
        }
        try
        {
            if ((Convert.ToInt32(cYear) > 2900) || (Convert.ToInt32(cYear) < 1100))
                throw new Exception("Невалидна дата"
                   + " - \"" + s + "\"!");
            DateTime res = new DateTime(Convert.ToInt32(cYear), Convert.ToInt32(cMonth), Convert.ToInt32(cDay));
            return res;
        }
        catch (Exception err)
        {
            err.HelpLink = "";
            throw new Exception("Невалидна дата" 
               + " - \"" + s + "\"!");
        }
    }
}    
