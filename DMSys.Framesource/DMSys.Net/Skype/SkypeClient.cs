using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DMSys.Net.Skype
{
    public partial class SkypeClient : Component
    {
        #region Events

        public event SkypeAttachHandler SkypeAttach;

        public event SkypeResponseHandler SkypeResponse;

        public event SkypeResponseListHandler SkypeResponseList;

        #endregion Events

        #region Properties

        private SkypeCommand _SCommand = null;

        #endregion Properties

        public SkypeClient()
        {
            InitializeComponent();
        }

        public SkypeClient(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Events: Method

        private void SkypeClient_SkypeAttach(object sender, SkypeAttachEventArgs e)
        {
            if (SkypeAttach != null)
            { SkypeAttach(this, e); }
        }

        private void SkypeClient_SkypeResponse(object sender, SkypeResponseEventArgs e)
        {
            if (SkypeResponse != null)
            { SkypeResponse(this, e); }

            switch (e.RValue)
            {
                case "USERS":
                    if (SkypeResponseList != null)
                    { SkypeResponseList(this, new SkypeResponseListEventArgs(e)); }
                    break;
                default:
                    break;
            }
        }

        #endregion Events: Method

        public bool Conect()
        {
            return _SCommand.Connect();
        }

        public void Disconnect()
        {
            _SCommand.Disconnect();
        }

        public bool Command(string CommandName)
        {
            return _SCommand.Command(CommandName);
        }

        /// <summary>
        /// Syntax:     SEARCH FRIENDS
        /// Response:   USERS [user[, user]*]
        ///     - returns a list of found usernames; an empty list if no match is found
        /// </summary>
        /// <returns></returns>
        public bool SearchFriends()
        {
            return Command("SEARCH FRIENDS");
        }
    }
}
