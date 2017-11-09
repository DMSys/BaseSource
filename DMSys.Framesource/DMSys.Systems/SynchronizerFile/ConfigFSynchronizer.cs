using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;

namespace DMSys.Systems.SynchronizerFile
{
    /// <summary>
    /// Цели за синхронизиране
    /// </summary>
    [Serializable(), XmlRoot("FSynchronizer")]
    public class ConfigFSynchronizer
    {

        /// <summary>
        /// Списък от цели за синхронизиране
        /// </summary>
        [XmlArray("Targets"), XmlArrayItem("Target")]
        public List<ConfigTarget> Targets = new List<ConfigTarget>();

        /// <summary>
        /// Добавя нова цел за синхронизиране
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public ConfigTarget AddTarget(string source, string destination)
        {
            ConfigTarget ct = new ConfigTarget();
            ct.Source = source;
            ct.Destination = destination;

            this.Targets.Add(ct);
            return ct;
        }

        /// <summary>
        /// Добавя нова цел за синхронизиране
        /// </summary>
        /// <param name="configTarget"></param>
        public void AddTarget(ConfigTarget configTarget)
        {
            this.Targets.Add(configTarget);
        }

        /// <summary>
        /// Глобален списък за игнориране
        /// </summary>
        [XmlArray("GlobalIgnoreList"), XmlArrayItem("Item")]
        public List<ConfigIgnoreItem> GlobalIgnoreList = new List<ConfigIgnoreItem>();

        /// <summary>
        /// Добавя файл за игнориране
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ConfigIgnoreItem AddIgnoreFile(string value)
        {
            ConfigIgnoreItem cii = new ConfigIgnoreItem();
            cii.Value = value;
            cii.Type = SynchItemType.File;

            this.GlobalIgnoreList.Add(cii);
            return cii;
        }

        /// <summary>
        /// Добавя дир. за игнориране
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ConfigIgnoreItem AddIgnoreDirectorie(string value)
        {
            ConfigIgnoreItem cii = new ConfigIgnoreItem();
            cii.Value = value;
            cii.Type = SynchItemType.Directorie;

            this.GlobalIgnoreList.Add(cii);
            return cii;
        }
    }

    /// <summary>
    /// Описание на целта за синхронизация
    /// </summary>
    [Serializable(), XmlRoot("Target")]
    public class ConfigTarget
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name = "";

        /// <summary>
        /// Източник
        /// </summary>
        public string Source = "";

        /// <summary>
        /// Дестинация/Цел
        /// </summary>
        public string Destination = "";

        /// <summary>
        /// Списък за игнориране
        /// </summary>
        [XmlArray("IgnoreList"), XmlArrayItem("Item")]
        public List<ConfigIgnoreItem> IgnoreList = new List<ConfigIgnoreItem>();

        /// <summary>
        /// Добавя файл за игнориране
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ConfigIgnoreItem AddIgnoreFile(string value)
        {
            ConfigIgnoreItem cii = new ConfigIgnoreItem();
            cii.Value = value;
            cii.Type = SynchItemType.File;

            this.IgnoreList.Add(cii);
            return cii;
        }

        /// <summary>
        /// Добавя дир. за игнориране
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ConfigIgnoreItem AddIgnoreDirectorie(string value)
        {
            ConfigIgnoreItem cii = new ConfigIgnoreItem();
            cii.Value = value;
            cii.Type = SynchItemType.Directorie;

            this.IgnoreList.Add(cii);
            return cii;
        }
    }

    /// <summary>
    /// Елемент за игнориране
    /// </summary>
    [Serializable(), XmlRoot("IgnoreItem")]
    public class ConfigIgnoreItem
    {
        /// <summary>
        /// Стойност / Шаблон
        /// </summary>
        public string Value = "";

        /// <summary>
        /// Тип на елемента
        /// </summary>
        public SynchItemType Type = SynchItemType.File;

        public bool Active = true;
    }
}
