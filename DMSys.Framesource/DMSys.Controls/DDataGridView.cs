using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace DMSys.Controls
{
    public class DDataGridView: DataGridView
    {
        public DDataGridViewBookmark Bookmark
        {
            get
            {
                DDataGridViewBookmark bm = new DDataGridViewBookmark();
                if (this.CurrentCell != null)
                {
                    bm.CurrentRowIndex = this.CurrentCell.RowIndex;
                    bm.CurrentColumnIndex = this.CurrentCell.ColumnIndex;
                }
                if (this.FirstDisplayedCell != null)
                {
                    bm.FirstDisplayedRowIndex = this.FirstDisplayedCell.RowIndex;
                    bm.FirstDisplayedColumnIndex = this.FirstDisplayedCell.ColumnIndex;
                }
                if (this.SortedColumn != null)
                {
                    bm.SortedColumnName = this.SortedColumn.Name;
                    bm.SortedColumnOrder = this.SortOrder;
                }
                return bm;
            }
            set
            {
                if (value == null)
                { return; }
                // Sort
                if (value.SortedColumnName != null)
                {
                    DataGridViewColumn sortColumn = this.Columns[value.SortedColumnName];
                    if (sortColumn != null)
                    {
                        ListSortDirection direction = ConertToListSortDirection(value.SortedColumnOrder);
                        this.Sort(sortColumn, direction);
                    }
                }
                // CurrentCell
                DataGridViewCell cCell = GetCell(value.CurrentColumnIndex, value.CurrentRowIndex);
                if ( cCell != null)
                { this.CurrentCell = cCell; }
                // FirstDisplayedCell
                DataGridViewCell fdCell = GetCell(value.FirstDisplayedColumnIndex, value.FirstDisplayedRowIndex);
                if (fdCell != null)
                { this.FirstDisplayedCell = fdCell; }
            }
        }

        private DataGridViewCell GetCell(int columnIndex, int rowIndex)
        {
            int iCol = columnIndex;
            int iRow = rowIndex;
            if (iCol >= this.ColumnCount)
            { iCol = this.ColumnCount - 1; }
            if (iRow >= this.RowCount)
            { iRow = this.RowCount - 1; }

            if ((iCol < 0) || (iRow < 0))
            { return null; }
            else
            {
                DataGridViewCell cel = this[iCol, iRow];
                return ((cel.Visible)?cel:null);
            }
        }

        private ListSortDirection ConertToListSortDirection(SortOrder value)
        {
            switch (value)
            {
                case SortOrder.Ascending:
                    return ListSortDirection.Ascending;
                case SortOrder.Descending:
                    return ListSortDirection.Descending;
                default:
                    return ListSortDirection.Ascending;
            }
        }
    }

    public class DDataGridViewBookmark
    {
        public int CurrentRowIndex
        { get; set; }

        public int CurrentColumnIndex
        { get; set; }

        public int FirstDisplayedRowIndex
        { get; set; }

        public int FirstDisplayedColumnIndex
        { get; set; }

        public string SortedColumnName
        { get; set; }

        public SortOrder SortedColumnOrder
        { get; set; }
    }
}