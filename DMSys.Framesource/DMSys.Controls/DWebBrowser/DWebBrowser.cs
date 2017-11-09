using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace DMSys.Controls
{
    public class DWebBrowser : WebBrowser
    {
        private bool _AllowSecurityAlert = true;
        [Category("Behavior")]
        [Description("")]
        public bool AllowSecurityAlert
        {
            get
            { return _AllowSecurityAlert; }
            set
            { _AllowSecurityAlert = value; }
        }

        public DWebBrowser()
        {
            // Subscribe to Event(s) with the WindowsInterop Class
            WindowsInterop.SecurityAlertDialogWillBeShown +=
                new GenericDelegate<Boolean, Boolean>(this.WindowsInterop_SecurityAlertDialogWillBeShown);

            WindowsInterop.ConnectToDialogWillBeShown +=
                new GenericDelegate<String, String, Boolean>(this.WindowsInterop_ConnectToDialogWillBeShown);

            this.Navigating += 
                new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WB_Navigating);

            this.DocumentCompleted +=
                new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB_DocumentCompleted);
        }

        private Boolean WindowsInterop_SecurityAlertDialogWillBeShown(Boolean blnIsSSLDialog)
        {
            // Return true to ignore and not show the 
            // "Security Alert" dialog to the user
            return true;
        }

        private Boolean WindowsInterop_ConnectToDialogWillBeShown(ref String sUsername, ref String sPassword)
        {
            // (Fill in the blanks in order to be able 
            // to return the appropriate Username and Password)
            sUsername = "";
            sPassword = "";

            // Return true to auto populate credentials and not 
            // show the "Connect To ..." dialog to the user
            return true;
        }

        private void WB_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!_AllowSecurityAlert)
            {
                // Tell the WidowsInterop to Hook messages
                WindowsInterop.Hook();
            }
        }

        private void WB_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!_AllowSecurityAlert)
            {
                // Tell the WidowsInterop to Unhook
                WindowsInterop.Unhook();
            }
        }
    }
}
