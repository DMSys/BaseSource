using System;
using System.Collections.Generic;
using System.Text;

namespace DMSys.Controls
{
    /// <summary>
    /// Статус на стаята
    /// </summary>
    public enum RStatus { fsEmpty, fsReserve, fsRegister, fsPause }

    /// <summary>
    /// Преобразува статуси
    /// </summary>
    public static class ConvertRStatus
    {
        private static char _TReserve = 'S';
        /// <summary>
        /// Резервация
        /// </summary>
        public static char TReserve
        {
            get
            { return _TReserve; }
        }

        private static char _TRegister = 'G';
        /// <summary>
        /// Регистрация
        /// </summary>
        public static char TRegister
        {
            get
            { return _TRegister; }
        }

        private static char _TPause = 'P';
        /// <summary>
        /// Почивка
        /// </summary>
        public static char TPause
        {
            get
            { return _TPause; }
        }

        private static char _TEmpty = 'E';
        /// <summary>
        /// Празна
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
    /// Детайлна информация за събитие
    /// </summary>
    public class RoomDetail
    {
        /// <summary>
        /// Заетост: ID
        /// </summary>
        public Int64 BusyID = 0;

        /// <summary>
        /// Заетос: Тип
        /// </summary>
        public RStatus BusyType = RStatus.fsEmpty;

        public DateTime BusyDateFrom = DateTime.Now;

        public DateTime BusyDateTo = DateTime.Now;

        /// <summary>
        /// Стая: ID
        /// </summary>
        public Int32 RoomID = 0;

        /// <summary>
        /// Стая: Номер
        /// </summary>
        public string RoomName = "";

        /// <summary>
        /// Клиент: ID
        /// </summary>
        public Int64 ClientID = 0;

        /// <summary>
        /// Клиент: Име
        /// </summary>
        public string ClientName = "";

        /// <summary>
        /// Задължение на клиента
        /// </summary>
        public decimal RateRemaining = 0;

        /// <summary>
        /// Позиция на клетката в грида по X
        /// </summary>
        public int GridPos_X = 0;

        /// <summary>
        /// Позиция на клетката в грида по Y
        /// </summary>
        public int GridPos_Y = 0;

        /// <summary>
        /// Номер на ред в грида
        /// </summary>
        public Int32 GridRowNo = 0;

        /// <summary>
        /// Стаята е освободена
        /// </summary>
        public bool HasLeft = false;
    }

    /// <summary>
    /// Данни на стая
    /// </summary>
    public class RoomData
    {
        /// <summary>
        /// Стая: ID
        /// </summary>
        public Int32 RoomID = 0;

        /// <summary>
        /// Стая: Номер
        /// </summary>
        public string RoomName = "";

        /// <summary>
        /// Тип на стаята
        /// </summary>
        public string TypeName = "";

        /// <summary>
        /// Номер на ред в грида
        /// </summary>
        public Int32 GridRowNo = 0;

        /// <summary>
        /// true - Почистена е стаята
        /// false - За почистване е стаята
        /// </summary>
        public bool IsClean = true;
        
    }

}
