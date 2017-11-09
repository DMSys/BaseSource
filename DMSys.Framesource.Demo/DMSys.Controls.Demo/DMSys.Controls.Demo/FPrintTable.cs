using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMSys.Controls.Printing;

namespace DMSys.Controls.Demo
{
    public partial class FPrintTable : Form
    {
        public FPrintTable()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            docPreview.PageMargins.Left = 50;
            docPreview.PageMargins.Right = 50;
            docPreview.PageMargins.Top = 50;
            docPreview.PageMargins.Bottom = 60;
            docPreview.DocumentName = "Print Table";
            // docPreview.Landscape = true;

            /*
            DPrintItemTable table = new DPrintItemTable();
            table.CellBorder = DPrintBorderType.Solid;
            table.ColumnsWidthType = DPrintSizeType.Percent;
            //tableFooter.CellFont = fontBodyB;
            table.AddColumn("Column 1", 50, DPrintAlignment.Far);

            for (int i = 1; i < 200; i++)
            {
                table.AddRow("row "+i.ToString("0000"));
            }
            docPreview.Document.Items.Add(table);
            */
            /*
            for (int i = 1; i < 200; i++)
            {
                docPreview.Document.AddItemText("row "+i.ToString("0000"));
            }*/

            DPrintItemDataTable dTable = new DPrintItemDataTable();
            dTable.ColumnsWidthType = DPrintSizeType.Percent;
            dTable.AddColumn("test 1", 60, DPrintAlignment.Near);
            dTable.AddColumn("test 2", 40, DPrintAlignment.Near);

            for (int i = 1; i < 200; i++)
            {
                DPrintItemDataRow row = new DPrintItemDataRow();
                row.DTable = dTable;
                row.CountTextLine = 2;
                row.CellBorder = DPrintBorderType.Solid;
                row.BackgroundColor = ((i % 2) == 1) ? Color.Azure : Color.Yellow;
                row.Border = DPrintBorderType.Solid;
                row.AddCellText("row " + i.ToString("0000"));

                DPrintItemText cell2 = new DPrintItemText();
                cell2.Text = "test 123456789 " + i.ToString("0000");
                cell2.CountTextLine = 2;
                row.Cells.Add(cell2);

                docPreview.Document.Items.Add(row);
            }

            docPreview.ShowDocument();
            ShowDialog();
        }
    }
}
