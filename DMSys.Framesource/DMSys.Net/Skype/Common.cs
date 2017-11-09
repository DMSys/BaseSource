using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Net.Skype
{
    internal class Constants
    {
        public const string SkypeControlAPIDiscover = "SkypeControlAPIDiscover";
        public const string SkypeControlAPIAttach = "SkypeControlAPIAttach";
    }

    #region SkypeAttach

    public class SkypeAttachEventArgs : EventArgs
    {
        public SkypeAttachStatus AttachStatus;

        public SkypeAttachEventArgs(SkypeAttachStatus theAttachStatus)
        {
            AttachStatus = theAttachStatus;
        }
    }

    public delegate void SkypeAttachHandler(object sender, SkypeAttachEventArgs e);

    public enum SkypeAttachStatus : uint
    {
        Success = 0,
        PendingAuthorizaion = 1,
        Refused = 2,
        NotAvailable = 3,
        Available = 0x8001
    }

    #endregion SkypeAttach

    #region SkypeResponse

    public class SkypeResponseEventArgs : EventArgs
    {
        private string _Response = "";
        public string Response
        {
            get
            { return _Response; }
        }

        private int _Index = 0;

        public string RValue
        {
            get
            { return _Response.Substring(0, _Index); }
        }

        public string RMessage
        {
            get
            { return _Response.Substring(_Index + 1, _Response.Length - _Index - 1); }
        }

        public SkypeResponseEventArgs(string aResponse)
        {
            _Response = aResponse.Trim();

            _Index = _Response.IndexOf(' ');
        }
    }

    public delegate void SkypeResponseHandler(object sender, SkypeResponseEventArgs e);

    public class SkypeResponseListEventArgs : EventArgs
    {
        private SkypeResponseEventArgs _Response = null;
        public SkypeResponseEventArgs Response
        {
            get
            { return _Response; }
        }

        private List<string> _Items = null;
        public List<string> Items
        {
            get
            { return _Items; }
        }

        public SkypeResponseListEventArgs(SkypeResponseEventArgs aResponse)
        {
            _Response = aResponse;
            string[] sItems = _Response.RMessage.Split(',');
            foreach (string sItem in sItems)
            {
                string s = sItem.Trim();
                if (!s.Equals(""))
                { _Items.Add(s); }
            }
        }
    }

    public delegate void SkypeResponseListHandler(object sender, SkypeResponseListEventArgs e);

    #endregion SkypeResponse
}
