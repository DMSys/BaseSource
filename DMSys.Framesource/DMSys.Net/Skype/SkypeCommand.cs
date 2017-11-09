using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMSys.NativeMethods;

namespace DMSys.Net.Skype
{
    internal partial class SkypeCommand : Form
    {
        public SkypeCommand()
        {
            InitializeComponent();

            UM_SkypeControlAPIDiscover = User32.RegisterWindowMessage(Constants.SkypeControlAPIDiscover);
            UM_SkypeControlAPIAttach = User32.RegisterWindowMessage(Constants.SkypeControlAPIAttach);

            CreateHandle();
        }

        public bool Connect()
        {
            IntPtr result;
            IntPtr aRetVal = User32.SendMessageTimeout(HWND.BROADCAST, UM_SkypeControlAPIDiscover, Handle, IntPtr.Zero, SendMessageTimeoutFlags.SMTO_NORMAL, 100, out result);

            return (aRetVal != IntPtr.Zero);
        }

        public void Disconnect()
        {
            Command("");
            mySkypeHandle = IntPtr.Zero;
        }

        public bool Command(string theCommand)
        {
            CopyDataStruct aCDS = new CopyDataStruct();

            aCDS.ID = "2";
            aCDS.Data = theCommand;
            aCDS.Length = aCDS.Data.Length + 1;

            IntPtr result;
            IntPtr aRetVal = User32.SendMessageTimeout(mySkypeHandle, WM.COPYDATA, Handle, ref aCDS, SendMessageTimeoutFlags.SMTO_NORMAL, 100, out result);

            return (aRetVal != IntPtr.Zero);
        }

        private UInt32 UM_SkypeControlAPIDiscover = 0;
        private UInt32 UM_SkypeControlAPIAttach = 0;

        private IntPtr mySkypeHandle = IntPtr.Zero;

        public event SkypeAttachHandler SkypeAttach;
        public event SkypeResponseHandler SkypeResponse;

        protected override void WndProc(ref Message m)
        {
            UInt32 aMsg = (UInt32)m.Msg;

            if (aMsg == UM_SkypeControlAPIAttach)
            {
                SkypeAttachStatus anAttachStatus = (SkypeAttachStatus)m.LParam;

                if (anAttachStatus == SkypeAttachStatus.Success)
                    mySkypeHandle = m.WParam;

                if (SkypeAttach != null)
                    SkypeAttach(this, new SkypeAttachEventArgs(anAttachStatus));

                m.Result = new IntPtr(1);
                return;
            }

            if (aMsg == WM.COPYDATA)
            {
                if (m.WParam == mySkypeHandle)
                {
                    CopyDataStruct aCDS = (CopyDataStruct)m.GetLParam(typeof(CopyDataStruct));
                    /*object ddd = m.GetLParam((typeof(Platform.CopyDataStruct)));
                    string sss = ddd.ToString();
                    Platform.CopyDataStruct aCDS = (Platform.CopyDataStruct)ddd;*/
                    //string aResponse = aCDS.Data;
                    string aResponse = "Data: " + aCDS.Data + " SkypeHandle: " + mySkypeHandle + " HWnd: " + m.HWnd.ToString();

                    if (SkypeResponse != null)
                        SkypeResponse(this, new SkypeResponseEventArgs(aResponse));

                    m.Result = new IntPtr(1);
                    return;
                }
                else
                {
                    object ddd = m.GetLParam((typeof(CopyDataStruct)));
                }
            }

            base.WndProc(ref m);
        }
    }
}
