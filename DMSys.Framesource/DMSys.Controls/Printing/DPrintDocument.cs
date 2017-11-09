using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace DMSys.Controls.Printing
{
    public enum DPrintBorderType { None, Solid }
    public enum DPrintSizeType { Fixed, Percent }
    public enum DPrintAlignment
    {
        None, 
        /// <summary>
        /// от ляво на дясно
        /// </summary>
        Near, 
        /// <summary>
        /// от дясно на ляво
        /// </summary>
        Far,
        Center 
    }

    public class DPrintDocument
    {
        private List<DPrintItem> _Items = new List<DPrintItem>();
        public List<DPrintItem> Items
        {
            get
            { return _Items; }
        }

        public void AddItemText(string text, Font printFont = null, DPrintAlignment alignment = DPrintAlignment.None)
        {
            DPrintItemText item = new DPrintItemText();
            item.Text = text;
            item.PrintFont = printFont;
            item.Alignment = alignment;

            _Items.Add(item);
        }

        public void AddItemBlank(float height)
        {
            DPrintItemBlank item = new DPrintItemBlank();
            item.Height = height;

            _Items.Add(item);
        }
    }

    public class DPrintItem
    {
        public DPrintBorderType Border = DPrintBorderType.None;

        public Color BackgroundColor { get; set; }

        public Margins Margins = new Margins(0, 0, 0, 0);
    }

    /// <summary>
    /// Празно място
    /// </summary>
    public class DPrintItemBlank : DPrintItem
    {
        public float Height = 10;
    }

    /// <summary>
    /// Текст
    /// </summary>
    public class DPrintItemText : DPrintItem
    {
        public string Text { get; set; }

        public Font PrintFont { get; set; }

        public DPrintAlignment Alignment = DPrintAlignment.None;

        /// <summary>
        /// Брой редове на текста
        /// </summary>
        public int CountTextLine = 1;
    }

    /// <summary>
    /// От средата на страница
    /// </summary>
    public class DPrintFromMiddlePage : DPrintItem
    { 
    }
    /*
    /// <summary>
    /// Нова страница
    /// </summary>
    public class DPrintNewPage : DPrintItem
    {
    }
    */

    #region DPrintItemTable

    /// <summary>
    /// Таблица
    /// </summary>
    public class DPrintItemTable : DPrintItem
    {
        public DPrintBorderType CellBorder = DPrintBorderType.None;

        public Margins CellMargins = new Margins(0, 0, 0, 0);

        public Font CellFont { get; set; }

        private List<DPrintItemTableRow> _Rows = new List<DPrintItemTableRow>();
        public List<DPrintItemTableRow> Rows
        {
            get
            { return _Rows; }
        }

        public DPrintItemTableRow AddRow(params string[] values)
        {
            DPrintItemTableRow row = new DPrintItemTableRow();
            foreach (string value in values)
            {
                row.AddCellText(value);
            }
            _Rows.Add(row);
            return row;
        }

        private List<DPrintItemTableColumn> _Columns = new List<DPrintItemTableColumn>();
        public List<DPrintItemTableColumn> Columns
        {
            get
            { return _Columns; }
        }

        public DPrintSizeType ColumnsWidthType = DPrintSizeType.Fixed;

        public DPrintItemTableColumn AddColumn(string name, float width, DPrintAlignment alignment = DPrintAlignment.None)
        {
            DPrintItemTableColumn column = new DPrintItemTableColumn();
            column.Name = name;
            column.Width = width;
            column.Alignment = alignment;

            _Columns.Add(column);
            return column;
        }
    }

    public class DPrintItemTableColumn
    {
        public string Name { get; set; }

        public float Width { get; set; }

        public DPrintAlignment Alignment { get; set; }
    }

    public class DPrintItemTableRow
    {
        private List<DPrintItemTableCell> _Cells = new List<DPrintItemTableCell>();
        public List<DPrintItemTableCell> Cells
        {
            get
            { return _Cells; }
        }

        public void AddCell(DPrintItem item)
        {
            DPrintItemTableCell cell = new DPrintItemTableCell();
            cell.Item = item;
            _Cells.Add(cell);
        }

        public void AddCellText(string text, Font printFont = null)
        {
            DPrintItemText item = new DPrintItemText();
            item.Text = text;
            item.PrintFont = printFont;
         
            DPrintItemTableCell cell = new DPrintItemTableCell();
            cell.Item = item;
            _Cells.Add(cell);
        }
    }

    public class DPrintItemTableCell
    {
        public DPrintItem Item { get; set; }
    }

    #endregion DPrintItemTable

    #region DPrintItemDataTable

    public class DPrintItemDataRow : DPrintItem
    {
        private DPrintItemDataTable _DTable = null;
        public DPrintItemDataTable DTable
        {
            get
            { return _DTable; }
            set
            { _DTable = value; }
        }

        private List<DPrintItem> _Cells = new List<DPrintItem>();
        public List<DPrintItem> Cells
        {
            get
            { return _Cells; }
        }

        /// <summary>
        /// Брой редове на текста
        /// </summary>
        public int CountTextLine = 1;

        public DPrintBorderType CellBorder = DPrintBorderType.None;
        
        public void AddCell(DPrintItem cell)
        {
            _Cells.Add(cell);
        }

        public void AddCellText(string text, Font printFont = null)
        {
            DPrintItemText item = new DPrintItemText();
            item.Text = text;
            item.PrintFont = printFont;

            _Cells.Add(item);
        }
    }

    public class DPrintItemDataColumn
    {
        public string Name { get; set; }

        public float Width { get; set; }

        public DPrintAlignment Alignment { get; set; }
    }

    public class DPrintItemDataTable
    {
        private DPrintSizeType _ColumnsWidthType = DPrintSizeType.Fixed;
        public DPrintSizeType ColumnsWidthType
        {
            get
            { return _ColumnsWidthType; }
            set
            { _ColumnsWidthType = value; }
        }

        private List<DPrintItemDataColumn> _Columns = new List<DPrintItemDataColumn>();
        public List<DPrintItemDataColumn> Columns
        {
            get
            { return _Columns; }
        }

        public void AddColumn(string name, float width, DPrintAlignment alignment)
        {
            DPrintItemDataColumn column = new DPrintItemDataColumn();
            column.Name = name;
            column.Width = width;
            column.Alignment = alignment;

            _Columns.Add(column);
        }

        public PointF[] GetColumns(float startTableX, float endTableX)
        {
            PointF[] cols = null;
            // има дефинирани колони
            if (_Columns.Count > 0)
            {
                // формира колоните
                cols = new PointF[_Columns.Count];
                float cellX = startTableX;
                // Ако колоните са с фиксиран размер
                if (_ColumnsWidthType == DPrintSizeType.Fixed)
                {
                    for (int i = 0; i < _Columns.Count; i++)
                    {
                        DPrintItemDataColumn column = _Columns[i];
                        cols[i].X = cellX;
                        cellX += column.Width;
                        cols[i].Y = cellX;
                    }
                }
                // Ако колоните са с процентен размер
                else
                {
                    // ширина на таблицата
                    float tableWidth = (endTableX - startTableX);
                    for (int i = 0; i < _Columns.Count; i++)
                    {
                        DPrintItemDataColumn column = _Columns[i];
                        cols[i].X = cellX;
                        cellX += (tableWidth * column.Width / 100);
                        cols[i].Y = cellX;
                    }
                }
            }
            return cols;
        }

        public Font CellFont { get; set; }
    }

    #endregion DPrintItemDataTable
}
