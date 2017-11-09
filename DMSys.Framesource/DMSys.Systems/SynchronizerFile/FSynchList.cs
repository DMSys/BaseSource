using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Systems.SynchronizerFile
{
    /// <summary>
    /// Списък за синхронизиране
    /// </summary>
    public class FSynchList
    {
        /// <summary>
        /// Главна дир. на източника
        /// </summary>
        public string Source = "";

        /// <summary>
        /// Главна дир. на целта
        /// </summary>
        public string Destination = "";

        /// <summary>
        /// Списък на елементите
        /// </summary>
        public List<FSynchItem> Items = new List<FSynchItem>();

        public FSynchList(string sourceDir, string destinationDir)
        {
            this.Source = sourceDir;
            this.Destination = destinationDir;
        }

        /// <summary>
        /// Добавя елемент
        /// </summary>
        /// <param name="itemValue">Наименование</param>
        /// <param name="itemType">Тип</param>
        /// <param name="itemStatus">Статус/Прчина</param>
        public void AddItem(string itemValue, SynchItemType itemType, SynchItemStatus itemStatus)
        {
            FSynchItem si = new FSynchItem();
            si.Type = itemType;
            si.Status = itemStatus;

            if (itemValue.StartsWith(this.Source))
            { si.Value = itemValue.Substring(this.Source.Length, itemValue.Length - this.Source.Length); }
            else
            { si.Value = itemValue; }

            this.Items.Add(si);
        }
    }

    /// <summary>
    /// Елемент за синхронизация
    /// </summary>
    public class FSynchItem
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Value = "";

        /// <summary>
        /// Тип на елемента
        /// </summary>
        public SynchItemType Type = SynchItemType.File;

        /// <summary>
        /// Статус/Причина за синхронизиране
        /// </summary>
        public SynchItemStatus Status = SynchItemStatus.New;

        /// <summary>
        /// да бъде ли синхронизиран
        /// </summary>
        public bool Active = true;
    }
}
