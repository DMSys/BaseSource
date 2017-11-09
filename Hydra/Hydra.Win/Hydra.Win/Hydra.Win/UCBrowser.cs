using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hydra.Win.ExtensionScript;

namespace Hydra.Win
{
    public partial class UCBrowser : UserControl
    {
        #region Properties

        private WebBrowser _WebBrowser = new WebBrowser();

        private BGroundBrowser _BGBrowser = new BGroundBrowser();

        private string _HydraRootPath = "";
        /// <summary>
        /// Път до длавната дир. на Hydra
        /// </summary>
        public string HydraRootPath
        {
            get
            { return _HydraRootPath; }
            set
            { _HydraRootPath = value; }
        }

        private string _AppBasePath = "";

        /// <summary>
        /// Път до приложението
        /// </summary>
        public string AppBasePath
        {
            get
            { return _AppBasePath; }
            set
            { _AppBasePath = value; }
        }

        private Uri _AppInitUrl = null;
        /// <summary>
        /// URL стартирало приложението
        /// </summary>
        public Uri AppInitUrl
        {
            get
            { return _AppInitUrl; }
        }

        private string _JScriptsPath = "";
        /// <summary>
        /// Път до JScripts
        /// </summary>
        public string JScriptsPath
        {
            get
            { return _JScriptsPath; }
            set
            { _JScriptsPath = value; }
        }

        private ExtensionScript.ObjectScript _ObjectScript = null;

        public ExtensionScript.ObjectScript ObjectForScripting
        {
            get
            { return _ObjectScript; }
            set
            {
                _ObjectScript = value;
                _ObjectScript.Console.ConsoleLog += new ConsoleEventHandler(Window_ConsoleLog);
                _ObjectScript.Console.ConsoleInfo += new ConsoleEventHandler(Window_ConsoleInfo);
                _ObjectScript.Console.ConsoleWarn += new ConsoleEventHandler(Window_ConsoleWarn);
                _ObjectScript.Console.ConsoleDebug += new ConsoleEventHandler(Window_ConsoleDebug);
                _ObjectScript.Console.ConsoleError += new ConsoleEventHandler(Window_ConsoleError);

                _WebBrowser.ObjectForScripting = _ObjectScript;
                _BGBrowser.ObjectForScripting = _ObjectScript;
            }
        }

        /// <summary>
        /// Url на заредената станица
        /// </summary>
        private Uri _CurrentPageUrl = null;

        #endregion Properties

        public UCBrowser()
        {
            InitializeComponent();

            _BGBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(bgBrowser_ExecuteCodeCompleted);
            
            // Създава WebBrowser
            _WebBrowser.AllowWebBrowserDrop = false;
            _WebBrowser.IsWebBrowserContextMenuEnabled = false;
            _WebBrowser.WebBrowserShortcutsEnabled = false;
            _WebBrowser.Dock = DockStyle.Fill;
            // Показва стандартното меню
            _WebBrowser.IsWebBrowserContextMenuEnabled = true;
            // Спира ScriptErrors
            _WebBrowser.ScriptErrorsSuppressed = true;
            _WebBrowser.Navigating += new WebBrowserNavigatingEventHandler(webBrowser_Navigating);
            _WebBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser_Navigated);
            _WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
            _WebBrowser.PreviewKeyDown += new PreviewKeyDownEventHandler(this.webBrowser_PreviewKeyDown);

            // Добавя WebBrowser
            splitContainer.Panel1.Controls.Clear();
            splitContainer.Panel1.Controls.Add(_WebBrowser);
            // Изчиства консолата
            dgvConsole.Rows.Clear();
        }

        public void Navigate(Uri url)
        {
            dgvConsole.Rows.Clear();

            _AppInitUrl = url;
            _WebBrowser.Navigate(url);
        }

        /// <summary>
        /// Панел за разработка.
        /// Отваря, ако е затворен и затваря, ако е отворен.
        /// </summary>
        public void DevPanel_ShowHide()
        {
            splitContainer.Panel2Collapsed = !splitContainer.Panel2Collapsed;
        }

        #region Web Browser

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // Изчиства консолата
            dgvConsole.Rows.Clear();
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // Запазва Url на заредената страница
            if ((e != null) && (e.Url != null))
            {
                _CurrentPageUrl = e.Url;
            }
            // Ако има зареден документ, добавя JS библиотеки
            if (_WebBrowser.Document != null)
            {
                // Subscribe to the Error event
                _WebBrowser.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
                HtmlElement pageHead = _WebBrowser.Document.GetElementsByTagName("head")[0];

                // json2
                string jsJson = System.IO.Path.Combine(_JScriptsPath, "json2.js");
                HtmlElement elJson = _WebBrowser.Document.CreateElement("script");
                elJson.SetAttribute("type", "text/javascript");
                elJson.SetAttribute("src", jsJson);
                pageHead.AppendChild(elJson);
                // dHydra.Browser
                string jsHBrowser = System.IO.Path.Combine(_JScriptsPath, "windowsBrowser.js");
                HtmlElement elHBrowser = _WebBrowser.Document.CreateElement("script");
                elHBrowser.SetAttribute("type", "text/javascript");
                elHBrowser.SetAttribute("src", jsHBrowser);
                pageHead.AppendChild(elHBrowser);
                // dHydra.Framework
                string jsFramework = System.IO.Path.Combine(_JScriptsPath, "dHydra.js");
                HtmlElement elFramework = _WebBrowser.Document.CreateElement("script");
                elFramework.SetAttribute("type", "text/javascript");
                elFramework.SetAttribute("src", jsFramework);
                pageHead.AppendChild(elFramework);
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (_WebBrowser.Document != null)
            {
                string viewStartPage = Layouts.Helper.PathCombine(_AppBasePath, "~/_ViewStart.html");
                _BGBrowser.HydraRootPath = _HydraRootPath;
                _BGBrowser.Navigate(viewStartPage, "view_start");
            }
        }

        private void bgBrowser_ExecuteCodeCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (_WebBrowser.Document != null)
            {
                switch (_BGBrowser.CorrelationId)
                {
                    case "view_start":
                        if (_ObjectScript != null)
                        {
                            string layoutPath = _ObjectScript.WebApp.LayoutPath;
                            if (!String.IsNullOrWhiteSpace(layoutPath))
                            {
                                layoutPath = Layouts.Helper.PathCombine(_AppBasePath, layoutPath);

                                _BGBrowser.Navigate(layoutPath, "master_page");
                            }
                        }
                        break;
                    case "master_page":
                        HtmlDocument pageMaster = _BGBrowser.Document;
                        // Ако има Master Page
                        if (pageMaster != null)
                        {
                            // Променя Head
                            _WebBrowser.Document.Encoding = pageMaster.Encoding;
                            _WebBrowser.Document.Title = pageMaster.Title;

                            HtmlElement pageHead = _WebBrowser.Document.GetElementsByTagName("head")[0];
                            HtmlElement pageMasterHead = pageMaster.GetElementsByTagName("head")[0];
                            // Прехвърля link
                            HtmlElementCollection pageMasterHeadLinks = pageMasterHead.GetElementsByTagName("link");
                            foreach (HtmlElement pageMasterHeadLink in pageMasterHeadLinks)
                            {
                               HtmlElement pageHeadLink = _WebBrowser.Document.CreateElement(pageMasterHeadLink.TagName);
                               pageHeadLink.SetAttribute("rel", pageMasterHeadLink.GetAttribute("rel"));
                               pageHeadLink.SetAttribute("type", pageMasterHeadLink.GetAttribute("type"));
                               pageHeadLink.SetAttribute("href", pageMasterHeadLink.GetAttribute("href"));
                                
                               pageHead.AppendChild(pageHeadLink);
                            }
                            // Променя Body
                            HtmlElement pageMasterBody = pageMaster.GetElementsByTagName("body")[0];

                            _WebBrowser.Document.Body.InnerHtml =
                                pageMasterBody.InnerHtml.Replace("@BodyContent", _WebBrowser.Document.Body.InnerHtml);
                        }
                        break;
                }
            }
        }

        private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                DevPanel_ShowHide();
            }
        }

        #endregion Web Browser

        #region Console

        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            string absolutePath = "";
            string sourcePath = "";
            try
            {
                if (e.Url != null)
                {
                    absolutePath = e.Url.AbsolutePath;
                    if (e.Url.Segments.Length > 0)
                    {
                        sourcePath = string.Format("{0}:{1}",
                            e.Url.Segments[e.Url.Segments.Length - 1], e.LineNumber);
                    }
                }
            }
            catch { }
            dgvConsole.Rows.Add(new object[] { "exception", e.Description, absolutePath, e.LineNumber, sourcePath });
            // Ignore the error and suppress the error dialog box. 
            e.Handled = true;
        }

        private void Window_ConsoleLog(object sender, ConsoleEventArgs e)
        {
            dgvConsole.Rows.Add(new object[] { "log", e.Message, "", "" });
        }

        private void Window_ConsoleInfo(object sender, ConsoleEventArgs e)
        {
            dgvConsole.Rows.Add(new object[] { "info", e.Message, "", "" });
        }

        private void Window_ConsoleWarn(object sender, ConsoleEventArgs e)
        {
            dgvConsole.Rows.Add(new object[] { "warn", e.Message, "", "" });
        }

        private void Window_ConsoleDebug(object sender, ConsoleEventArgs e)
        {
            dgvConsole.Rows.Add(new object[] { "debug", e.Message, "", "" });
        }

        private void Window_ConsoleError(object sender, ConsoleEventArgs e)
        {
            dgvConsole.Rows.Add(new object[] { "error", e.Message, "", "" });
        }

        private void dgvConsole_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                DevPanel_ShowHide();
            }
        }

        #endregion Console

        /// <summary>
        /// Променя ориентацията на допълнителния панел
        /// </summary>
        private void tsbDock_Click(object sender, EventArgs e)
        {
            if (splitContainer.Orientation == Orientation.Horizontal)
            {
                splitContainer.Orientation = Orientation.Vertical;
                splitContainer.SplitterDistance = (splitContainer.Width / 4) * 3;
                tsDeveloperMenu.Dock = DockStyle.Top;
                this.tsbDock.Image = global::Hydra.Win.Properties.Resources.dock_bottom_16_icon;
            }
            else
            {
                splitContainer.Orientation = Orientation.Horizontal;
                splitContainer.SplitterDistance = (splitContainer.Height / 4) * 3;
                tsDeveloperMenu.Dock = DockStyle.Left;
                this.tsbDock.Image = global::Hydra.Win.Properties.Resources.dock_right_16_icon;
            }
        }

        /// <summary>
        /// Презарежда последно заредената страница
        /// </summary>
        private void tsbReload_Click(object sender, EventArgs e)
        {
            if(_CurrentPageUrl != null)
            {
                _WebBrowser.Navigate(_CurrentPageUrl);
            }
        }
    }
}