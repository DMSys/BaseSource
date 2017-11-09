using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hydra.Win.Layouts
{
    public static class Helper
    {
        /// <summary>
        /// Валидира пътя до локалното приложение
        /// </summary>
        public static string ValidateLocalAppPath(string localApp, out Uri localAppUrl)
        {
            localAppUrl = null;
            if (localApp.Equals(string.Empty))
            { return ""; }
            // Ако е подаден път до папка
            if (Directory.Exists(localApp))
            {
                string localAppPage = Path.Combine(localApp, "index.html");
                if (File.Exists(localAppPage))
                {
                    localAppUrl = new Uri(localAppPage);
                    return localApp;
                }
                localAppPage = Path.Combine(localApp, "index.htm");
                if (File.Exists(localAppPage))
                {
                    localAppUrl = new Uri(localAppPage);
                    return localApp;
                }
                return localAppPage;
            }
            // Ако е подаден път до файл
            else if (File.Exists(localApp))
            {
                localAppUrl = new Uri(localApp);
                return Path.GetFullPath(localApp);
            }
            else
            { return ""; }
        }

        /// <summary>
        /// Десериализира JSON
        /// </summary>
        public static object JsonDeserialize(string jsonString, Type type)
        {
            object jsonObject = null;
            using (var jsonMemoryStream = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
            {
                var jsonSerializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(type);

                jsonObject = jsonSerializer.ReadObject(jsonMemoryStream);
            }
            return jsonObject;
        }

        /// <summary>
        /// Combines two strings into a path.
        /// </summary>
        public static string PathCombine(string path1, string path2)
        {
            if (path2.StartsWith("~\\"))
            {
                return Path.Combine(path1, path2.Replace("~\\", ""));
            }
            else if (path2.StartsWith("~/"))
            {
                return Path.Combine(path1, path2.Replace("~/", ""));
            }
            else
            {
                return Path.Combine(path1, path2);
            }
        }
    }
}
