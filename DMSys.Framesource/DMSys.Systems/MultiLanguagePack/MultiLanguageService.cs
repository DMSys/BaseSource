using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DMSys.Systems.MultiLanguagePack
{
    public class MultiLanguageService
    {
        #region Properties

        /// <summary>
        /// Път до файла с превод
        /// </summary>
        public string FileName = "";

        /// <summary>
        /// Превод на програмата в избрания език
        /// </summary>
        private LanguagePack _LPack = new LanguagePack();
        public LanguagePack LPack
        {
            get
            { return _LPack; }
            set
            { _LPack = value; }
        }

        /// <summary>
        /// Език
        /// </summary>
        public string LanguageName
        {
            get
            { return _LPack.LanguageName; }
            set
            { _LPack.LanguageName = value; }
        }

        /// <summary>
        /// Има ли промяна в преведената форма
        /// </summary>
        private bool _IsEditLngPack = false;

        #endregion Properties

        #region Load Form Controls

        /// <summary>
        /// Зарежда Name и Text на контролите от формата
        /// Зарежда масив за превод
        /// </summary>
        public void FormLoadControls(Form aForm, string[] aTArea)
        {
            // Зарежда Name и Text на контролите от формата
            FormLoadControls(aForm);

            // Зарежда масив за превод
            FormTranslateArea(aForm.ToString().Split(',')[0].Trim(), aTArea);
        }

        /// <summary>
        /// Зарежда Name и Text на контролите от формата
        /// Зарежда масив за превод
        /// </summary>
        public void FormLoadControls(Control aControl, string[] aTArea)
        {
            // Зарежда Name и Text на контролите от формата
            FormLoadControls(aControl);

            // Зарежда масив за превод
            FormTranslateArea(aControl.ToString().Split(',')[0].Trim(), aTArea);
        }

        /// <summary>
        /// Зарежда Name и Text на контролите от формата
        /// </summary>
        public void FormLoadControls(Form aForm)
        {
            // Взема уникално име за формата
            string sOwner = aForm.ToString().Split(',')[0].Trim();
            TranslateCollection TCllctn = _LPack.GetCollection(sOwner);
            if (TCllctn == null)
            {
                _IsEditLngPack = true;
                //
                TCllctn = new TranslateCollection();
                TCllctn.TOwner = sOwner;
                TCllctn.TItem.TName = aForm.Name;
                TCllctn.TItem.TText = aForm.Text;
                TCllctn.TItem.TTextOrg = aForm.Text;
                TCllctn.TItem.TType = aForm.GetType().ToString();
                //
                _LPack.TCollections.Add(TCllctn);
            }
            //
            if (TCllctn.TItem.TName.Equals(""))
            {
                _IsEditLngPack = true;
                //
                TCllctn.TItem.TName = aForm.Name;
                TCllctn.TItem.TText = aForm.Text;
                TCllctn.TItem.TTextOrg = aForm.Text;
                TCllctn.TItem.TType = aForm.GetType().ToString();
            }
            // Добавя контролите в списъка за превод
            LoadControls(TCllctn.TItem, aForm.Controls);
        }

        /// <summary>
        /// Зарежда Name и Text на контролите от контролите
        /// </summary>
        public void FormLoadControls(Control aControl)
        {
            // Взема уникално име за формата
            string sOwner = aControl.ToString().Split(',')[0].Trim();
            TranslateCollection TCllctn = _LPack.GetCollection(sOwner);
            if (TCllctn == null)
            {
                _IsEditLngPack = true;
                //
                TCllctn = new TranslateCollection();
                TCllctn.TOwner = sOwner;
                TCllctn.TItem.TName = aControl.Name;
                TCllctn.TItem.TText = aControl.Text;
                TCllctn.TItem.TTextOrg = aControl.Text;
                TCllctn.TItem.TType = aControl.GetType().ToString();
                //
                _LPack.TCollections.Add(TCllctn);
            }
            //
            if (TCllctn.TItem.TName.Equals(""))
            {
                _IsEditLngPack = true;
                //
                TCllctn.TItem.TName = aControl.Name;
                TCllctn.TItem.TText = aControl.Text;
                TCllctn.TItem.TTextOrg = aControl.Text;
                TCllctn.TItem.TType = aControl.GetType().ToString();
            }
            // Добавя контролите в списъка за превод
            LoadControls(TCllctn.TItem, aControl.Controls);
        }

        /// <summary>
        /// Добавя контролите в списъка за превод
        /// </summary>
        private void LoadControls(TranslateItem aTCllctn, Control.ControlCollection aControls)
        {
            if (aControls != null)
            {
                // Добавя контролите в списъка за превод
                foreach (Control cntr in aControls)
                {
                    // Търси превода
                    TranslateItem tCrntItem = aTCllctn.GetItem(cntr.Name);
                    // Добавя ако несъществува
                    if (tCrntItem==null)
                    {
                        _IsEditLngPack = true;
                        tCrntItem = aTCllctn.ItemAdd(cntr.Name, cntr.Text, cntr.GetType());
                    }
                    // Добавя под елементите според типовете
                    Type CntrTp = cntr.GetType();
                    // MenuStrip
                    if (CntrTp == typeof(MenuStrip))
                    {
                        Load_MenuStrip(tCrntItem, (MenuStrip)cntr);
                    }
                    // TableLayoutPanel
                    else if (CntrTp == typeof(TableLayoutPanel))
                    {
                        LoadControls(tCrntItem, ((TableLayoutPanel)cntr).Controls);
                    }
                    // SplitContainer
                    else if (CntrTp == typeof(SplitContainer))
                    {
                        Load_SplitContainer(tCrntItem, ((SplitContainer)cntr));
                    }
                    // DataGridView
                    else if (CntrTp == typeof(DataGridView))
                    {
                        Load_DataGridView(tCrntItem, ((DataGridView)cntr));
                    }
                    // ToolStrip
                    else if (CntrTp == typeof(ToolStrip))
                    {
                        Load_ToolStrip(tCrntItem, ((ToolStrip)cntr));
                    }
                    else
                    {
                        LoadControls(tCrntItem, cntr.Controls);
                    }
                }
            }
        }

        /// <summary>
        /// Зарежда масив за превод
        /// </summary>
        public void FormTranslateArea(string aOwner, string[] aTArea)
        {
            // Зарежда масив за превод
            if ((aTArea != null) && (aTArea.Length > 0))
            {
                TranslateCollection TCllctn = _LPack.GetCollection(aOwner);
                if (TCllctn != null)
                {
                    // Маха излишните преводи
                    for (int rem = TCllctn.TranslateArea.Count; rem > aTArea.Length; rem--)
                    {
                        TCllctn.TranslateArea.Remove(TCllctn.TranslateArea[rem - 1]);
                        _IsEditLngPack = true;
                    }
                    // Добавя и корегира преводите
                    for (int i = 0; i < aTArea.Length; i++)
                    {
                        if (TCllctn.TranslateArea.Count > i)
                        {
                            if (!TCllctn.TranslateArea[i].TTextOrg.Equals(aTArea[i]))
                            {
                                TCllctn.TranslateArea[i].TTextOrg = aTArea[i];
                                _IsEditLngPack = true;
                            }
                        }
                        else
                        {
                            TCllctn.TranslateArea.Add(new TranslateAreaItem(aTArea[i]));
                            _IsEditLngPack = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Зарежда Name и Text на контролите от MenuStrip
        /// </summary>
        private void Load_MenuStrip(TranslateItem aTItem, MenuStrip ctrMnStrp)
        {
            if (aTItem == null)
            { return; }
            foreach (ToolStripMenuItem tsmi in ctrMnStrp.Items)
            {
                TranslateItem NewTItem = aTItem.GetItem(tsmi.Name);
                if (NewTItem == null)
                {
                    _IsEditLngPack = true;
                    NewTItem = aTItem.ItemAdd(tsmi.Name, tsmi.Text, tsmi.GetType());
                }
                //
                Load_ToolStripItems(NewTItem, tsmi.DropDownItems);
            }
        }
        
        /// <summary>
        /// Зарежда Name и Text на контролите от MenuStrip
        /// </summary>
        private void Load_SplitContainer(TranslateItem aTItem, SplitContainer aSpltCntnr)
        {
            if (aTItem == null)
            { return; }
            //
            TranslateItem NewTItem = null;
            // Panel1
            NewTItem = aTItem.GetItem("Panel1");
            if (NewTItem == null)
            {
                _IsEditLngPack = true;
                NewTItem = aTItem.ItemAdd("Panel1", "", aSpltCntnr.Panel1.GetType());
                LoadControls(NewTItem, aSpltCntnr.Panel1.Controls);
            }
            // Panel2
            NewTItem = aTItem.GetItem("Panel2");
            if (NewTItem == null)
            {
                _IsEditLngPack = true;
                NewTItem = aTItem.ItemAdd("Panel2", "", aSpltCntnr.Panel2.GetType());
                LoadControls(NewTItem, aSpltCntnr.Panel2.Controls);
            }
        }

        /// <summary>
        /// Зарежда Name и Text на контролите от ToolStrip
        /// </summary>
        private void Load_ToolStrip(TranslateItem aTItem, ToolStrip aTlStrip)
        {
            if (aTItem == null)
            { return; }
            foreach (ToolStripItem tsmi in aTlStrip.Items)
            {
                TranslateItem NewTItem = aTItem.GetItem(tsmi.Name);
                if (NewTItem == null)
                {
                    _IsEditLngPack = true;
                    NewTItem = aTItem.ItemAdd(tsmi.Name, tsmi.Text, tsmi.GetType());
                }
                // ToolStripMenuItem
                if (tsmi.GetType() == typeof(ToolStripSplitButton))
                { Load_ToolStripItems(NewTItem, ((ToolStripSplitButton)tsmi).DropDownItems); }
            }
        }

        /// <summary>
        /// Зарежда Name и Text на контролите от ToolStripItemCollection
        /// </summary>
        private void Load_ToolStripItems(TranslateItem aTItem, ToolStripItemCollection aTlStrpItms)
        {
            foreach (ToolStripItem tsi in aTlStrpItms)
            {
                if (tsi.GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem tsmi = (ToolStripMenuItem)tsi;
                    TranslateItem NewTItem = aTItem.GetItem(tsmi.Name);
                    if (NewTItem == null)
                    {
                        _IsEditLngPack = true;
                        NewTItem = aTItem.ItemAdd(tsmi.Name, tsmi.Text, tsmi.GetType());
                    }
                    //
                    Load_ToolStripItems(NewTItem, tsmi.DropDownItems);
                }
            }
        }

        /// <summary>
        /// Зарежда Name и Text на Column от DataGridView
        /// </summary>
        private void Load_DataGridView(TranslateItem aTItem, DataGridView aDataGridView)
        {
            if (aTItem == null)
            { return; }
            foreach (DataGridViewColumn dgvc in aDataGridView.Columns)
            {
                TranslateItem NewTItem = aTItem.GetItem(dgvc.Name);
                if (NewTItem == null)
                {
                    _IsEditLngPack = true;
                    NewTItem = aTItem.ItemAdd(dgvc.Name, dgvc.HeaderText, dgvc.GetType());
                }
            }
        }

        #endregion Load Form Controls

        #region Set Form Controls

        /// <summary>
        /// Зарежда Name и Text на контролите в формата
        /// </summary>
        public void FormSetControls(Form aForm, string[] aTArea)
        {
            // Зарежда Name и Text на контролите в формата
            FormSetControls(aForm);
            //
            string sOwner = aForm.ToString().Split(',')[0].Trim();
            TranslateCollection TCllctn = _LPack.GetCollection(sOwner);
            for (int i = 0; i < aTArea.Length; i++)
            {
                if (TCllctn.TranslateArea.Count > i)
                { aTArea[i] = TCllctn.TranslateArea[i].TText; }
            }
        }

        /// <summary>
        /// Зарежда Name и Text на контролите в формата
        /// </summary>
        public void FormSetControls(Control aControl, string[] aTArea)
        {
            // Зарежда Name и Text на контролите в формата
            FormSetControls(aControl);
            //
            string sOwner = aControl.ToString().Split(',')[0].Trim();
            TranslateCollection TCllctn = _LPack.GetCollection(sOwner);
            for (int i = 0; i < aTArea.Length; i++)
            {
                if (TCllctn.TranslateArea.Count > i)
                { aTArea[i] = TCllctn.TranslateArea[i].TText; }
            }
        }

        /// <summary>
        /// Зарежда Name и Text на контролите в формата
        /// </summary>
        public void FormSetControls(Form aForm)
        {
            // Определя коя е формата
            string sOwner = aForm.ToString().Split(',')[0].Trim();
            TranslateCollection TCllctn = _LPack.GetCollection(sOwner);
            if (TCllctn != null)
            {
                aForm.Text = TCllctn.TItem.TText;
                // Превежда контролите
                SetControls(TCllctn.TItem, aForm.Controls);
            }
        }

        /// <summary>
        /// Зарежда Name и Text на контролите в Control
        /// </summary>
        public void FormSetControls(Control aControl)
        {
            // Определя коя е формата
            string sOwner = aControl.ToString().Split(',')[0].Trim();
            TranslateCollection TCllctn = _LPack.GetCollection(sOwner);
            if (TCllctn != null)
            {
                aControl.Text = TCllctn.TItem.TText;
                // Превежда контролите
                SetControls(TCllctn.TItem, aControl.Controls);
            }
        }

        /// <summary>
        /// Превежда контролите
        /// </summary>
        private void SetControls(TranslateItem aTCllctn, Control.ControlCollection aControls)
        {
            // Превежда контролите
            foreach (TranslateItem ti in aTCllctn.TItems)
            {
                try
                {
                    // MenuStrip
                    if (ti.TType == typeof(MenuStrip).ToString())
                    {
                        MenuStrip ms = (MenuStrip)aControls[ti.TName];
                        ms.Text = ti.TText;
                        //
                        Set_MenuStrip(ti, ms);
                    }
                    // TableLayoutPanel
                    else if (ti.TType == typeof(TableLayoutPanel).ToString())
                    {
                        TableLayoutPanel tlp = (TableLayoutPanel)aControls[ti.TName];
                        SetControls(ti, tlp.Controls);
                    }
                    // DataGridView
                    else if (ti.TType == typeof(DataGridView).ToString())
                    {
                        DataGridView dgv = (DataGridView)aControls[ti.TName];
                        Set_DataGridView(ti, dgv);
                    }
                    // ToolStrip
                    else if (ti.TType == typeof(ToolStrip).ToString())
                    {
                        ToolStrip ts = (ToolStrip)aControls[ti.TName];
                        ts.Text = ti.TText;
                        Set_ToolStrip(ti, ts);
                    }
                    //
                    // SplitContainer
                    else if (ti.TType == typeof(SplitContainer).ToString())
                    {
                        SplitContainer sc = (SplitContainer)aControls[ti.TName];
                        Set_SplitContainer(ti, sc);
                    }
                    else
                    {
                        aControls[ti.TName].Text = ti.TText;
                        SetControls(ti, aControls[ti.TName].Controls);
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// Зарежда Name и Text на контролите в MenuStrip
        /// </summary>
        private void Set_MenuStrip(TranslateItem aTItem, MenuStrip ctrMnStrp)
        {
            foreach (TranslateItem ti in aTItem.TItems)
            {
                try
                {
                    ToolStripMenuItem tsmi = (ToolStripMenuItem)ctrMnStrp.Items[ti.TName];
                    tsmi.Text = ti.TText;
                    //
                    Set_ToolStripItems(ti,tsmi.DropDownItems);
                }
                catch { }
            }
        }

        /// <summary>
        /// Зарежда Name и Text на контролите в SplitContainer
        /// </summary>
        private void Set_SplitContainer(TranslateItem aTItem, SplitContainer aSpltCntnr)
        {
            foreach (TranslateItem ti in aTItem.TItems)
            {
                try
                {
                    switch (ti.TName)
                    {
                        case "Panel1":
                            SetControls(ti, aSpltCntnr.Panel1.Controls);
                            break;
                        case "Panel2":
                            SetControls(ti, aSpltCntnr.Panel2.Controls);
                            break;
                        default:
                            break;
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// Зарежда Name и Text на контролите в ToolStripMenuItem
        /// </summary>
        private void Set_ToolStripItems(TranslateItem aTItem, ToolStripItemCollection aTlStrpItms)
        {
            foreach (TranslateItem ti in aTItem.TItems)
            {
                try
                {
                    ToolStripItem tsi = (ToolStripItem)aTlStrpItms[ti.TName];
                    tsi.Text = ti.TText;
                    //
                    if (tsi.GetType() == typeof(ToolStripMenuItem))
                    { Set_ToolStripItems(ti, ((ToolStripMenuItem)tsi).DropDownItems); }
                }
                catch { }
            }
        }

        /// <summary>
        /// Зарежда Name и Text на Column в DataGridView
        /// </summary>
        private void Set_DataGridView(TranslateItem aTItem, DataGridView aDataGridView)
        {
            foreach (TranslateItem ti in aTItem.TItems)
            {
                try
                {
                    DataGridViewColumn dgvc = aDataGridView.Columns[ti.TName];
                    dgvc.HeaderText = ti.TText;
                }
                catch { }
            }
        }

        /// <summary>
        /// Зарежда Name и Text на контролите в ToolStrip
        /// </summary>
        private void Set_ToolStrip(TranslateItem aTItem, ToolStrip aToolStrip)
        {
            foreach (TranslateItem ti in aTItem.TItems)
            {
                try
                {
                    ToolStripItem tsi = (ToolStripItem)aToolStrip.Items[ti.TName];
                    tsi.Text = ti.TText;
                    //
                    if (tsi.GetType() == typeof(ToolStripSplitButton))
                    { Set_ToolStripItems(ti, ((ToolStripSplitButton)tsi).DropDownItems); }
                }
                catch { }
            }
        }

        #endregion Set Form Controls

        #region File Tools

        /// <summary>
        /// Запис на контролите в XML
        /// </summary>
        public void SaveChangeFile()
        {
            if (_IsEditLngPack)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FileName));
                ObjectXMLSerializer<LanguagePack>.Save(_LPack, FileName);
                _IsEditLngPack = false;
            }
        }

        /// <summary>
        /// Запис на контролите в XML
        /// </summary>
        public void SaveFile()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FileName));
            ObjectXMLSerializer<LanguagePack>.Save(_LPack, FileName);
        }

        /// <summary>
        /// Запис на контролите в XML
        /// </summary>
        public void LoadFile()
        {
            _LPack.Clear();
            if (File.Exists(FileName))
            { _LPack = ObjectXMLSerializer<LanguagePack>.Load(FileName); }

            // Изравняване форматите при превод
            if (_LPack != null)
            {
                foreach (TranslateCollection tc in _LPack.TCollections)
                {
                    foreach (TranslateItem ti in tc.TItems)
                    {
                        tc.TItem.TItems.Add(ti);
                        _IsEditLngPack = true;
                    }
                    tc.TItems.Clear();
                }
            }
        }

        #endregion File Tools
    }
}

