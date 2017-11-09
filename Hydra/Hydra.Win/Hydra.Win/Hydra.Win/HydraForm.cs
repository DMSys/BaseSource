using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hydra.Win.ExtensionScript;
using Hydra.Win.Layouts;

namespace Hydra.Win
{
    public partial class FHydraForm : Form
    {
        /// <summary>
        /// Път до длавната дир. на Hydra
        /// </summary>
        private string _HydraRootPath = "";

        // private const string _BaseUrl = "http://tester.xfirma.com/h/Play";
        // private const string _BaseUrl = "http://tester.xfirma.com/m/Content/_test/index.html";
        // private const string _BaseUrl = "http://tester.xfirma.com/h/Home/About";
        // private const string _BaseUrl = "http://localhost:55392/Play";
        // private const string _BaseUrl = "http://localhost:55392/";
        private const string _BaseUrl = "http://hydra.orionhub.org:8000/index.html";

        private Hydra.Win.QuickMenu.UCQuickMenu _QuickMenu = null;

        public FHydraForm()
        {
            InitializeComponent();
            _HydraRootPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            _QuickMenu = new Hydra.Win.QuickMenu.UCQuickMenu();
            _QuickMenu.ItemClick += QuickMenu_ItemClick;
        }

        private void FHydraForm_Load(object sender, EventArgs e)
        {
            HideToolBar();
            // Зарежда Default приложението, ако има зададен път
            string defaultAppBasePath = AppConfig.DefaultAppBasePath;
            if (defaultAppBasePath != "")
            {
                string defaultAppInitPath = Helper.PathCombine(defaultAppBasePath, AppConfig.DefaultAppStartPage);
                var appScript = new Hydra.Win.ExtensionScript.ObjectScript();
                UCBrowser browser = CreateBrowser(appScript
                    , defaultAppInitPath
                    , defaultAppBasePath
                    , AppConfig.DefaultAppCompany
                    , AppConfig.DefaultAppName
                    , AppConfig.DefaultAppIsOnline);

                pnlBrowser.Controls.Clear();
                pnlBrowser.Controls.Add(browser);
            }
            // Зарежда магазина 
            else
            {
                var appScript = new Hydra.Win.ExtensionScript.ObjectScript();
                appScript.WebApp.Opening += OpeningApplication;

                UCBrowser browser = CreateBrowser(appScript, _BaseUrl, "", "", "", true);
                pnlBrowser.Controls.Clear();
                pnlBrowser.Controls.Add(browser);

                _QuickMenu.Add(new QuickMenuItemModel()
                {
                    App = new АpplicationModel()
                    {
                        Name = "Store",
                        AppUrl = _BaseUrl
                    },
                    WBrowser = browser
                });
            }
        }

        /// <summary>
        /// Създава и зарежда браузъра
        /// </summary>
        private UCBrowser CreateBrowser(ObjectScript objScript, string initPath, string basePath
            , string appCompany, string appName, bool appIsOnline)
        {
            Uri initUrl = new Uri(initPath);

            UCBrowser browser = new UCBrowser();
            browser.ObjectForScripting = objScript;
            browser.Dock = DockStyle.Fill;
            browser.AppBasePath = basePath;
            browser.HydraRootPath = _HydraRootPath;
            // browser.JScriptsPath = AppConfig.JScriptsPath;
            browser.JScriptsPath = System.IO.Path.Combine(_HydraRootPath, "JScripts");

            browser.Navigate(initUrl);

            return browser;
        }

        private void tsbMenu_Click(object sender, EventArgs e)
        {
            if (this.IsShowToolBar)
            { HideToolBar(); }
            else
            { ShowToolBar(_QuickMenu); }
        }

        private void OpeningApplication(object sender, АpplicationModel e)
        {
            var appScript = new Hydra.Win.ExtensionScript.ObjectScript();
            UCBrowser browser = CreateBrowser(appScript, e.AppUrl, "", "", "", true);

            _QuickMenu.Add(new QuickMenuItemModel()
            {
                App = e,
                WBrowser = browser
            });

            pnlBrowser.Controls.Clear();
            pnlBrowser.Controls.Add(browser);
        }

        private void QuickMenu_ItemClick(object sender, QuickMenuItemModel e)
        {
            pnlBrowser.Controls.Clear();
            pnlBrowser.Controls.Add(e.WBrowser);
        }

        #region ToolBar

        private bool IsShowToolBar
        {
            get
            { return pnlToolBar.Visible; }
        }

        private void ShowToolBar(UserControl toolPanel)
        {
            splitterToolBar.Visible = true;
            pnlToolBar.Visible = true;

            pnlToolBar.Controls.Clear();
            toolPanel.Dock = DockStyle.Fill;
            pnlToolBar.Controls.Add(toolPanel);
        }

        private void HideToolBar()
        {
            pnlToolBar.Visible = false;
            splitterToolBar.Visible = false;
        }

        #endregion ToolBar

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            string optionsPageUrl = Helper.PathCombine(AppConfig.AppsFiles, "~\\Systems\\Options\\index.html");

            var appScript = new Hydra.Win.ExtensionScript.ObjectScript();
            UCBrowser browser = CreateBrowser(appScript, optionsPageUrl, "", "", "", true);

            pnlBrowser.Controls.Clear();
            pnlBrowser.Controls.Add(browser);
        }
    }
}
