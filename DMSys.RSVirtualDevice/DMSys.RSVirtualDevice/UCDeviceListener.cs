using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMSys.RSVirtualDevice
{
    public partial class UCDeviceListener : UCVirtualDevice
    {
        private string _SPRMessageValue = "";
        private string _SPRMessageKey = "";

        private LogDevice _Log = null;

        public UCDeviceListener(LogDevice log)
        {
            InitializeComponent();
            _Log = log;
        }

        public override bool IsOpen
        {
            get { return sPort.IsOpen; }
        }

        public override void Start()
        {
            sPort.PortName = "COM" + ((int)nudComNo.Value).ToString();
            sPort.ReadTimeout = 500;
            sPort.Open();
            
            bgwReader.RunWorkerAsync();

            /*
            if (sPort.IsOpen)
            {
                byte[] bufferWrite = new byte[]{13};
                //sPort.Write(bufferWrite, 0, bufferWrite.Length);

                byte[] buffer = new byte[1];
                sPort.Read(buffer, 0, buffer.Length);

                // string dd = sPort.ReadLine();
                LogSet("ReadByte", "OK");
            }*/
        }

        public override void Stop()
        {
            sPort.Close();
        }

        private void bgwReader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _SPRMessageValue = sPort.ReadLine();
                _SPRMessageKey = "ReadLine";
            }
            catch (Exception ex)
            {
                if (typeof(TimeoutException) == ex.GetType())
                {
                    _SPRMessageKey = "";
                    _SPRMessageValue = "";
                }
                else
                {
                    _SPRMessageValue = ex.Message;
                    _SPRMessageKey = ex.GetType().ToString();
                }
            }
        }

        private void bgwReader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _Log.Set(_SPRMessageKey, _SPRMessageValue);
            if (sPort.IsOpen)
            {
                bgwReader.RunWorkerAsync();
            }
        }
    }
}
