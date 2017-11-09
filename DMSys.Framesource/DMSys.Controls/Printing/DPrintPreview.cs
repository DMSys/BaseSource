using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace DMSys.Controls.Printing
{
    public partial class DPrintPreview : UserControl
    {
        #region Properties

        private DPrintDocument _Document = new DPrintDocument();
        public DPrintDocument Document
        {
            get
            { return _Document; }
        }

        public Margins PageMargins
        {
            get
            { return pDocument.DefaultPageSettings.Margins; }
        }

        public string DocumentName
        {
            get
            { return pDocument.DocumentName; }
            set
            { pDocument.DocumentName = value; }
        }

        public bool Landscape
        {
            get
            { return pDocument.DefaultPageSettings.Landscape; }
            set
            { pDocument.DefaultPageSettings.Landscape = value; }
        }

        /// <summary>
        /// Индекс на елемента за отпечатване
        /// </summary>
        private int _PrintItemIndex = 0;
        /// <summary>
        /// Брой принтирани странници
        /// </summary>
        private int _PrintCountPage = 1;
        /// <summary>
        /// В режим на преглед
        /// </summary>
        private bool _IsPrintPreviewMode = true;

        private float _PrintPageStartX = 0;
        private float _PrintPageEndX = 0;
        private float _PrintPageStartY = 0;
        private float _PrintPageEndY = 0;

        #endregion Properties

        public DPrintPreview()
        {
            InitializeComponent();

            tscb_Zoom.SelectedIndex = 0;
        }

        public void ShowDocument()
        {
            if ((PrinterSettings.InstalledPrinters == null)
                 || (PrinterSettings.InstalledPrinters.Count < 1))
            {
                throw new Exception("No printers are installed.");
            }
            StartNewPrint(true);
            // Размери на страницата за печат
            float startX = pDocument.DefaultPageSettings.Margins.Left;
            float endX = pDocument.DefaultPageSettings.PaperSize.Width
                            - pDocument.DefaultPageSettings.Margins.Right;
            float startY = pDocument.DefaultPageSettings.Margins.Top;
            float endY = pDocument.DefaultPageSettings.PaperSize.Height
                            - pDocument.DefaultPageSettings.Margins.Bottom;

            if (pDocument.DefaultPageSettings.Landscape)
            {
                _PrintPageStartX = startY;
                _PrintPageEndX = endY;
                _PrintPageStartY = startX;
                _PrintPageEndY = endX;
            }
            else
            {
                _PrintPageStartX = startX;
                _PrintPageEndX = endX;
                _PrintPageStartY = startY;
                _PrintPageEndY = endY;
            }
            pPreviewControl.Document = pDocument;
        }

        private void pDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Позицията на елемента за отпечатване
            float _PrintItemY = _PrintPageStartY;

            // Печата елементите
            for (; _PrintItemIndex < _Document.Items.Count; _PrintItemIndex++)
            {
                DPrintItem item = _Document.Items[_PrintItemIndex];
                _PrintItemY = PrintItem(e, _PrintItemY, _PrintPageStartX, _PrintPageEndX, item);
                // Ако е достигнат края, се отваря нова стр.
                if (_PrintItemY > _PrintPageEndY)
                {
                    // Брой отпечатани страници
                    _PrintCountPage += 1;
                    // Елемента за отпечатване
                    _PrintItemIndex += 1;

                    if (_IsPrintPreviewMode)
                    {
                        nud_Page.Maximum = _PrintCountPage;
                    }
                    e.HasMorePages = true;
                    return;
                }
            }
        }

        #region PrintItem

        /// <summary>
        /// Принтиране на елемент
        /// </summary>
        private float PrintItem(PrintPageEventArgs e, float startY, float startX, float endX
            , DPrintItem item, Font parentFont = null, DPrintAlignment alignment = DPrintAlignment.None)
        {
            Type itemType = item.GetType();
            // Текст
            if (itemType == typeof(DPrintItemText))
            {
                DPrintItemText itemText = (DPrintItemText)item;
                if (itemText.PrintFont == null)
                { itemText.PrintFont = parentFont; }
                if (itemText.Alignment == DPrintAlignment.None)
                { itemText.Alignment = alignment; }
                return PrintItemText(e, startY, startX, endX, itemText);
            }
            // Таблица
            else if (itemType == typeof(DPrintItemTable))
            {
                return PrintItemTable(e, startY, startX, endX, (DPrintItemTable)item);
            }
            // Празно място
            else if (itemType == typeof(DPrintItemBlank))
            {
                return PrintItemBlank(e, startY, startX, endX, (DPrintItemBlank)item);
            }
            // от средата на стр.
            else if (itemType == typeof(DPrintFromMiddlePage))
            {
                return (pDocument.DefaultPageSettings.PaperSize.Height / 2);
            }
            // DataTable
            else if (itemType == typeof(DPrintItemDataRow))
            {
                return PrintItemDataRow(e, startY, startX, endX, (DPrintItemDataRow)item);
            }
            else
            {
                return startY;
            }
        }

        /// <summary>
        /// Принтиране на текст
        /// </summary>
        private float PrintItemText(PrintPageEventArgs e, float startY, float startX, float endX, DPrintItemText item)
        {
            // Font на текста
            Font printFont = item.PrintFont;
            if (printFont == null)
            { printFont = this.Font; }
            // Подравняване на текста
            StringFormat sFormat = new StringFormat();
            sFormat.Alignment = CastToStringAlignment(item.Alignment);
            // Начало на текста
            float startTextX = 0;
            switch (item.Alignment)
            {
                case DPrintAlignment.Far:
                    startTextX = endX;
                    break;
                case DPrintAlignment.Center:
                    startTextX = startX + ((endX - startX) / 2);
                    break;
                case DPrintAlignment.Near:
                default:
                    startTextX = startX;
                    break;
            }

            int lineHeight = printFont.Height + 1;
            if (item.CountTextLine > 1)
            { lineHeight *= item.CountTextLine; }
            RectangleF textRect = new RectangleF(startX, startY, endX - startX, lineHeight);

            if (!item.BackgroundColor.IsEmpty)
            {
                SolidBrush backgroundBrush = new SolidBrush(item.BackgroundColor);
                e.Graphics.FillRectangle(backgroundBrush, textRect);
            }
            // Текста
            // e.Graphics.DrawString(item.Text, printFont, Brushes.Black, startTextX, startY, sFormat);
            e.Graphics.DrawString(item.Text, printFont, Brushes.Black, textRect, sFormat);

            return startY + lineHeight;
        }

        /// <summary>
        /// Принтиране на таблица
        /// </summary>
        private float PrintItemTable(PrintPageEventArgs e, float startY, float startX, float endX, DPrintItemTable item)
        {
            // Margins
            float startTableY = startY + item.Margins.Top;
            float startTableX = startX + item.Margins.Left;
            float endTableX = endX - item.Margins.Right;
            // край на таблицата по Y
            float endY = startTableY;
            // Редовете на таблицата
            if (item.Rows.Count > 0)
            {
                PointF[] cols = null;
                // има дефинирани колони
                if (item.Columns.Count > 0)
                {
                    // формира колоните
                    cols = new PointF[item.Columns.Count];
                    float cellX = startTableX;
                    // Ако колоните са с фиксиран размер
                    if (item.ColumnsWidthType == DPrintSizeType.Fixed)
                    {
                        for (int i = 0; i < item.Columns.Count; i++)
                        {
                            DPrintItemTableColumn column = item.Columns[i];
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
                        for (int i = 0; i < item.Columns.Count; i++)
                        {
                            DPrintItemTableColumn column = item.Columns[i];
                            cols[i].X = cellX;
                            cellX += (tableWidth * column.Width / 100);
                            cols[i].Y = cellX;
                        }
                    }
                }
                // Няма дефинирани колони.
                // Колоните се формират спрямо клетките в първия ред
                else
                {
                    int cellCount = item.Rows[0].Cells.Count;
                    // ширина на клетката
                    float celWidth = (endTableX - startTableX) / cellCount;
                    // формира колоните
                    cols = new PointF[cellCount];
                    float cellX = startTableX;
                    for (int i = 0; i < cellCount; i++)
                    {
                        cols[i].X = cellX;
                        cellX += celWidth;
                        cols[i].Y = cellX;
                    }
                }
                // Принтира редовете
                foreach (DPrintItemTableRow row in item.Rows)
                {
                    endY = PrintItemTableRow(e, endY, cols, row, item);
                }
            }
            // Рамка на таблицата
            if (item.Border == DPrintBorderType.Solid)
            {
                PrintItemBorder(e.Graphics, startTableX, startTableY, endTableX, endY);
            }
            return endY + item.Margins.Bottom;
        }

        /// <summary>
        /// Принтиране на ред от таблица
        /// </summary>
        private float PrintItemTableRow(PrintPageEventArgs e, float startY, PointF[] cols
            , DPrintItemTableRow item, DPrintItemTable table)
        {
            float maxCellY = startY;
            // Принтира данните на клетката
            for (int colIndex = 0; colIndex < cols.Length; colIndex++)
            {
                // Позиция на колоната
                PointF col = cols[colIndex];
                // Принтира елемента
                if (colIndex < item.Cells.Count)
                {
                    DPrintItemTableCell cell = item.Cells[colIndex];
                    DPrintAlignment columnAlignment = DPrintAlignment.None;
                    if (table.Columns.Count > colIndex)
                    {
                        DPrintItemTableColumn column = table.Columns[colIndex];
                        columnAlignment = column.Alignment;
                    }
                    float cellY = PrintItem(e, startY, col.X, col.Y, cell.Item
                        , table.CellFont, columnAlignment);
                    // Максималната височина на клетката
                    if (cellY > maxCellY)
                    { maxCellY = cellY; }
                }
            }
            // Слага рамка на клетките
            if (table.CellBorder == DPrintBorderType.Solid)
            {
                for (int colIndex = 0; colIndex < cols.Length; colIndex++)
                {
                    // Позиция на колоната
                    PointF col = cols[colIndex];
                    PrintItemBorder(e.Graphics, col.X, startY, col.Y, maxCellY);
                }
            }
            return maxCellY;
        }

        /// <summary>
        /// Принтиране на празно място
        /// </summary>
        private float PrintItemBlank(PrintPageEventArgs e, float startY, float startX, float endX, DPrintItemBlank item)
        {
            return startY + item.Height;
        }

        /// <summary>
        /// Принтира рамка
        /// </summary>
        private void PrintItemBorder(Graphics g, float startX, float startY, float endX, float endY)
        {
            Pen pn = new Pen(Color.Black);
            // Горе
            g.DrawLine(pn, startX, startY, endX, startY);
            // Долу
            g.DrawLine(pn, startX, endY, endX, endY);
            // Ляво
            g.DrawLine(pn, startX, startY, startX, endY);
            // Дясно
            g.DrawLine(pn, endX, startY, endX, endY);
        }

        /// <summary>
        /// Принтир ред от DataTable
        /// </summary>
        private float PrintItemDataRow(PrintPageEventArgs e, float startY, float startX, float endX, DPrintItemDataRow item)
        {
            // Margins
            float startTableY = startY + item.Margins.Top;
            float startTableX = startX + item.Margins.Left;
            float endTableX = endX - item.Margins.Right;
            // край на таблицата по Y
            float endY = startTableY;
            PointF[] cols = item.DTable.GetColumns(startTableX, endTableX);

            for (int colIndex = 0; colIndex < cols.Length; colIndex++)
            {
                // Позиция на колоната
                PointF col = cols[colIndex];
                // Принтира елемента
                if (colIndex < item.Cells.Count)
                {
                    DPrintItem cell = item.Cells[colIndex];
                    DPrintAlignment columnAlignment = DPrintAlignment.None;
                    if (item.DTable.Columns.Count > colIndex)
                    {
                        DPrintItemDataColumn column = item.DTable.Columns[colIndex];
                        columnAlignment = column.Alignment;
                    }

                    if (cell.BackgroundColor.IsEmpty)
                    { cell.BackgroundColor = item.BackgroundColor; }
                    if (item.CountTextLine > 1)
                    {
                        Type itemType = cell.GetType();
                        // Текст
                        if (itemType == typeof(DPrintItemText))
                        {
                            DPrintItemText cellText = (DPrintItemText)cell;
                            cellText.CountTextLine = item.CountTextLine;
                        }
                    }
                    float cellY = PrintItem(e, startY, col.X, col.Y, cell
                        , item.DTable.CellFont, columnAlignment);

                    // Максималната височина на клетката
                    if (cellY > endY)
                    { endY = cellY; }
                    // Слага рамка на клетката
                    if (item.CellBorder == DPrintBorderType.Solid)
                    {
                        PrintItemBorder(e.Graphics, col.X, startY, col.Y, endY);
                    }
                }
            }
            // Слага рамка на реда
            if (item.Border == DPrintBorderType.Solid)
            {
                PrintItemBorder(e.Graphics, startX, startY, endX, endY);
            }
            return endY;
        }

        #endregion PrintItem

        #region PrintButtons

        private void tsb_QuickPrint_Click(object sender, EventArgs e)
        {
            try
            {
                StartNewPrint(false);
                pDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsb_Print_Click(object sender, EventArgs e)
        {
            try
            {
                using (PrintDialog pDialog = new PrintDialog())
                {
                    pDialog.Document = pDocument;
                    if (pDialog.ShowDialog() == DialogResult.OK)
                    {
                        StartNewPrint(false);
                        pDocument.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsb_PageSetup_Click(object sender, EventArgs e)
        {
            try
            {
                using (PageSetupDialog psDialog = new PageSetupDialog())
                {
                    psDialog.Document = pDocument;
                    //psDialog.PageSettings = pDocument.DefaultPageSettings;
                    //psDialog.PrinterSettings = pDocument.PrinterSettings;

                    if (psDialog.ShowDialog() == DialogResult.OK)
                    {
                        //pDocument.DefaultPageSettings = psDialog.PageSettings;
                        //pDocument.PrinterSettings = psDialog.PrinterSettings;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tscb_Zoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Auto Zoom
                if (tscb_Zoom.SelectedIndex == 0)
                {
                    pPreviewControl.AutoZoom = true;
                }
                else
                {
                    string zoomText = tscb_Zoom.Text.Trim().TrimEnd('%');
                    double zoomValue = 100;
                    if (Double.TryParse(zoomText, out zoomValue))
                    {
                        pPreviewControl.AutoZoom = false;
                        pPreviewControl.Zoom = (zoomValue / 100);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion PrintButtons

        private StringAlignment CastToStringAlignment(DPrintAlignment value)
        {
            switch (value)
            {
                case DPrintAlignment.Far:
                    return StringAlignment.Far;
                case DPrintAlignment.Center:
                    return StringAlignment.Center;
                case DPrintAlignment.Near:
                default:
                    return StringAlignment.Near;
            }
        }

        private void nud_Page_ValueChanged(object sender, EventArgs e)
        {
            pPreviewControl.StartPage = ((int)nud_Page.Value) - 1;
        }

        /// <summary>
        /// Стартира нов печат
        /// </summary>
        private void StartNewPrint(bool isPrintPreviewMode)
        {
            _PrintItemIndex = 0;
            _PrintCountPage = 1;
            _IsPrintPreviewMode = isPrintPreviewMode;
            if (isPrintPreviewMode)
            {
                nud_Page.Value = 1;
                nud_Page.Maximum = 1;
            }
        }
    }
}
