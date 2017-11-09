using System;
using System.Collections.Generic;
using System.Text;

namespace DMSys.Controls
{
    /// <summary>
    /// ������ �� ������
    /// </summary>
    public enum RStatus { fsEmpty, fsReserve, fsRegister, fsPause }

    /// <summary>
    /// ����������� �������
    /// </summary>
    public static class ConvertRStatus
    {
        private static char _TReserve = 'S';
        /// <summary>
        /// ����������
        /// </summary>
        public static char TReserve
        {
            get
            { return _TReserve; }
        }

        private static char _TRegister = 'G';
        /// <summary>
        /// �����������
        /// </summary>
        public static char TRegister
        {
            get
            { return _TRegister; }
        }

        private static char _TPause = 'P';
        /// <summary>
        /// �������
        /// </summary>
        public static char TPause
        {
            get
            { return _TPause; }
        }

        private static char _TEmpty = 'E';
        /// <summary>
        /// ������
        /// </summary>
        public static char TEmpty
        {
            get
            { return _TEmpty; }
        }

        public static RStatus GetStatus(object aValue)
        {
            return GetStatus(Convert.ToChar(aValue));
        }

        public static RStatus GetStatus(char aValue)
        {
            switch (aValue)
            {
                case 'S':
                    return RStatus.fsReserve;
                case 'G':
                    return RStatus.fsRegister;
                case 'P':
                    return RStatus.fsPause;
                case 'E':
                default:
                    return RStatus.fsEmpty;
            }
        }

        public static char GetStatusVaue(RStatus aValue)
        {
            switch (aValue)
            {
                case RStatus.fsReserve:
                    return _TReserve;
                case RStatus.fsRegister:
                    return _TRegister;
                case RStatus.fsPause:
                    return _TPause;
                default:
                    return _TEmpty;
            }
        }
    }

    /// <summary>
    /// �������� ���������� �� �������
    /// </summary>
    public class RoomDetail
    {
        /// <summary>
        /// �������: ID
        /// </summary>
        public Int64 BusyID = 0;

        /// <summary>
        /// ������: ���
        /// </summary>
        public RStatus BusyType = RStatus.fsEmpty;

        public DateTime BusyDateFrom = DateTime.Now;

        public DateTime BusyDateTo = DateTime.Now;

        /// <summary>
        /// ����: ID
        /// </summary>
        public Int32 RoomID = 0;

        /// <summary>
        /// ����: �����
        /// </summary>
        public string RoomName = "";

        /// <summary>
        /// ������: ID
        /// </summary>
        public Int64 ClientID = 0;

        /// <summary>
        /// ������: ���
        /// </summary>
        public string ClientName = "";

        /// <summary>
        /// ���������� �� �������
        /// </summary>
        public decimal RateRemaining = 0;

        /// <summary>
        /// ������� �� �������� � ����� �� X
        /// </summary>
        public int GridPos_X = 0;

        /// <summary>
        /// ������� �� �������� � ����� �� Y
        /// </summary>
        public int GridPos_Y = 0;

        /// <summary>
        /// ����� �� ��� � �����
        /// </summary>
        public Int32 GridRowNo = 0;

        /// <summary>
        /// ������ � ����������
        /// </summary>
        public bool HasLeft = false;
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    public class RoomData
    {
        /// <summary>
        /// ����: ID
        /// </summary>
        public Int32 RoomID = 0;

        /// <summary>
        /// ����: �����
        /// </summary>
        public string RoomName = "";

        /// <summary>
        /// ��� �� ������
        /// </summary>
        public string TypeName = "";

        /// <summary>
        /// ����� �� ��� � �����
        /// </summary>
        public Int32 GridRowNo = 0;

        /// <summary>
        /// true - ��������� � ������
        /// false - �� ���������� � ������
        /// </summary>
        public bool IsClean = true;
        
    }

}
