using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Net.HTMLParser
{
    public enum HTMLTagType { HTML, ShortHTML, Text }

    public class HTMLTag : IDisposable
    {
        #region Properties

        private HTMLTagCollection _Tags = new HTMLTagCollection();
        /// <summary>
        /// Списък от HTML Tags
        /// </summary>
        public HTMLTagCollection Tags
        {
            get
            { return _Tags; }
        }

        private string _TagName = "";
        /// <summary>
        /// Име на тага
        /// </summary>
        public string TagName
        {
            get
            { return _TagName; }
        }

        private HTMLTagType _TagType = HTMLTagType.Text;
        /// <summary>
        /// Тип на тага
        /// </summary>
        public HTMLTagType TagType
        {
            get
            { return _TagType; }
        }

        private HTMLTag _TagParent = null;
        public HTMLTag TagParent
        {
            get
            { return _TagParent; }
        }

        private Dictionary<string, string> _TagProperties = new Dictionary<string, string>();
        /// <summary>
        /// Елементи на тага
        /// </summary>
        public Dictionary<string, string> TagProperties
        {
            get
            { return _TagProperties; }
        }
        
        #endregion Properties

        public HTMLTag(HTMLTag aTagParent, string aTagName, HTMLTagType aTagType)
        {
            _TagParent = aTagParent;
            _TagType = aTagType;

            if ((aTagType == HTMLTagType.HTML) || (aTagType == HTMLTagType.ShortHTML))
            { _TagName = aTagName.ToUpper(); }
            else
            { _TagName = aTagName; }
        }

        /// <summary>
        /// Преобразува HTML обект в HTML текст
        /// </summary>
        /// <param name="aSBPrint"></param>
        public void Print(StringBuilder aSBPrint, string aTapSpace)
        {
            switch (this.TagType)
            {
                case HTMLTagType.HTML:
                    aSBPrint.AppendLine(aTapSpace + "<" + _TagName + PrintProperties() + ">");
                    foreach (HTMLTag tag in _Tags)
                    {
                        tag.Print(aSBPrint, aTapSpace + "    ");
                    }
                    aSBPrint.AppendLine(aTapSpace + "</" + _TagName + ">");
                    break;
                case HTMLTagType.ShortHTML:
                    aSBPrint.AppendLine(aTapSpace + "<" + _TagName + PrintProperties() + "/>");
                    break;
                case HTMLTagType.Text:
                    aSBPrint.AppendLine(aTapSpace + _TagName);
                    break;
            }
        }

        /// <summary>
        /// Преобразува елементите на тага в HTML текст
        /// </summary>
        /// <returns></returns>
        private string PrintProperties()
        {
            string sProperties = "";

            foreach (string sKey in _TagProperties.Keys)
            {
                sProperties += " " + sKey + "=\"" + _TagProperties[sKey] + "\"";
            }
            return sProperties;
        }

        public void Dispose()
        {
            _TagProperties.Clear();
            _Tags.Clear();
        }
    }
}
