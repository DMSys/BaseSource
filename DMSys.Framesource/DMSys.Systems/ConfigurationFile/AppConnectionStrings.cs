using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Security.Cryptography;

namespace DMSys.Systems.ConfigurationFile
{
    /// <summary>
    /// Съдържа връзки с база данни
    /// </summary>
    public class AppConnectionStrings
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
        /// Връзки с база данни
        /// </summary>
        private XmlNode _ConnectionStrings = null;

        /// <summary>
        /// Парола за кодиране
        /// </summary>
        private byte[] _Кey24 = { 174, 12, 100, 200, 126, 122, 231, 6, 130, 200, 33, 85, 67, 95, 170, 189, 162, 140, 6, 223, 202, 202, 69, 235 };

        #endregion Properties

        public AppConnectionStrings(XmlDocument xmlDoc)
        {
            _XmlDoc = xmlDoc;
            _XmlRoot = _XmlDoc.DocumentElement;
            _ConnectionStrings = _XmlRoot.SelectSingleNode("connectionStrings");
        }

        /// <summary>
        /// Добавя ConnectionString
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connectionString"></param>
        /// <param name="password"></param>
        /// <param name="providerName"></param>
        public void Add(string name, string connectionString, string password, string providerName)
        {
            // Добавя connectionStrings ако не съществува
            if (_ConnectionStrings == null)
            {
                _ConnectionStrings = _XmlDoc.CreateElement("connectionStrings");
                _XmlRoot.AppendChild(_ConnectionStrings);
            }
            // Добавя елемент
            XmlElement elementAdd = _XmlDoc.CreateElement("add");
            elementAdd.SetAttribute("name", name);
            elementAdd.SetAttribute("connectionString", connectionString);
            elementAdd.SetAttribute("password", Encrypt(password));
            elementAdd.SetAttribute("providerName", providerName);
            _ConnectionStrings.AppendChild(elementAdd);
        }

        /// <summary>
        /// Дава ConnectionString
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AppConnectionString Get(string name)
        {
            if (_ConnectionStrings == null)
            { return null; }
            // Търси елемента
            XmlNodeList addNodes = _ConnectionStrings.SelectNodes("add");
            foreach (XmlElement addNode in addNodes)
            {
                if (addNode.GetAttribute("name") == name)
                {
                    AppConnectionString cs = new AppConnectionString();
                    cs.Name = addNode.GetAttribute("name");
                    cs.ConnectionString = addNode.GetAttribute("connectionString");
                    cs.Password = Decrypt(addNode.GetAttribute("password"));
                    cs.ProviderName = addNode.GetAttribute("providerName");
                    return cs;
                }
            }
            // Няма открит ConnectionString
            return null;
        }

        /// <summary>
        /// Кодира текста
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Encrypt(string input)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            // Ако няма за Encrypt
            if (inputArray.Length == 0)
            { return ""; }
            // Encrypt
            byte[] resultArray = null;
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.Key = _Кey24;
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                using (ICryptoTransform cTransform = tripleDES.CreateEncryptor())
                {
                    resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                }
                tripleDES.Clear();
            }
            // Ако няма резултат
            if (resultArray == null)
            { return ""; }
            else
            { return Convert.ToBase64String(resultArray, 0, resultArray.Length); }
        }

        /// <summary>
        /// Декодира текста
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Decrypt(string input)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            // Ако няма за Encrypt
            if (inputArray.Length == 0)
            { return ""; }
            // Decrypt
            byte[] resultArray = null;
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.Key = _Кey24;
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                using (ICryptoTransform cTransform = tripleDES.CreateDecryptor())
                {
                    resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                }
                tripleDES.Clear();
            }
            // Ако няма резултат
            if (resultArray == null)
            { return ""; }
            else
            { return UTF8Encoding.UTF8.GetString(resultArray); }
        }
    }
}
