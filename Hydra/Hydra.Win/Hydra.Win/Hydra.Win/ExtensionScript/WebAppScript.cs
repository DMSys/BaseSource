using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hydra.Win.Layouts;

namespace Hydra.Win.ExtensionScript
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class WebAppScript
    {
        #region Layout

        private string _LayoutPath = "";
        public string LayoutPath
        {
            get
            { return _LayoutPath; }
        }
        
        /// <summary>
        /// Задава път до оформлението на страницата / Master page
        /// </summary>
        /// <param name="path"></param>
        public void Layout(string path)
        {
            _LayoutPath = path;
        }

        #endregion Layout

        #region Tabs

        public event EventHandler OnClosing;

        public void Close()
        {
            if (OnClosing != null)
            { OnClosing(this, new EventArgs()); }
        }

        public event ApplicationEventHandler Opening;

        public void Open(string gId = "", string name = "", string appUrl = "", string author = "")
        {
            АpplicationModel model = new АpplicationModel()
            {
                GId = new Guid(gId),
                Name = name,
                AppUrl = appUrl,
                Author = author,
                Description = ""
            };
            if (Opening != null)
            { Opening(this, model); }
        }

        public event ApplicationEventHandler OpeningTab;

        public void OpenTab(string gId = "", string name = "", string appUrl = "", string author = "")
        {
            АpplicationModel model = new АpplicationModel()
            {
                GId = new Guid(gId),
                Name = name,
                AppUrl = appUrl,
                Author = author,
                Description = ""
            };
            if (OpeningTab != null)
            { OpeningTab(this, model); }
        }
        
        #endregion Tabs
    }
}
