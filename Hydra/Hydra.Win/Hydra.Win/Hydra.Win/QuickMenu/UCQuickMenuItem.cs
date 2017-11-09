using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hydra.Win.Layouts;

namespace Hydra.Win.QuickMenu
{
    public partial class UCQuickMenuItem : UserControl
    {
        private QuickMenuItemModel _ItemModel = null;

        public event QuickMenuItemEventHandler ItemClick;

        public UCQuickMenuItem()
        {
            InitializeComponent();
        }

        public UCQuickMenuItem(QuickMenuItemModel model)
        {
            InitializeComponent();
            _ItemModel = model;
            if (model != null)
            {
                lblAppName.Text = model.App.Name;
                lblAppAuthor.Text = model.App.Author;
            }
        }

        #region Events
        
        private void lblAppName_Click(object sender, EventArgs e)
        {
            OnItemClick(_ItemModel);
        }

        private void lblAppAuthor_Click(object sender, EventArgs e)
        {
            OnItemClick(_ItemModel);
        }

        private void lblAppName_MouseEnter(object sender, EventArgs e)
        {
            ItemMouseEnter();
        }

        private void lblAppAuthor_MouseEnter(object sender, EventArgs e)
        {
            ItemMouseEnter();
        }

        private void lblAppName_MouseLeave(object sender, EventArgs e)
        {
            ItemMouseLeave();
        }

        private void lblAppAuthor_MouseLeave(object sender, EventArgs e)
        {
            ItemMouseLeave();
        }

        #endregion Events

        private void OnItemClick(QuickMenuItemModel e)
        {
            if (ItemClick != null)
            { ItemClick(this, e); }
        }

        private void ItemMouseEnter()
        {
            Color backColor = Color.FromArgb(0, 122, 204);
            lblAppName.BackColor = backColor;
            lblAppName.ForeColor = Color.White;
            lblAppAuthor.BackColor = backColor;
            lblAppAuthor.ForeColor = Color.White;
        }

        private void ItemMouseLeave()
        {
            lblAppName.BackColor = Color.White;
            lblAppName.ForeColor = Color.Black;
            lblAppAuthor.BackColor = Color.White;
            lblAppAuthor.ForeColor = Color.RoyalBlue;
        }

    }
}