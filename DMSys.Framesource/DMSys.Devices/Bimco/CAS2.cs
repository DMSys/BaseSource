using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace DMSys.Devices.Bimco
{
    public class CAS2 : IDisposable
    {
        #region Propeties

        private string _ExceptionMessage = "";

        private int indexRs = 0;

        private int _PortNumber = 1;

        private SerialPort _SPort = null;

        private byte[] _Response = new byte[4];

        public byte[] Response
        {
            get
            { return _Response; }
        }

        public string ResponseString
        {
            get
            {
                string valueRs = "";
                foreach (byte b in _Response)
                {
                    valueRs += b.ToString() + " ";
                }
                return valueRs;
            }
        }

        public decimal ResponseWeight
        {
            get
            {
                string sWeight = BitConverter.ToString(_Response, 0, 3).Replace("-", "");
                decimal dWeight = 0;
                if (Decimal.TryParse(sWeight, out dWeight))
                { return dWeight / 1000; }
                else
                { return 0; }
            }
        }

        #endregion Propeties
        
        public CAS2(int portNumber)
        {
            _PortNumber = portNumber;

            _SPort = new SerialPort("COM" + portNumber.ToString());
            _SPort.BaudRate = 9600;
            _SPort.DataBits = 8;
            _SPort.Parity = System.IO.Ports.Parity.None;
            _SPort.StopBits = System.IO.Ports.StopBits.One;
            _SPort.Handshake = System.IO.Ports.Handshake.None;
            _SPort.ReadTimeout = 500;

            _SPort.DataReceived += serialPort_DataReceived;
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;
                
                string indata = sp.ReadExisting();
                int ix = 0;
                for (int i = 0; i < indata.Length; i++)
                {
                    byte bt = ((byte)indata[i]);
                    if ( (indexRs + i < 4) && (bt != 63)) // 0x3F
                    {
                        _Response[indexRs + i] = bt;
                        ix++;
                    }
                }
                indexRs += ix;
            }
            catch (Exception ex)
            {
                _ExceptionMessage = ex.Message;
            }
        }

        public void Open()
        {
            _SPort.Open();
        }

        public void Close()
        {
            _SPort.Close();
        }

        public void Dispose()
        {
            if (_SPort != null)
            {
                if (_SPort.IsOpen)
                {
                    _SPort.Close();
                }
                _SPort.Dispose();
                _SPort = null;
            }
            GC.Collect();
        }

        /// <summary>
        /// Команда: Тегло
        /// </summary>
        public void CommandWeight()
        {
            byte[] requestByte = { 0xAA };
            _SPort.Write(requestByte, 0, 1);

            try
            {
                indexRs = 1;
                byte bt = (byte)_SPort.ReadByte();
                if (0xBB == bt)
                {
                }
                else
                {
                    _Response[0] = bt;   
                }
            }
            catch
            {
                for (int i = 0; i < _Response.Length; i++)
                {
                    _Response[i] = 0;
                }
            }
        }

        /// <summary>
        /// Команда: Тариране
        /// </summary>
        public void CommandCalibration()
        {
            byte[] requestByte = { 0xCC };
            _SPort.Write(requestByte, 0, 1);
        }
    }
}
