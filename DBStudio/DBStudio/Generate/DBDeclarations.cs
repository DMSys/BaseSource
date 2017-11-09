using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBStudio.Generate
{
    /// <summary>
    /// Описание на таблица
    /// </summary>
    public class DBTable
    {
        /// <summary>
        /// Наименование от базата
        /// </summary>
        public string Name = "";

        /// <summary>
        /// Наименование
        /// </summary>
        public string Caption = "";

        /// <summary>
        /// Списък на колонките
        /// </summary>
        public List<DBTableColumn> Columns = new List<DBTableColumn>();
    }

    /// <summary>
    /// Колонка на таблица
    /// </summary>
    public class DBTableColumn
    {
        public int Id = 0;

        /// <summary>
        /// Наименование от базата
        /// </summary>
        public string Name = "";

        /// <summary>
        /// Тип от базата
        /// </summary>
        public string DataType = "";

        /// <summary>
        /// Наименование
        /// </summary>
        public string Caption = "";

        /// <summary>
        /// Начин на визуализация
        /// </summary>
        public VisualComponent VComponent = VisualComponent.TextBox;

        /// <summary>
        /// Пореден номер (при сортиране)
        /// </summary>
        public int OrderNo = 0;
    }

    public enum VisualComponent { TextBox, ComboBox, DateTime, Integer, Double }
}
