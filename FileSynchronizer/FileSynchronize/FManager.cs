using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DMSys.Systems;
using DMSys.Systems.SynchronizerFile;

namespace FileSynchronizer
{
    public partial class FManager : Form
    {
        #region Properties

        /// <summary>
        /// Път до проложението
        /// </summary>
        private string _AppDir = "";

        /// <summary>
        /// Път до конфигурационния файл
        /// </summary>
        private string _ConfigFSynchrPath = "";

        /// <summary>
        /// Цели за синхронизиране
        /// </summary>
        private ConfigFSynchronizer _ConfigFSynchr = null;

        #endregion Properties

        public FManager()
        {
            InitializeComponent();
            // Основни данни
            _AppDir = Path.GetDirectoryName(Application.ExecutablePath);
            _ConfigFSynchrPath = Path.Combine(_AppDir, Application.ProductName + ".Config");
        }

        private void FManager_Load(object sender, EventArgs e)
        {
            try
            {
                LoadConfig();
                LoadTableTargets();
                LoadTableIgnoreList(_ConfigFSynchr.GlobalIgnoreList, dt_GIgnoreList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region ToolStrip

        private void tsb_NewTarget_Click(object sender, EventArgs e)
        {
            try
            {
                using (FTarget_NewEdit fTrgt = new FTarget_NewEdit())
                {
                    fTrgt.CTarget = new ConfigTarget();
                    if (fTrgt.ShowForm())
                    {
                        _ConfigFSynchr.AddTarget(fTrgt.CTarget);
                        SaveConfig();
                        LoadTableTargets();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsb_Synch_Click(object sender, EventArgs e)
        {
            try
            {
                FSynchronizer rf = new FSynchronizer();
                rf.GlobalIgnoreList = _ConfigFSynchr.GlobalIgnoreList;
                FSynchList fSList = rf.GetSynchList(GetCurrentTarget());
                using (FTargetSynchList fTSL = new FTargetSynchList())
                {
                    fTSL.TSynchList = fSList;
                    if (fTSL.ShowForm())
                    {
                        rf.RunSynch(fSList);
                        MessageBox.Show("ok");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsb_SynchAll_Click(object sender, EventArgs e)
        {
            try
            {
                FSynchronizer rf = new FSynchronizer();
                rf.GlobalIgnoreList = _ConfigFSynchr.GlobalIgnoreList;
                foreach (ConfigTarget ct in _ConfigFSynchr.Targets)
                {
                    rf.RunSynch(rf.GetSynchList(ct));
                }
                MessageBox.Show("ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion ToolStrip

        #region PrivateMethod

        /// <summary>
        /// Записва конфигурационния файл
        /// </summary>
        private void SaveConfig()
        {
            ObjectXMLSerializer<ConfigFSynchronizer>.Save(_ConfigFSynchr, _ConfigFSynchrPath);
        }

        /// <summary>
        /// Зарежда конфигурационния файл
        /// </summary>
        private void LoadConfig()
        {
            if (File.Exists(_ConfigFSynchrPath))
            {
                try
                { _ConfigFSynchr = ObjectXMLSerializer<ConfigFSynchronizer>.Load(_ConfigFSynchrPath); }
                catch( Exception ex )
                {
                    throw new Exception("Грешен формат на '" + _ConfigFSynchrPath + "'! " + ex.Message+ ex.StackTrace);
                }
            }
            else
            { _ConfigFSynchr = new ConfigFSynchronizer(); }
        }

        /// <summary>
        /// Зарежда талицата с цели за синхронизиране
        /// </summary>
        private void LoadTableTargets()
        {
            dt_Target.Rows.Clear();
            for (int i = 0; i < _ConfigFSynchr.Targets.Count; i++)
            {
                ConfigTarget ct = _ConfigFSynchr.Targets[i];

                DataRow dr = dt_Target.NewRow();
                dr["tc_TNo"] = (i + 1).ToString();
                dr["tc_TSource"] = ct.Source;
                dr["tc_TDestination"] = ct.Destination;
                dr["tc_TName"] = ct.Name;

                dt_Target.Rows.Add(dr);
            }
        }

        private void EditTarget(ConfigTarget aTarget)
        {
            using (FTarget_NewEdit fTrgt = new FTarget_NewEdit())
            {
                fTrgt.CTarget = aTarget;
                if (fTrgt.ShowForm())
                {
                    SaveConfig();
                    LoadTableTargets();
                }
            }
        }

        /// <summary>
        /// Зарежда таблица с елементи за игнориране
        /// </summary>
        /// <param name="ignoreList"></param>
        /// <param name="ignoreTable"></param>
        private void LoadTableIgnoreList(List<ConfigIgnoreItem> ignoreList, DataTable ignoreTable)
        {
            if (ignoreTable.Rows.Count > 0)
            { ignoreTable.Rows.Clear(); }

            if (ignoreList != null)
            {
                for (int i = 0; i < ignoreList.Count; i++)
                {
                    ConfigIgnoreItem cii = ignoreList[i];
                    if (cii.Type == SynchItemType.Directorie)
                    { ignoreTable.Rows.Add((i + 1).ToString(), Properties.Resources.folder, cii.Value); }
                    else
                    { ignoreTable.Rows.Add((i + 1).ToString(), Properties.Resources.file, cii.Value); }
                }
            }
        }

        private void NewIgnoreItem(List<ConfigIgnoreItem> aIgnoreList, DataTable aIgnoreTable)
        {
            using (FIgnore_NewEdit fIgnore = new FIgnore_NewEdit())
            {
                fIgnore.CIgnoreItem = new ConfigIgnoreItem();
                if (fIgnore.ShowForm())
                {
                    aIgnoreList.Add(fIgnore.CIgnoreItem);
                    SaveConfig();
                    LoadTableIgnoreList(aIgnoreList, aIgnoreTable);
                }
            }
        }

        private void EditIgnoreItem(List<ConfigIgnoreItem> aIgnoreList, ConfigIgnoreItem aIgnoreItem, DataTable aIgnoreTable)
        {
            using (FIgnore_NewEdit fIgnore = new FIgnore_NewEdit())
            {
                fIgnore.CIgnoreItem = aIgnoreItem;
                if (fIgnore.ShowForm())
                {
                    SaveConfig();
                    LoadTableIgnoreList(aIgnoreList, aIgnoreTable);
                }
            }
        }

        private ConfigTarget GetCurrentTarget()
        {
            if (dgv_Targets.CurrentRow == null)
            { return null; }

            Int32 iTargetIndex = Convert.ToInt32(dgv_Targets.CurrentRow.Cells["gc_TNo"].Value) - 1;
            return _ConfigFSynchr.Targets[iTargetIndex];
        }

        private ConfigIgnoreItem GetCurrentLIgnoreItem(List<ConfigIgnoreItem> aIgnoreList)
        {
            if (dgv_LIgnoreList.CurrentRow == null)
            { return null; }

            Int32 iIgnoreItemIndex = Convert.ToInt32(dgv_LIgnoreList.CurrentRow.Cells["gc_LINo"].Value) - 1;
            return aIgnoreList[iIgnoreItemIndex];
        }

        private ConfigIgnoreItem GetCurrentGIgnoreItem(List<ConfigIgnoreItem> aIgnoreList)
        {
            if (dgv_GIgnoreList.CurrentRow == null)
            { return null; }

            Int32 iIgnoreItemIndex = Convert.ToInt32(dgv_GIgnoreList.CurrentRow.Cells["gc_GINo"].Value) - 1;
            return aIgnoreList[iIgnoreItemIndex];
        }

        #endregion PrivateMethod

        #region TargetGridEvent

        private void dgv_Targets_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Int32 iTargetIndex = Convert.ToInt32(dgv_Targets.Rows[e.RowIndex].Cells["gc_TNo"].Value) - 1;

                EditTarget(_ConfigFSynchr.Targets[iTargetIndex]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_Targets_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ConfigTarget ct = GetCurrentTarget();
                if (ct == null)
                { LoadTableIgnoreList(null, dt_LIgnoreList); }
                else
                { LoadTableIgnoreList(ct.IgnoreList, dt_LIgnoreList); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion TargetGridEvent

        #region TargetGridMenu

        private void tsmi_EditTarget_Click(object sender, EventArgs e)
        {
            try
            {
                EditTarget(GetCurrentTarget());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmi_DeleteTarget_Click(object sender, EventArgs e)
        {
            try
            {
                _ConfigFSynchr.Targets.Remove(GetCurrentTarget());
                SaveConfig();
                LoadTableTargets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmi_NewIgnoreLocal_Click(object sender, EventArgs e)
        {
            try
            {
                NewIgnoreItem(GetCurrentTarget().IgnoreList, dt_LIgnoreList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmi_NewIgnoreGlobal_Click(object sender, EventArgs e)
        {
            try
            {
                NewIgnoreItem(_ConfigFSynchr.GlobalIgnoreList, dt_GIgnoreList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmi_SynchTarget_Click(object sender, EventArgs e)
        {
            try
            {
                FSynchronizer rf = new FSynchronizer();
                rf.GlobalIgnoreList = _ConfigFSynchr.GlobalIgnoreList;
                FSynchList fSList = rf.GetSynchList(GetCurrentTarget());
                using (FTargetSynchList fTSL = new FTargetSynchList())
                {
                    fTSL.TSynchList = fSList;
                    if (fTSL.ShowForm())
                    {
                        rf.RunSynch(fSList);
                        MessageBox.Show("ok");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion TargetGridMenu

        #region PrivateEvent GIgnoreList

        /// <summary>
        /// Игноре лист за всички задачи
        /// Двойно кликване: Отваря форма за редакция
        /// </summary>
        private void dgv_GIgnoreList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                EditIgnoreItem(_ConfigFSynchr.GlobalIgnoreList, GetCurrentGIgnoreItem(_ConfigFSynchr.GlobalIgnoreList), dt_GIgnoreList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Игноре лист за всички задачи
        /// При отваряне на менюто определя статуса на елементите
        /// </summary>
        private void cms_GIgnoreG_Opening(object sender, CancelEventArgs e)
        {
            bool bHasRows = (dt_GIgnoreList.Rows.Count > 0);
            tsmi_EditGIgnore.Enabled = bHasRows;
            tsmi_DeleteGIgnore.Enabled = bHasRows;
        }

        /// <summary>
        /// Игноре лист за всички задачи
        /// Отваря форма за редакция
        /// </summary>
        private void tsmi_EditGIgnore_Click(object sender, EventArgs e)
        {
            try
            {
                EditIgnoreItem(_ConfigFSynchr.GlobalIgnoreList, GetCurrentGIgnoreItem(_ConfigFSynchr.GlobalIgnoreList), dt_GIgnoreList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Игноре лист за всички задачи
        /// Изтрива избрания
        /// </summary>
        private void tsmi_DeleteGIgnore_Click(object sender, EventArgs e)
        {
            try
            {
                _ConfigFSynchr.GlobalIgnoreList.Remove(GetCurrentGIgnoreItem(_ConfigFSynchr.GlobalIgnoreList));
                SaveConfig();
                LoadTableIgnoreList(_ConfigFSynchr.GlobalIgnoreList, dt_GIgnoreList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion PrivateEvent GIgnoreList

        #region PrivateEvent LIgnoreList

        /// <summary>
        /// Игноре лист за избраната задача
        /// Двойно кликване: Отваря форма за редакция
        /// </summary>
        private void dgv_LIgnoreList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ConfigTarget ct = GetCurrentTarget();
                EditIgnoreItem(ct.IgnoreList, GetCurrentLIgnoreItem(ct.IgnoreList), dt_LIgnoreList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Игноре лист за избраната задача
        /// При отваряне на менюто определя статуса на елементите
        /// </summary>
        private void cms_LIgnoreG_Opening(object sender, CancelEventArgs e)
        {
            bool bHasRows =  (dt_LIgnoreList.Rows.Count > 0);
            tsmi_EditLIgnore.Enabled = bHasRows;
            tsmi_DeleteLIgnore.Enabled = bHasRows;
        }

        /// <summary>
        /// Игноре лист за избраната задача
        /// Отваря форма за редакция
        /// </summary>
        private void tsmi_EditLIgnore_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigTarget ct = GetCurrentTarget();
                EditIgnoreItem(ct.IgnoreList, GetCurrentLIgnoreItem(ct.IgnoreList), dt_LIgnoreList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Игноре лист за избраната задача
        /// Изтрива избрания
        /// </summary>
        private void tsmi_DeleteLIgnore_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigTarget ct = GetCurrentTarget();
                ct.IgnoreList.Remove(GetCurrentLIgnoreItem(ct.IgnoreList));
                SaveConfig();
                LoadTableIgnoreList(ct.IgnoreList, dt_LIgnoreList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion PrivateEvent LIgnoreList
    }
}
