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
    public partial class UCQuickMenu : UserControl
    {
        public event QuickMenuItemEventHandler ItemClick;

        public UCQuickMenu()
        {
            InitializeComponent();
        }

        public void Add(QuickMenuItemModel model)
        {
            UCQuickMenuItem item = new UCQuickMenuItem(model);
            item.Dock = DockStyle.Top;
            item.ItemClick += QuickMenuItem_ItemClick;

            this.Controls.Add(item);
        }

        private void QuickMenuItem_ItemClick(object sender, QuickMenuItemModel e)
        {
            OnItemClick(e);
        }

        private void OnItemClick(QuickMenuItemModel e)
        {
            if (ItemClick != null)
            { ItemClick(this, e); }
        }
    }
}
