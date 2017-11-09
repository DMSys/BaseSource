using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBStudio.Generate
{
    public partial class FEditTable : Form
    {
        #region Properties

        private int _MarginTop = 5;
        private int _MarginLeft = 10;

        private DBStudioData _SData = null;

        /// <summary>
        /// Описание на заредената таблица
        /// </summary>
        private DBTable _Table = null;

        #endregion Properties

        public FEditTable(DBStudioData studioData)
        {
            InitializeComponent();
            _SData = studioData;
        }

        public DialogResult ShowForm(Int32 tableID)
        {
            DBTable dbTable = _SData.DBConfig.GetTable(tableID);

            this.Text = dbTable.Caption;
            
            int itemLabelWidth = 100;
            int itemValueWidth = 250;
            int itemHeight = 21;

            // Ширина на формата
            int clientSizeWidth = _MarginLeft + itemLabelWidth + _MarginLeft + itemValueWidth + _MarginLeft;
            this.Width = (this.Width - this.ClientSize.Width) + clientSizeWidth;

            LoadFormItems(dbTable.Columns, itemLabelWidth, itemValueWidth, itemHeight);
            
            return ShowDialog();
        }

        /// <summary>
        /// Зарежда колоните на таблицата, като елементи на формата
        /// </summary>
        /// <param name="tableColumns"></param>
        /// <param name="itemLabelWidth"></param>
        /// <param name="itemValueWidth"></param>
        /// <param name="itemHeight"></param>
        private void LoadFormItems(List<DBTableColumn> tableColumns, int itemLabelWidth,
            int itemValueWidth, int itemHeight)
        {
            int itemTop = 10;
            foreach (DBTableColumn column in tableColumns)
            {
                Label lbl = new Label();
                lbl.Text = column.Caption;
                lbl.Top = itemTop;
                lbl.Left = _MarginLeft;
                lbl.Width = itemLabelWidth;
                this.Controls.Add(lbl);

                TextBox tb = new TextBox();
                tb.Text = "";
                tb.Top = itemTop;
                tb.Left = _MarginLeft + itemLabelWidth + _MarginLeft;
                tb.Width = itemValueWidth;
                this.Controls.Add(tb);

                // За следващия ред от елементи
                itemTop += itemHeight;
            }
            // Премества бутоните
            btn_Close.Top = itemTop + _MarginTop;
            btn_Close.Left = _MarginLeft + itemLabelWidth + _MarginLeft +
                itemValueWidth - btn_Close.Width;

            btn_Save.Top = itemTop + _MarginTop;
            btn_Save.Left = btn_Close.Left - btn_Save.Width;

            // Височина на формата
            int clientSizeHeight = btn_Save.Top + btn_Save.Height + _MarginTop;
            this.Height = (this.Height - this.ClientSize.Height) + clientSizeHeight;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}