using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydra.Win.Layouts
{
    public static class AppConfig
    {
        private static string GetCMAppSettings(string name)
        {
            return System.Configuration.ConfigurationManager.AppSettings[name];
        }

        public static string CurrentDirectoryCombine(string path)
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }

        /// <summary>
        /// Път до файловете на приложенията
        /// </summary>
        public static string AppsFiles
        {
            get
            {
                string appsFilesPath = GetCMAppSettings("APPS_FILES");
                if (String.IsNullOrWhiteSpace(appsFilesPath))
                { return CurrentDirectoryCombine("AppsFiles\\"); }
                else
                { return appsFilesPath.ToString(); }
            }
        }

        /// <summary>
        /// Път до файловете на приложенията
        /// </summary>
        public static string JScriptsPath
        {
            get
            {
                string appsFilesPath = GetCMAppSettings("JSCRIPTS_PATH");
                if (String.IsNullOrWhiteSpace(appsFilesPath))
                { return CurrentDirectoryCombine("JScripts\\"); }
                else
                { return appsFilesPath.ToString(); }
            }
        }

        /// <summary>
        /// Път до данните на приложенията
        /// </summary>
        public static string AppsData
        {
            get
            {
                string appsDataPath = GetCMAppSettings("APPS_DATA");
                if (String.IsNullOrWhiteSpace(appsDataPath))
                { return CurrentDirectoryCombine("AppsData\\"); }
                else
                { return appsDataPath.ToString(); }
            }
        }

        /// <summary>
        /// Път до приложението
        /// </summary>
        public static string DefaultAppBasePath
        {
            get
            {
                string defaultAppBasePath = GetCMAppSettings("DEFAULT_APP_BASE_PATH");
                if (String.IsNullOrWhiteSpace(defaultAppBasePath))
                { return ""; }
                else
                { return defaultAppBasePath.ToString(); }
            }
        }

        /// <summary>
        /// Стартова страница
        /// </summary>
        public static string DefaultAppStartPage
        {
            get
            {
                string defaultAppStartPage = GetCMAppSettings("DEFAULT_APP_START_PAGE");
                if (String.IsNullOrWhiteSpace(defaultAppStartPage))
                { return ""; }
                else
                { return defaultAppStartPage.ToString(); }
            }
        }

        /// <summary>
        /// Наименование на компанията
        /// </summary>
        public static string DefaultAppCompany
        {
            get
            {
                string defaultAppCompany = GetCMAppSettings("DEFAULT_APP_COMPANY");
                if (String.IsNullOrWhiteSpace(defaultAppCompany))
                { return "Unknown"; }
                else
                { return defaultAppCompany.ToString(); }
            }
        }

        /// <summary>
        /// Наименование на прилоцението
        /// </summary>
        public static string DefaultAppName
        {
            get
            {
                string defaultAppName = GetCMAppSettings("DEFAULT_APP_NAME");
                if (String.IsNullOrWhiteSpace(defaultAppName))
                { return "Unknown"; }
                else
                { return defaultAppName.ToString(); }
            }
        }

        /// <summary>
        /// Online ли е заредено
        /// </summary>
        public static bool DefaultAppIsOnline
        {
            get
            {
                string defaultAppIsOnline = GetCMAppSettings("DEFAULT_APP_IS_ONLINE");
                if (String.IsNullOrWhiteSpace(defaultAppIsOnline))
                { return true; }
                else
                { return (defaultAppIsOnline != "0"); }
            }
        }   
    }
}
