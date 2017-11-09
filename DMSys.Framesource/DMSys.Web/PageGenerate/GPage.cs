using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Mvc;

namespace DMSys.Web.PageGenerate
{
    /// <summary>
    /// Генерираната страница
    /// </summary>
    public class GPage
    { 
        /// <summary>
        /// Id на страницата
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заглавие на страницата
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Съдържание на страницата
        /// </summary>
        public StringBuilder Content { get; set; }

        /// <summary>
        /// Предоставя страницата в MvcHtmlString
        /// </summary>
        public MvcHtmlString RenderContent()
        {
            if (this.Content == null)
            { return new MvcHtmlString(""); }
            else
            { return new MvcHtmlString(this.Content.ToString()); }
        }
    }

    #region GPageGrid

    public class GPageGrid
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SQL { get; set; }

        public bool WithHead { get; set; }

        public bool WithFoot { get; set; }

        public GPageGridColumnCollection Columns { get; set; }

        public DataTable DataSource { get; set; }
    }

    public class GPageGridColumn
    {
        public int Id { get; set; }

        public string HeadText { get; set; }

        public string FootText { get; set; }

        public string DataField { get; set; }

        public int TypeId { get; set; }

        public GPageGridColumnMenuCollection Menu { get; set; }
    }

    public class GPageGridColumnCollection : List<GPageGridColumn>
    {
    }

    public class GPageGridColumnMenuItem
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public string CommandUrl { get; set; }

        public string CommandValues { get; set; }

        public string[] GetCommandValues()
        {
            if (this.CommandValues == null)
            { return new string[0]; }
            else
            { return this.CommandValues.Split(';'); }
        }
    }

    public class GPageGridColumnMenuCollection : List<GPageGridColumnMenuItem>
    {
    }

    #endregion GPageGrid
    
    /// <summary>
    /// Заявка за нова страница
    /// </summary>
    public class GPageRequest
    {
        public GPageRequest()
        {
            this.Area = "";
            this.Controller = "";
            this.Action = "";
            this.ValueId = 0;
            this.SaveData = false;
        }

        public string Area { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }
        
        /// <summary>
        /// Записва данните
        /// </summary>
        public bool SaveData { get; set; }

        /// <summary>
        /// Ст-ст на заредения елемент
        /// </summary>
        public int ValueId { get; set; }

        /// <summary>
        /// Ст-ти подадени с POST
        /// </summary>
        public System.Collections.Specialized.NameValueCollection PostValues { get; set; }
    }

    /// <summary>
    /// Валидиране на страница
    /// </summary>
    public class GPageValidation
    {
        public bool IsValid
        {
            get
            { return (_Messages.Count == 0); }
        }

        private List<string> _Messages = new List<string>();
        /// <summary>
        /// Съобщения в разултат на валидирането
        /// </summary>
        public List<string> Messages
        {
            get { return _Messages; }
        }

        private List<GPageField> _PageFields = new List<GPageField>();
        /// <summary>
        /// Стойности на полетата
        /// </summary>
        public List<GPageField> PageFields
        {
            get { return _PageFields; }
        }
    }

    /// <summary>
    /// Поле от страницата
    /// </summary>
    public class GPageField
    {
        public string FieldName { get; set; }

        public string FieldType { get; set; }

        public string SqlValue { get; set; }
    }
}
