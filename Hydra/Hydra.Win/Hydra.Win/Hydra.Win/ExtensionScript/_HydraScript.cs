using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hydra.Win.Layouts;

namespace Hydra.Win.ExtensionScript
{
    /*
    /// <summary>
    /// Скрип за Hydra прилоцението
    /// </summary>
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class HydraScript
    {
        private Form _Owner = null;

        public event ApplicationEventHandler OpeningApplication;

        public HydraScript(Form owner)
        {
            _Owner = owner;
        }

        public void OpenApplication(string gId = "", string name = "", string appUrl = "", string author = "")
        {
            АpplicationModel model = new АpplicationModel()
            {
                GId = new Guid(gId),
                Name = name,
                AppUrl = appUrl,
                Author = author,
                Description = ""
            };
            OnOpeningApplication(model);
        }

        private void OnOpeningApplication(АpplicationModel e)
        {
            if (OpeningApplication != null)
            { OpeningApplication(this, e); }
        }

        public void Layout(string message)
        {
            String hhh = message;
        }

        /*
        private ConsoleScript _Console = null;
        public ConsoleScript Console
        {
            get
            {
                if (_Console == null)
                { _Console = new ConsoleScript(_Owner); }
                return _Console;
            }
        }
        *//*
    }
    */
}