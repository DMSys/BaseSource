using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web
{
    public static class HttpSession
    {
        private static int GetSessionInt(string name, int defaultValue = 0)
        {
            object sessionValue = HttpContext.Current.Session[name];
            int resultValue = 0;
            if (sessionValue == null)
            { return defaultValue; }
            else if (Int32.TryParse(sessionValue.ToString(), out resultValue))
            { return resultValue; }
            else
            { return defaultValue; }
        }

        private static string GetSessionString(string name, string defaultValue = "")
        {
            object sessionValue = HttpContext.Current.Session[name];
            if (sessionValue == null)
            { return defaultValue; }
            else
            { return sessionValue.ToString(); }
        }

        private static void SetSession(string name, int value)
        {
            HttpContext.Current.Session[name] = value;
        }

        private static void SetSession(string name, string value)
        {
            HttpContext.Current.Session[name] = value;
        }

        /// <summary>
        /// ID на текущия сайт
        /// </summary>
        public static int CurrentSiteID
        {
            get
            { return GetSessionInt(SessionKeys.CurrentSiteID); }
            set
            { SetSession(SessionKeys.CurrentSiteID, value); }
        }

        /// <summary>
        /// ID на изгледа на текущия сайт
        /// </summary>
        public static string CurrentSiteViewID
        {
            get
            { return GetSessionString(SessionKeys.CurrentSiteViewID); }
            set
            { SetSession(SessionKeys.CurrentSiteViewID, value); }
        }

        /// <summary>
        /// ID на логнатия потребител
        /// </summary>
        public static int UserID
        {
            get
            { return GetSessionInt(SessionKeys.UserID); }
            set
            { SetSession(SessionKeys.UserID, value); }
        }

        public static int AminSiteID
        {
            get
            { return -1; }
        }

        public static bool IsAuthenticated
        {
            get
            { return System.Web.HttpContext.Current.User.Identity.IsAuthenticated; }
        }
    }

    public static class SessionKeys
    {
        /// <summary>
        /// ID на текущия сайт
        /// </summary>
        public const string CurrentSiteID = "CurrentSiteID";

        /// <summary>
        /// ID на изгледа на текущия сайт
        /// </summary>
        public const string CurrentSiteViewID = "CurrentSiteViewID";

        /// <summary>
        /// ID на логнатия потребител
        /// </summary>
        public const string UserID = "UserID";
    }
}