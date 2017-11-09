using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Net.HTMLParser
{
    public class HTMLCustomPage
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

        private int _ParseCharIndex = 0;

        #endregion Properties

        public HTMLCustomPage()
        { }

        /// <summary>
        /// Парсва HTML текст и създава HTML обект
        /// </summary>
        /// <param name="aHTMLText"></param>
        public void Parse( string aHTMLText )
        {
            _ParseCharIndex = 0;
            string sTagValue = "";
            HTMLTag htmlCurrentTag = null;
            while (_ParseCharIndex < aHTMLText.Length)
            {
                // Ако тага е обработен, заражда следващия
                if (sTagValue == "")
                { sTagValue = Find_NextTag(aHTMLText); }

                // Съдава таг на първо ниво
                if (htmlCurrentTag == null)
                { htmlCurrentTag = Create_Tag(null, _Tags, ref sTagValue); }
                // Създава под таг
                else
                { htmlCurrentTag = Create_Tag(htmlCurrentTag, htmlCurrentTag.Tags, ref sTagValue); }
            }
        }

        /// <summary>
        /// Преобразува HTML обект в HTML текст
        /// </summary>
        /// <returns></returns>
        public StringBuilder Print()
        {
            StringBuilder sb_Print = new StringBuilder();
            foreach(HTMLTag tag in _Tags)
            {
                tag.Print(sb_Print, "");
            }
            return sb_Print;
        }

        #region CreateTag

        /// <summary>
        /// Създава таг
        /// </summary>
        /// <param name="aCurrentTag"></param>
        /// <param name="aCurrentTags"></param>
        /// <param name="aTagValue"></param>
        /// <returns></returns>
        private HTMLTag Create_Tag(HTMLTag aCurrentTag, HTMLTagCollection aCurrentTags, ref string aTagValue)
        {
            // Затварящ таг
            if (aTagValue.StartsWith("</"))
            {
                List<string> lsValue = GetTagValue(aTagValue);

                if (aCurrentTag.TagName == lsValue[0].ToUpper())
                { aTagValue = ""; }
                
                return aCurrentTag.TagParent;
            }
            // Кратък гаг
            else if ( aTagValue.EndsWith("/>") )
            {
                List<string> lsValue = GetTagValue(aTagValue);

                HTMLTag htmlTag = new HTMLTag(aCurrentTag, lsValue[0], HTMLTagType.ShortHTML);
                aCurrentTags.Add(htmlTag);
                AddTagProperties(htmlTag, lsValue);

                aTagValue = "";
                return aCurrentTag;
            }
            // Отварящ таг
            else if (aTagValue.StartsWith("<"))
            {
                List<string> lsValue = GetTagValue(aTagValue);
                // Изключение: Кратък гаг
                if (lsValue[0].ToUpper() == "BR")
                {
                    HTMLTag htmlTag = new HTMLTag(aCurrentTag, lsValue[0], HTMLTagType.ShortHTML);
                    aCurrentTags.Add(htmlTag);
                    AddTagProperties(htmlTag, lsValue);

                    aTagValue = "";
                    return aCurrentTag;
                }
                // Отваря тага
                else
                {
                    HTMLTag htmlTag = new HTMLTag(aCurrentTag, lsValue[0], HTMLTagType.HTML);
                    aCurrentTags.Add(htmlTag);
                    AddTagProperties(htmlTag, lsValue);

                    aTagValue = "";
                    return htmlTag;
                }
            }
            // текстови таг
            else
            {
                HTMLTag htmlTag = new HTMLTag(aCurrentTag, aTagValue, HTMLTagType.Text);
                aCurrentTags.Add(htmlTag);

                aTagValue = "";
                return aCurrentTag;
            }            
        }

        /// <summary>
        /// Разделя тага на име и пропартита
        /// Първия елемент е тага
        /// </summary>
        /// <param name="aTagValue"></param>
        /// <returns></returns>
        private List<string> GetTagValue(string aTagValue)
        {
            List<string> listValue = new List<string>();

            string sValue = "";
            bool InQuotes = false; // стринг в кавички
            char QuoteChar = ' '; // Символ за кавички
            foreach (char ch in aTagValue)
            {
                // Стринг в кавички
                if (InQuotes)
                {
                    // Край на кавичките
                    if (QuoteChar == ch)
                    { InQuotes = false; }
                    sValue += ch;
                }
                // Начало на стринг в кавички
                else if( (ch == '"') || (ch == '\''))
                { 
                    InQuotes = true;
                    sValue += ch;
                    QuoteChar = ch;
                }
                // край / начало
                else if ((ch == '<') || (ch == '/') || (ch == '>'))
                {
                    if (!sValue.Trim().Equals(""))
                    {
                        listValue.Add(sValue.Trim());
                        sValue = "";
                    }
                }
                else if (ch == ' ')
                {
                    if (!sValue.Trim().Equals(""))
                    {
                        listValue.Add(sValue.Trim());
                        sValue = "";
                    }
                }
                else
                { sValue += ch; }
            }
            if (!sValue.Trim().Equals(""))
            {
                listValue.Add(sValue.Trim());
                sValue = "";
            }
            return listValue;
        }

        /// <summary>
        /// Намира следващия таг
        /// </summary>
        /// <param name="aHTMLText"></param>
        /// <returns></returns>
        private string Find_NextTag(string aHTMLText)
        {
            // Открива началото на таг
            while ((_ParseCharIndex < aHTMLText.Length)
                && (aHTMLText[_ParseCharIndex] == ' '))
            { _ParseCharIndex++; }

            string sTag = "";
            while ((_ParseCharIndex < aHTMLText.Length)
                && ((aHTMLText[_ParseCharIndex] != '<') || (sTag.Trim().Length == 0))
                && (aHTMLText[_ParseCharIndex] != '>'))
            {
                sTag += aHTMLText[_ParseCharIndex].ToString();
                _ParseCharIndex++;
            }
            sTag = sTag.TrimStart();
            if (sTag.StartsWith("<"))
            {
                sTag += aHTMLText[_ParseCharIndex].ToString();
                _ParseCharIndex++;
            }
            return sTag.TrimEnd();
        }

        /// <summary>
        /// Добавя елементите на тага
        /// </summary>
        /// <param name="aTag"></param>
        /// <param name="aTagValues"></param>
        private void AddTagProperties(HTMLTag aTag, List<string> aTagValues)
        {
            if (aTagValues.Count < 2)
            { return; }

            for (int i = 1; i < aTagValues.Count; i++)
            {
                Int32 iIndex = aTagValues[i].IndexOf('=');
                string sKey = aTagValues[i].Substring(0, iIndex);
                string sValue = aTagValues[i].Substring(iIndex+1, aTagValues[i].Length-iIndex-1);
                sValue = sValue.Trim('"').Trim();

                aTag.TagProperties.Add(sKey, sValue);
            }
        }

        #endregion CreateTag

        public HTMLTag Select(string aPath)
        {/*
            string[] mPath = aPath.Split('/');

            if (mPath.Length == 0)
            { return null; }

            HTMLTag selTag = _SelectedTag;

            foreach (string sTag in mPath)
            {
                if (sTag == "")
                { return null; }

                selTag = selTag.GetChildTag(sTag);

                if (selTag == null)
                { return null; }
            }
            return selTag;*/
            return null;
        }
    }
}
