using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace DMSys.Systems.ConfigurationFile
{
    /// <summary>
    /// XML файл с настройки за приложение
    /// </summary>
    public class AppConfig
    {
        #region Properties

        /// <summary>
        /// Път до XML документа
        /// </summary>
        private string _XmlFile = "";

        /// <summary>
        /// XML докъмент
        /// </summary>
        private XmlDocument _XmlDoc = new XmlDocument();

        /// <summary>
        /// Основния елемент на документа
        /// </summary>
        private XmlElement _XmlRoot = null;

        private AppConfigSettings _AppSettings = null;
        /// <summary>
        /// Специални настройки
        /// </summary>
        public AppConfigSettings AppSettings
        {
            get
            { return _AppSettings; }
        }

        private AppConnectionStrings _ConnectionStrings = null;
        /// <summary>
        /// Връзки с база данни
        /// </summary>
        public AppConnectionStrings ConnectionStrings
        {
            get
            { return _ConnectionStrings; }
        }

        #endregion Properties

        public AppConfig()
        { }

        /// <summary>
        /// Отваря и зарежда данните от конфигурационния файл
        /// </summary>
        /// <param name="xmlFile"></param>
        public void Open(string xmlFile)
        {
            _XmlFile = xmlFile;
            _XmlDoc.RemoveAll();
            if (File.Exists(xmlFile))
            {
                _XmlDoc.Load(xmlFile);
                _XmlRoot = _XmlDoc.DocumentElement;
            }
            else
            {
                // Create the XML Declaration, and append it to XML document
                XmlDeclaration dec = _XmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                _XmlDoc.AppendChild(dec);// Create the root element
                _XmlRoot = _XmlDoc.CreateElement("configuration");
                _XmlDoc.AppendChild(_XmlRoot);
            }
            // Специалните настройки
            _ConnectionStrings = new AppConnectionStrings(_XmlDoc);
            // Специалните настройки
            _AppSettings = new AppConfigSettings(_XmlDoc);
        }

        /// <summary>
        /// Записва конфигурационния файл
        /// </summary>
        public void Save()
        {
            _XmlDoc.Save(_XmlFile);
        }
    }
}
