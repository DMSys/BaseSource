using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DMSys.Systems.ConfigurationFile
{
    /// <summary>
    /// Съдържа специални настройки
    /// </summary>
    public class AppConfigSettings
    {
        #region Properties

        /// <summary>
        /// XML докъмент
        /// </summary>
        private XmlDocument _XmlDoc = null;

        /// <summary>
        /// Основния елемент на документа
        /// </summary>
        private XmlElement _XmlRoot = null;

        /// <summary>
        /// Настройки на приложението
        /// </summary>
        private XmlNode _AppSettings = null;

        #endregion Properties

        public AppConfigSettings(XmlDocument xmlDoc)
        {
            _XmlDoc = xmlDoc;
            _XmlRoot = _XmlDoc.DocumentElement;
            _AppSettings = _XmlRoot.SelectSingleNode("appSettings");
        }

        /// <summary>
        /// Добавя елемент
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            // Добавя appSettings ако не съществува
            if (_AppSettings == null)
            {
                _AppSettings = _XmlDoc.CreateElement("appSettings");
                _XmlRoot.AppendChild(_AppSettings);
            }
            // Добавя елемент
            XmlElement elementAdd = _XmlDoc.CreateElement("add");
            elementAdd.SetAttribute("key", key);
            elementAdd.SetAttribute("value", value);
            _AppSettings.AppendChild(elementAdd);
        }

        /// <summary>
        /// Дава стойноста на елемента
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            if (_AppSettings == null)
            {
                return "";
            }
            // Търси елемента
            XmlNodeList addNodes = _AppSettings.SelectNodes("add");
            foreach (XmlElement addNode in addNodes)
            {
                if (addNode.GetAttribute("key") == key)
                {
                    return addNode.GetAttribute("value");
                }
            }
            return "";
        }
    }
}
