using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace DMSys.Devices.Elicom
{
    public class ElicomEEP: IDisposable
    {
        public enum Protocols { Protocol0, Protocol1, Protocol2 }

        #region Propeties

        private SerialPort _SPort = null;

        private Protocols _Protocol = Protocols.Protocol1;

        #endregion Propeties

        #region Events

        public event ElicomMeasurementEventHandler Measurement;

        protected virtual void OnMeasurement(ElicomMeasurement e)
        {
            if (Measurement != null)
                Measurement(this, e);
        }

        #endregion Events

        public ElicomEEP(Protocols protocol, int portNumber)
        {
            _Protocol = protocol;

            _SPort = new SerialPort("COM" + portNumber.ToString());
            _SPort.BaudRate = 9600;
            _SPort.DataBits = 8;
            _SPort.Parity = Parity.None;
            _SPort.StopBits = StopBits.One;
            switch (protocol)
            {
                case Protocols.Protocol0:
                    _SPort.ReadTimeout = -1;
                    break;
                case Protocols.Protocol1:
                    _SPort.ReadTimeout = 500;
                    break;
                case Protocols.Protocol2:
                    _SPort.ReadTimeout = -1;
                    break;
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
        /// Изпраща заявка към устройството
        /// </summary>
        public void SendRequest()
        {
            switch(_Protocol)
            {
                case Protocols.Protocol1:
                    byte[] requestByte = { 0xF1 }; // за 'протокол 1'
                    // byte[] requestByte = { 0x05 }; // за 'протокол 1' и 'протокол 3'
                    this._SPort.Write(requestByte, 0, 1);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Прочети отговора от устройството
        /// </summary>
        /// <returns></returns>
        public ElicomMeasurement ReadMeasurement()
        {
            byte[] buffer = new byte[1];
            // Структора
            byte[] FLAGS_BYTE = new byte[1];
            string signValue = "+";
            string poundsValue = "0";
            string gramsValue = "0";
            // Прочита пакета
            int index = 0;
            while (buffer[0] != 13 /* CR_BYTE */)
            {
                this._SPort.Read(buffer, 0, 1);
                switch (index)
                {
                    case 0:
                        FLAGS_BYTE[0] = buffer[0];
                        break;
                    case 1: // ASCII символ ‘+’ или ‘-‘.
                        signValue = Encoding.ASCII.GetString(buffer);
                        break;
                    case 2: // ASCII символи ‘0’…’9‘ - за килограми
                    case 3:
                    case 4:
                        poundsValue += Encoding.ASCII.GetString(buffer);
                        break;
                    case 5: // ASCII символ ‘.’ (точка)
                        break;
                    case 6: // ASCII символи ‘0’…’9‘ - за грамове
                    case 7:
                    case 8:
                        gramsValue += Encoding.ASCII.GetString(buffer);
                        break;
                    case 9: // 13 (десетично) == ASCII символ “Carriage Return”
                        break;
                }
                index++;
            }
            ElicomMeasurement msrmnt = new ElicomMeasurement();
            msrmnt.SetFlags(FLAGS_BYTE);
            msrmnt.SetValue(signValue, poundsValue, gramsValue);

            OnMeasurement(msrmnt);

            return msrmnt;
        }
    }
}
