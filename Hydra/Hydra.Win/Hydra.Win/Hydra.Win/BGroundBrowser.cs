using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hydra.Win
{
    public class BGroundBrowser: IDisposable
    {
        private WebBrowser _WebBrowser = new WebBrowser();
        
        public object ObjectForScripting
        {
            set
            { _WebBrowser.ObjectForScripting = value; }
        }

        public HtmlDocument Document
        {
            get
            { return _WebBrowser.Document; }
        }

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

        private string _CorrelationId = "";
        public string CorrelationId
        { 
            get
            { return _CorrelationId; }
        }

        public event WebBrowserDocumentCompletedEventHandler DocumentCompleted;

        public BGroundBrowser()
        {
            _WebBrowser.AllowWebBrowserDrop = false;
            _WebBrowser.IsWebBrowserContextMenuEnabled = false;
            _WebBrowser.WebBrowserShortcutsEnabled = false;
            // Спира ScriptErrors
            _WebBrowser.ScriptErrorsSuppressed = true;

            _WebBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser_Navigated);
            _WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);

            _WebBrowser.Url = new Uri("about:blank");
        }

        public void Dispose()
        {
            _WebBrowser.Dispose();
        }
       
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            WebBrowser browser = (WebBrowser)sender;
            if (browser.Document != null)
            {
                // Subscribe to the Error event
                // _WebBrowser.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
                HtmlElementCollection pageHeads = browser.Document.GetElementsByTagName("head");
                if (pageHeads.Count > 0)
                {
                    HtmlElement pageHead = pageHeads[0];

                    // dHydra.Browser.js
                    string jsHBrowser = System.IO.Path.Combine(_HydraRootPath, "JScripts\\dHydra.Browser.js");
                    HtmlElement elHBrowser = browser.Document.CreateElement("script");
                    elHBrowser.SetAttribute("type", "text/javascript");
                    elHBrowser.SetAttribute("src", jsHBrowser);
                    pageHead.AppendChild(elHBrowser);
                    // json2.js
                    string jsJson = System.IO.Path.Combine(_HydraRootPath, "JScripts\\json2.js");
                    HtmlElement elJson = browser.Document.CreateElement("script");
                    elJson.SetAttribute("type", "text/javascript");
                    elJson.SetAttribute("src", jsJson);
                    pageHead.AppendChild(elJson);
                    // dHydra.Framework
                    string jsFramework = System.IO.Path.Combine(_HydraRootPath, "JScripts\\dHydra.Framework.js");
                    HtmlElement elFramework = browser.Document.CreateElement("script");
                    elFramework.SetAttribute("type", "text/javascript");
                    elFramework.SetAttribute("src", jsFramework);
                    pageHead.AppendChild(elFramework);
                }
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (DocumentCompleted != null)
            {
                DocumentCompleted(sender, e);
            }
        }

        public void Navigate(string pagePath, string correlationId = "")
        {
            _CorrelationId = correlationId;
            _WebBrowser.Navigate(pagePath);
        }
    }
}
