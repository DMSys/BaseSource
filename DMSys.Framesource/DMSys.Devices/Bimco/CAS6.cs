using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace DMSys.Devices.Bimco
{
    public class CAS6 : IDisposable
    {
        #region Propeties

        private string _ExceptionMessage = "";

        private int _PortNumber = 1;

        private SerialPort _SPort = null;

        private StringBuilder _BufferSB = new StringBuilder();

        private byte[] _Response = new byte[8];

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
                if (_Response[0] == 0xFF)
                {
                    string sWeight = BitConverter.ToString(_Response, 1, 2).Replace("-", "");
                    decimal dWeight = Utilite.HexToBase("FFFF") - Utilite.HexToBase(sWeight) + 1;
                    return dWeight / -1000;
                }
                else
                {
                    string sWeight = BitConverter.ToString(_Response, 0, 3).Replace("-", "");
                    decimal dWeight = Utilite.HexToBase(sWeight);
                    return dWeight / 1000;
                }
            }
        }

        #endregion Propeties

        public CAS6(int portNumber)
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
                
                byte[] buffer = new byte[8];
                if (sp.BytesToRead == 8)
                {
                    sp.Read(buffer, 0, 8);
                    _BufferSB.Clear();
                }
                else
                {
                    _BufferSB.Append(sp.ReadExisting());
                    if (_BufferSB.Length == 8)
                    {
                        Utilite.StrToMas(_BufferSB.ToString(), buffer);
                        _BufferSB.Clear();
                    }
                    else if(_BufferSB.Length > 8)
                    {
                        int pieces = (_BufferSB.Length / 8);
                        int piecesSum = pieces * 8;
                        if (piecesSum == _BufferSB.Length)
                        {
                            Utilite.StrToMas(_BufferSB.ToString().Substring(_BufferSB.Length - 8, 8), buffer);
                            _BufferSB.Clear();
                        }
                        else
                        {
                            int ix = _BufferSB.Length - piecesSum;
                            string piece = _BufferSB.ToString().Substring(_BufferSB.Length - ix, ix);
                            _BufferSB.Clear();
                            _BufferSB.Append(piece);
                        }                        
                    }
                }
                // Валидация
                if ((buffer[6] != 0) || (buffer[7] != 0))
                {
                    int CR = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        CR += buffer[i];
                    }
                    string strCR = BitConverter.ToString(buffer, 6, 2).Replace("-", "");
                    if (CR == Utilite.HexToBase(strCR))
                    {
                        buffer.CopyTo(_Response, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                _ExceptionMessage = ex.Message;
                _BufferSB.Clear();
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
            byte[] requestByte = { 0x36 };
            _SPort.Write(requestByte, 0, 1);
        }

        /// <summary>
        /// Команда: Тариране
        /// </summary>
        public void CommandCalibration()
        {
            byte[] requestByte = { 0x35 };
            _SPort.Write(requestByte, 0, 1);
        }
    }
}
