using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace DMSys.Systems.SynchronizerFile
{
    /// <summary>
    /// Създава списък за синхронизиране.
    /// Изпълнява синхронизирането по създадения списък.
    /// </summary>
    public class FSynchronizer
    {
        #region Properties

        /// <summary>
        /// Глобален списък за игнориране
        /// </summary>
        private List<ConfigIgnoreItem> _GlobalIgnoreList = null;

        /// <summary>
        /// Глобален списък за игнориране
        /// </summary>
        public List<ConfigIgnoreItem> GlobalIgnoreList
        {
            get
            { return _GlobalIgnoreList; }
            set
            { _GlobalIgnoreList = value; }
        } 

        #endregion Properties

        public FSynchronizer()
        { }

        /// <summary>
        /// Създава списък за синхронизиране
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public FSynchList GetSynchList(ConfigTarget target)
        {
            if (target.Source.Equals(""))
            { throw new Exception("Въведи директория източник!"); }
            if (!Directory.Exists(target.Source))
            { throw new Exception("Не съществува директорията на източника!"); }
            if (target.Destination.Equals(""))
            { throw new Exception("Въведи директория цел!"); }

            FSynchList synchList = new FSynchList(target.Source, target.Destination);
            GetSynchList(synchList, target.Source, target.Destination, target.IgnoreList);
            return synchList;
        }

        /// <summary>
        /// Създава списък за синхронизиране
        /// </summary>
        /// <param name="synchList">списък за синхронизиране</param>
        /// <param name="sourceBaseDir">източник (дир.)</param>
        /// <param name="destinationBaseDir">целева директория</param>
        /// <param name="ignoreList">игнорирани елементи</param>
        private void GetSynchList(FSynchList synchList, string sourceBaseDir, string destinationBaseDir, List<ConfigIgnoreItem> ignoreList)
        {
            // Синхронизира файлове
            string[] sourceFileList = Directory.GetFiles(sourceBaseDir);
            foreach (string sourceFile in sourceFileList)
            {
                // Ако файла не е игнориран
                FileInfo sourceFileInfo = new FileInfo(sourceFile);
                if (!IsIgnore(ignoreList, sourceFileInfo.Name, SynchItemType.File))
                {
                    string destinationFile = Path.Combine(destinationBaseDir, sourceFileInfo.Name);
                    FileInfo destinationFileInfo = new FileInfo(destinationFile);
                    // файла не същесвува в целевата директория
                    if (!destinationFileInfo.Exists)
                    { synchList.AddItem(sourceFileInfo.FullName, SynchItemType.File, SynchItemStatus.New); }
                    // файла е променен
                    else if (sourceFileInfo.LastWriteTimeUtc > destinationFileInfo.LastWriteTimeUtc)
                    { synchList.AddItem(sourceFileInfo.FullName, SynchItemType.File, SynchItemStatus.Modified); }
                }
            }
            // Синхронизира дир.
            string[] sourceDirList = Directory.GetDirectories(sourceBaseDir);
            foreach (string sourceDir in sourceDirList)
            {
                string sourceDirName = Path.GetFileName(sourceDir);
                if (!IsIgnore(ignoreList, Path.GetFileName(sourceDirName), SynchItemType.Directorie))
                {
                    string targetDir = Path.Combine(destinationBaseDir, sourceDirName);
                    if (!Directory.Exists(targetDir))
                    { synchList.AddItem(sourceDir, SynchItemType.Directorie, SynchItemStatus.New); }

                    // Стартира синхронизирането за подир.
                    GetSynchList(synchList, sourceDir, targetDir, ignoreList);
                }
            }
        }

        /// <summary>
        /// Синхронизира по зададен списък
        /// </summary>
        /// <param name="synchList"></param>
        public void RunSynch(FSynchList synchList)
        {
            foreach (FSynchItem si in synchList.Items)
            {
                if (si.Active)
                {
                    switch (si.Type)
                    {
                        case SynchItemType.File:
                            string sourceFile = Path.Combine(synchList.Source, si.Value.Trim('\\'));
                            string destinationFile = Path.Combine(synchList.Destination, si.Value.Trim('\\'));
                            File.Copy(sourceFile, destinationFile, true); 
                            break;
                        case SynchItemType.Directorie:
                            string destinationDir = Path.Combine(synchList.Destination, si.Value.Trim('\\'));
                            Directory.CreateDirectory(destinationDir);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Проверява елемента дали е в списъка за игнориране
        /// </summary>
        /// <param name="ignoreList">Списък за игнориране на задачата(локален)</param>
        /// <param name="itemName">Наименование на елемент</param>
        /// <param name="itemType">Тип на елемент</param>
        /// <returns></returns>
        private bool IsIgnore(List<ConfigIgnoreItem> ignoreList, string itemName, SynchItemType itemType)
        {
            string itemNameLower = itemName.ToLower();
            // Проверява в глобалния списък
            foreach (ConfigIgnoreItem cii in _GlobalIgnoreList)
            {
                if (IsIgnore(cii, itemNameLower, itemType))
                { return true; }
            }
            // Проверява в локалния списък
            foreach (ConfigIgnoreItem cii in ignoreList)
            {
                if (IsIgnore(cii, itemNameLower, itemType))
                { return true; }
            }
            return false;
        }

        /// <summary>
        /// Проверява елемента дали е игнориран
        /// </summary>
        /// <param name="ignoreItem">Елемент за игнориране</param>
        /// <param name="itemName">Наименование на елемент</param>
        /// <param name="itemType">Тип на елемент</param>
        /// <returns></returns>
        private bool IsIgnore(ConfigIgnoreItem ignoreItem, string itemName, SynchItemType itemType)
        {
            if ((ignoreItem.Type == itemType) && ignoreItem.Active)
            {
                // Преобразува игноре стойноста в RegularExpressions
                string ignoreValue = ignoreItem.Value.Replace("*", @"\w+");
                // Проверява за съвпадения
                if (Regex.IsMatch(itemName, ignoreValue, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                { return true; }
                else
                { return false; }
            }
            else
            {
                return false;
            }
        }
    }
}
