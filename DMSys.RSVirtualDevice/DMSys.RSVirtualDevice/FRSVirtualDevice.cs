using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMSys.RSVirtualDevice
{
    public partial class FRSVirtualDevice : Form
    {
        private UCVirtualDevice device = null;

        private LogDevice _Log = null;

        public FRSVirtualDevice()
        {
            InitializeComponent();
            _Log = new LogDevice(rtbRSLog);
        }

        private void FRSVirtualDevice_Load(object sender, EventArgs e)
        {
            _Log.Clear();
            tscbTypeDevice.SelectedIndex = 0;
        }

        private void tsbStartStop_Click(object sender, EventArgs e)
        {
            if (device == null)
            { return; }
            try
            {
                if (device.IsOpen)
                {
                    device.Stop();
                    tsbStartStop.Text = "Start";
                }
                else
                {
                    device.Start();
                    tsbStartStop.Text = "Stop";
                }
            }
            catch (Exception ex)
            {
                _Log.Set(ex.GetType().ToString(), ex.Message);
            }
        }

        private void tscbTypeDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (device != null)
            {
                device.Stop();
                device.Dispose();
                device = null;
            }
            pnlDevice.Controls.Clear();

            switch (tscbTypeDevice.SelectedIndex)
            { 
                case 1:
                    device = new UCDeviceListener(_Log);
                    device.Dock = DockStyle.Fill;

                    pnlDevice.Controls.Add(device);
                    break;
            }
        }
    }
}