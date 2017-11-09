using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;

namespace DMSys.Net.HTMLDocParser
{
    public static class HTMLDoc
    {
        #region Select

        public static HtmlElement SelectByTagName(HtmlElement aElement, string aPath)
        {
            string[] mPath = aPath.Split('/');

            if (mPath.Length == 0)
            { return null; }

            HtmlElement selTag = aElement;

            foreach (string sTag in mPath)
            {
                if (sTag == "")
                { return null; }

                selTag = SelectTagName(selTag, sTag);

                if (selTag == null)
                { return null; }
            }
            return selTag;
        }

        private static HtmlElement SelectTagName(HtmlElement aElement, string aTagName)
        {
            for (int i = 0; i < aElement.Children.Count; i++)
            {
                HtmlElement elm = aElement.Children[i];
                if (elm.TagName.Equals(aTagName))
                {
                    return elm;
                }
            }
            return null;
        }

        public static HtmlElement SelectByTagIndex(HtmlElement aElement, string aPath)
        {
            string[] mPath = aPath.Split('/');

            if (mPath.Length == 0)
            { return null; }

            HtmlElement selTag = aElement;

            foreach (string sTag in mPath)
            {
                if (sTag == "")
                { return null; }

                selTag = selTag.Children[Int32.Parse(sTag)];

                if (selTag == null)
                { return null; }
            }
            return selTag;
        }

        #endregion Select

        #region Convert

        public static DataTable ConvertToDataTable(HtmlElement aElement)
        {
            string sTableTagName = aElement.TagName.ToUpper();
            string sRowTagName = "";
            switch( sTableTagName )
            {
                case "TABLE":
                    sRowTagName = "TR";
                    break;
                case "UL":
                    sRowTagName = "LI";
                    break;
                default:
                    throw new Exception("Неуспешно конвертиране на '" + aElement.TagName + "' в DataTable."); 
            }
            if (aElement.Children.Count == 0)
            { return null; }
            //
            DataTable dt = new DataTable();
            //
            if (aElement.Children[0].TagName.ToUpper() == sRowTagName)
            {
                DataTable_AddRows(dt, aElement);
            }
            else
            {
                foreach (HtmlElement elm in aElement.Children)
                {
                    if (elm.TagName.ToUpper() == "TBODY")
                    { DataTable_AddRows(dt, elm); }
                }
            }
            return dt;
        }

        private static void DataTable_AddRows(DataTable aDTable, HtmlElement aElement)
        {
            // Редове
            foreach (HtmlElement elmntTR in aElement.Children)
            {
                DataRow dr = aDTable.NewRow();
                int iDTColumnIndex = 0;
                // Клети на реда
                foreach (HtmlElement elmnt in elmntTR.Children)
                {
                    // Ако колоните са недостатъчо - добавя нови
                    while (iDTColumnIndex >= aDTable.Columns.Count)
                    {
                        int iClnIndex = 0; // Номер на колона
                        if (aDTable.Columns.Count > 0)
                        { iClnIndex = aDTable.Columns.Count; }
                        aDTable.Columns.Add("Column" + (iClnIndex+1).ToString());
                    }
                    // ст-ст на клетката
                    if (elmnt.OuterHtml == null)
                    { dr[iDTColumnIndex] = ""; }
                    else
                    { dr[iDTColumnIndex] = elmnt.OuterHtml.Trim(); }
                    iDTColumnIndex++;
                }
                aDTable.Rows.Add(dr);
            }
        }

        private static void DataTable_AddRows_2(DataTable aDTable, HtmlElement aElement)
        {
            // Редове
            foreach (HtmlElement elmntTR in aElement.Children)
            {
                DataRow dr = aDTable.NewRow();
                int iDTColumnIndex = 0;
                // Клети на реда
                foreach (HtmlElement elmnt in elmntTR.Children)
                {
                    // Ако колоните са недостатъчо - добавя нови
                    while (iDTColumnIndex >= aDTable.Columns.Count)
                    {
                        int iClnIndex = 0; // Номер на двойката колонки
                        if (aDTable.Columns.Count > 0)
                        {
                            iClnIndex = aDTable.Columns.Count/2;
                        }
                        aDTable.Columns.Add("ColumnInner_" + iClnIndex.ToString());
                        aDTable.Columns.Add("ColumnOuter_" + iClnIndex.ToString());
                    }
                    // ст-ст на клетката: Inner
                    if (elmnt.InnerHtml == null)
                    { dr[iDTColumnIndex] = "";  }
                    else
                    { dr[iDTColumnIndex] = elmnt.InnerHtml.Trim(); }
                    iDTColumnIndex++;

                    // ст-ст на клетката: Outer
                    if (elmnt.OuterHtml == null)
                    { dr[iDTColumnIndex] = ""; }
                    else
                    { dr[iDTColumnIndex] = elmnt.OuterHtml.Trim(); }
                    iDTColumnIndex++;
                }
                aDTable.Rows.Add(dr);
            }
        }

        #endregion Convert
    }
}
