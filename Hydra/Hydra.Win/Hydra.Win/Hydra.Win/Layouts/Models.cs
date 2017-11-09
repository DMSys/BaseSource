using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hydra.Win.Layouts
{
    public class АpplicationModel
    {
        public Guid GId { get; set; }

        public string Name { get; set; }

        public string AppUrl { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
    }

    public class QuickMenuItemModel
    {
        public АpplicationModel App { get; set; }

        public UCBrowser WBrowser { get; set; }
    }
}
