using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DMSys.Controls
{
    public partial class DataGridHotel : UserControl
    {
        #region Properties

        private int _ControlWidth = 0;  // Последния размер на контрола
        private int _HeaderColumn_Height = 40;
        private int _HeaderColumn_Width = 0;

        /// <summary>
        /// 
        /// </summary>
        private Color _HeaderColumn_BackColor = Color.FromArgb(217, 224, 236);
        [Category("Behavior")]
        [Description("")]
        public Color HeaderColumn_BackColor
        {
            get
            { return _HeaderColumn_BackColor; }
            set
            { _HeaderColumn_BackColor = value; }
        }

        /// <summary>
        /// Цвят на първото заглавие на реда
        /// </summary>
        private Color _HeaderRowA_BackColor = Color.FromArgb(182, 200, 241);
        [Category("Behavior")]
        [Description("Цвят на първото заглавие на реда")]
        public Color HeaderRowA_BackColor
        {
            get
            { return _HeaderRowA_BackColor; }
            set
            { _HeaderRowA_BackColor = value; }
        }

        /// <summary>
        /// Цвят на първото заглавие на реда /Стая за почистване/
        /// </summary>
        private Color _HeaderRowA_BCClean = Color.FromArgb(244, 200, 113);
        [Category("Behavior")]
        [Description("Цвят на първото заглавие на реда /Стая за почистване/")]
        public Color HeaderRowA_BCClean
        {
            get
            { return _HeaderRowA_BCClean; }
            set
            { _HeaderRowA_BCClean = value; }
        }

        /// <summary>
        /// Цвят на второто заглавие на реда
        /// </summary>
        private Color _HeaderRowB_BackColor = Color.FromArgb(217, 224, 236);
        [Category("Behavior")]
        [Description("Цвят на второто заглавие на реда")]
        public Color HeaderRowB_BackColor
        {
            get
            { return _HeaderRowB_BackColor; }
            set
            { _HeaderRowB_BackColor = value; }
        }

        private Color _RoomRegister_BackColor = Color.Red;
        [Category("Behavior")]
        [Description("Цвят на регистрираните стаи")]
        public Color RoomRegister_BackColor
        {
            get
            { return _RoomRegister_BackColor; }
            set
            { _RoomRegister_BackColor = value; }
        }

        private Color _RoomRegisterFree_BackColor = Color.OrangeRed;
        [Category("Behavior")]
        [Description("Цвят на освободени от регистрация стая")]
        public Color RoomRegisterFree_BackColor
        {
            get
            { return _RoomRegisterFree_BackColor; }
            set
            { _RoomRegisterFree_BackColor = value; }
        }

        private Color _RoomReserve_BackColor = Color.Green;
        [Category("Behavior")]
        [Description("Цвят на резервирание стаи")]
        public Color RoomReserve_BackColor
        {
            get
            { return _RoomReserve_BackColor; }
            set
            { _RoomReserve_BackColor = value; }
        }

        private int _HeaderRow_Width = 70;
        private int _HeaderRow_Height = 20;
        private int _HeaderRow_Count = 2;   // Брой клетки в заглавието на реда

        // Padding за грида
        private Padding _GridPadding = new Padding(1,0,1,0);

        private const int _ViewDays = 16; // Брой дни за визуализация

        private RoomDetail _SelectCell = null;
        /// <summary>
        /// Маркирана клетка: При преминаване на мишката
        /// </summary>
        public RoomDetail SelectCell
        {
            get
            { return _SelectCell; }
        }

        private RoomDetail _CurrentCell = null;
        /// <summary>
        /// Маркирана клетка: При кликване на мишката
        /// </summary>
        public RoomDetail CurrentCell
        {
            get
            { return _CurrentCell; }
        }

        // клетки за данни
        private Label[] _CellsHeader = new Label[3];
        // клетки за данни: Дни от месеца /под заглавие/
        private Label[] _CellsSHeader = new Label[_ViewDays];
        // клетки за данни: информация за стаите
        private Label[,] _CellsData = null;
        // клетки за данни: заглавие на редовете
        private Label[,] _CellsHData = null;

        private DateTime _FromDate = DateTime.Now;
        /// <summary>
        /// Начална дата
        /// </summary>
        public DateTime FromDate
        {
            set
            { _FromDate = value; }
        }

        private DataTable _DataReservation = null;
        public DataTable DataReservation
        {
            set
            { _DataReservation = value; }
        }

        private DataTable _DataRooms = null;
        public DataTable DataRooms
        {
            set
            { _DataRooms = value; }
        }

        #endregion Properties

        #region Events

        public delegate void EventHandlerHotelEvent(object sender, RoomDetail RDetail);
        public delegate void EventHandlerHotelRoom(object sender, RoomData RData);

        public event EventHandlerHotelEvent HotelRoomRegister;
        public event EventHandlerHotelEvent HotelRoomReserve;
        public event EventHandlerHotelRoom HotelRoomProperty;
        public event EventHandlerHotelRoom HotelRoomClean;

        #endregion Events

        public DataGridHotel()
        {
            InitializeComponent(); 
        }

        public void DataLoad()
        {
            this.SuspendLayout();
            try
            {
                UnSelectSell();
                this.Controls.Clear();
                //
                _HeaderColumn_Width = (_ControlWidth - _HeaderRow_Width) / _ViewDays;
                // Заглавни редове на грида
                AddHeaderRow();
                SetHeaderData();
                //
                AddRows();
                SetRowsData();
            }
            finally
            {
                this.ResumeLayout(false);
            }
        }

        /// <summary>
        /// Опреснява данните в грида
        /// </summary>
        public void DataRefresh()
        {
            this.SuspendLayout();
            try
            {
                UnSelectSell();

                SetHeaderData();
                SetRowsData();

                SelectSell();
            }
            finally
            {
                this.ResumeLayout(false);
            }
        }

        /// <summary>
        /// Маркира последно избраната позиция
        /// </summary>
        private void SelectSell()
        {
            if (_CurrentCell != null)
            {
                Label lbCell = _CellsData[_CurrentCell.GridPos_X, _CurrentCell.GridPos_Y];
                lbCell.Left += 1;
                lbCell.Top += 1;
                lbCell.Width -= 2;
                lbCell.Height -= 2;
            }
        }

        /// <summary>
        /// Демаркира последно избраната позиция
        /// </summary>
        private void UnSelectSell()
        {
            if (_CurrentCell != null)
            {
                Label lbCell = _CellsData[_CurrentCell.GridPos_X, _CurrentCell.GridPos_Y];
                lbCell.Left -= 1;
                lbCell.Top -= 1;
                lbCell.Width += 2;
                lbCell.Height += 2;
                //
                _CurrentCell = null;
            }
        }

        #region DataRows

        /// <summary>
        /// Зарежда редовете на грида
        /// </summary>
        public void AddRows()
        {
            if (_DataRooms != null)
            {
                // масив със заетоста на стаите по дни
                _CellsData = new Label[_ViewDays + _HeaderRow_Count, _DataRooms.Rows.Count];
                // масив с номерацията на стаите
                _CellsHData = new Label[2, _DataRooms.Rows.Count];
                for (int i = 0; i < _DataRooms.Rows.Count; i++)
                {
                    AddRow(i);
                }
            }
        }

        /// <summary>
        /// Добавя ред към грида
        /// </summary>
        private void AddRow(int aRowNo)
        {
            // Данни за стаята
            RoomData dRoom = new RoomData();
            dRoom.RoomID = Convert.ToInt32(_DataRooms.Rows[aRowNo]["room_id"]);
            dRoom.RoomName = _DataRooms.Rows[aRowNo]["room_name"].ToString();
            dRoom.GridRowNo = aRowNo;
            dRoom.IsClean = _DataRooms.Rows[aRowNo]["is_clean"].ToString().Equals("Y");
            dRoom.TypeName = _DataRooms.Rows[aRowNo]["type_name"].ToString();

            // Тип стая
            Label lRT = new Label();
            lRT.Text = _DataRooms.Rows[aRowNo]["type_name"].ToString();
            lRT.TextAlign = ContentAlignment.MiddleCenter;
            lRT.Height = _HeaderRow_Height + 1;
            lRT.Width = 36;
            lRT.Left = _GridPadding.Left;
            lRT.Top = _HeaderColumn_Height + (int)(aRowNo * _HeaderRow_Height);
            lRT.Margin = new Padding(0);
            lRT.BorderStyle = BorderStyle.FixedSingle;
            lRT.BackColor = _HeaderRowA_BackColor;
            lRT.Tag = dRoom;

            _CellsHData[0, aRowNo] = lRT;
            this.Controls.Add(lRT);

            // Номер стая
            Label lRN = new Label();
            lRN.Text = _DataRooms.Rows[aRowNo]["room_name"].ToString();
            lRN.TextAlign = ContentAlignment.MiddleCenter;
            lRN.Height = _HeaderRow_Height + 1;
            lRN.Width = 36;
            lRN.BorderStyle = BorderStyle.FixedSingle;
            lRN.BackColor = _HeaderRowB_BackColor;
            lRN.Left = _GridPadding.Left + 35;
            lRN.Top = _HeaderColumn_Height + (int)(aRowNo * _HeaderRow_Height);
            lRN.Margin = new Padding(0);
            lRN.Tag = dRoom;

            _CellsHData[1, aRowNo] = lRN;
            this.Controls.Add(lRN);

            // Данни за стаите
            for (int i = 0; i < _ViewDays; i++)
            {
                Label lRD = new Label();
                lRD.Text = "";
                lRD.TextAlign = ContentAlignment.MiddleLeft;
                lRD.BackColor = Color.White;
                lRD.ForeColor = Color.White;
                lRD.Cursor = Cursors.Hand;
                lRD.Font = new Font(FontFamily.GenericSansSerif, (float)8.25, FontStyle.Bold);
                lRD.Height = (_HeaderColumn_Height / 2) + 1;
                lRD.Width = _HeaderColumn_Width + 1;
                lRD.Left = _GridPadding.Left + _HeaderRow_Width + (int)(i * _HeaderColumn_Width);
                lRD.Top = _HeaderColumn_Height + (int)(aRowNo * _HeaderRow_Height);
                lRD.BorderStyle = BorderStyle.FixedSingle;
                
                // Детайлна информация за стаята
                RoomDetail aRS = new RoomDetail();
                aRS.GridPos_X = _HeaderRow_Count + i;
                aRS.GridPos_Y = aRowNo;
                aRS.RoomID = Convert.ToInt32(_DataRooms.Rows[aRowNo]["room_id"]);
                aRS.RoomName = _DataRooms.Rows[aRowNo]["room_name"].ToString();
                aRS.GridRowNo = aRowNo;
                lRD.Tag = (object)aRS;
                lRD.MouseEnter += RoomData_Enter;
                lRD.MouseClick += RoomData_Click;
                lRD.DoubleClick += RoomData_DoubleClick;
                //
                _CellsData[_HeaderRow_Count + i, aRowNo] = lRD;
                this.Controls.Add(lRD);
            }
        }

        /// <summary>
        /// Зарежда редовете на грида с данни
        /// </summary>
        public void SetRowsData()
        {
            if ((_DataRooms != null) && (_DataReservation != null))
            {
                ClearRoomsState();
                //
                for (int i = 0; i < _DataRooms.Rows.Count; i++)
                {
                    bool bIsClean = _DataRooms.Rows[i]["is_clean"].ToString().Equals("Y");
                    ((RoomData)(_CellsHData[0, i].Tag)).IsClean = bIsClean;
                    if (bIsClean)
                    { _CellsHData[0, i].BackColor = _HeaderRowA_BackColor; }
                    else
                    { _CellsHData[0, i].BackColor = _HeaderRowA_BCClean; }
                }
                // обхожда списъка с резервации и регистрации
                foreach (DataRow dr in _DataReservation.Rows)
                {
                    // клетка: начало
                    int cell_from = Convert.ToInt32(dr["cell_from"]);
                    // клетка: край
                    int cell_to = Convert.ToInt32(dr["cell_to"])-1;
                    // валидация
                    if (cell_from < 0)
                    {
                        cell_to += cell_from;
                        cell_from = 0;
                    }
                    int aCellFrom = _HeaderRow_Count + cell_from;
                    // ред от грида
                    int iRowNo = FindRowNo(dr["room_id"]);
                    
                    // Допълнителна информация
                    if (iRowNo != -1)
                    {
                        RoomDetail aRS = (RoomDetail)_CellsData[aCellFrom, iRowNo].Tag;
                        aRS.RoomID = Convert.ToInt32(dr["room_id"]);
                        aRS.RoomName = dr["room_name"].ToString();
                        aRS.BusyID = Convert.ToInt64(dr["rwrk_id"]);
                        aRS.BusyType = ConvertRStatus.GetStatus(dr["rwrk_kind"]);
                        aRS.ClientID = Convert.ToInt64(dr["client_id"]);
                        aRS.ClientName = dr["client_name"].ToString();
                        aRS.BusyDateFrom = Convert.ToDateTime(dr["date_from"]);
                        aRS.BusyDateTo = Convert.ToDateTime(dr["date_to"]);
                        aRS.RateRemaining = Convert.ToDecimal(dr["rate_remaining"]) / 100;
                        aRS.HasLeft = dr["has_left"].ToString().Equals("Y");

                        // Задава статус за стаята
                        SetRoomData(iRowNo, aCellFrom, cell_to, aRS);
                    }
                }
            }
        }

        /// <summary>
        /// Търси номера на реда
        /// </summary>
        private int FindRowNo( object aRoomID )
        {
            for (int i = 0; i < _DataRooms.Rows.Count; i++)
            {
                if (_DataRooms.Rows[i]["room_id"].Equals(aRoomID))
                { return i; }
            }
            return -1;
        }

        /// <summary>
        /// Задава статус на стаята
        /// </summary>
        private void SetRoomData(int aRowNo, int aCellFrom, int aCellTo, RoomDetail aRDetail)
        {
            if (aCellTo > -1)
            {
                // валидация
                int iCellTo = aCellTo;
                if ((aCellFrom + iCellTo) > _ViewDays)
                { iCellTo = (_ViewDays - aCellFrom) + 1; }
                //
                Label lbSelectCell = _CellsData[aCellFrom, aRowNo];
                switch (aRDetail.BusyType)
                {
                    case RStatus.fsRegister:
                        if (aRDetail.HasLeft)
                        { lbSelectCell.BackColor = _RoomRegisterFree_BackColor; }
                        else
                        { lbSelectCell.BackColor = _RoomRegister_BackColor; }
                        break;
                    case RStatus.fsReserve:
                        lbSelectCell.BackColor = _RoomReserve_BackColor;
                        break;
                }
                lbSelectCell.Text = aRDetail.ClientName;
                lbSelectCell.Width = ((iCellTo + 1) * _HeaderColumn_Width) + 1;
                //
                for (int i = 1; i <= iCellTo; i++)
                {
                    _CellsData[aCellFrom + i, aRowNo].Visible = false;
                }
            }
        }

        /// <summary>
        /// Изчиства статуса на стаите
        /// </summary>
        private void ClearRoomsState()
        {
            for (int rw = 0; rw < _DataRooms.Rows.Count; rw++)
            {
                for (int cln = 0; cln < _ViewDays; cln++)
                {
                    Label lbCellData = _CellsData[_HeaderRow_Count + cln, rw];
                    //
                    lbCellData.BackColor = Color.White;
                    lbCellData.Width = _HeaderColumn_Width + 1;
                    lbCellData.Visible = true;
                    //
                    RoomDetail rdCellData = (RoomDetail)lbCellData.Tag;
                    rdCellData.BusyType = RStatus.fsEmpty;
                    rdCellData.BusyID = 0;

                    //_CellsData[_HeaderRow_Count + cln, rw].BackColor = Color.White;
                   // _CellsData[_HeaderRow_Count + cln, rw].Width = _HeaderColumn_Width + 1;
                   // _CellsData[_HeaderRow_Count + cln, rw].Visible = true;
                }
            }
        }

        #endregion DataRows

        #region HeaderRows

        private void AddHeaderRow()
        {
            // Първата клетка
            Label lHC = new Label();
            lHC.Text = "";
            lHC.Height = _HeaderColumn_Height + 1;
            lHC.Width = _HeaderRow_Width + 1;
            lHC.Left = _GridPadding.Left;
            lHC.Top = 0;
            lHC.BorderStyle = BorderStyle.FixedSingle;

            _CellsHeader[0] = lHC;
            this.Controls.Add(lHC);

            // клетката за първия месец
            Label lMN1 = new Label();
            lMN1.Text = "";
            lMN1.TextAlign = ContentAlignment.MiddleCenter;
            lMN1.Height = (_HeaderColumn_Height / 2) + 1;
            lMN1.Width = _HeaderColumn_Width * (_ViewDays / 2) + 1;
            lMN1.Left = _GridPadding.Left + _HeaderRow_Width;
            lMN1.Top = 0;
            lMN1.BackColor = Color.FromArgb(182, 200, 241);
            lMN1.BorderStyle = BorderStyle.FixedSingle;

            _CellsHeader[1] = lMN1;
            this.Controls.Add(lMN1);

            // клетката за втория месец
            Label lMN2 = new Label();
            lMN2.Text = "";
            lMN2.TextAlign = ContentAlignment.MiddleCenter;
            lMN2.Height = (_HeaderColumn_Height / 2) + 1;
            lMN2.Width = _HeaderColumn_Width * (_ViewDays / 2) + 1;
            lMN2.Left = _GridPadding.Left + _HeaderRow_Width + (_HeaderColumn_Width * (_ViewDays / 2));
            lMN2.Top = 0;
            lMN2.BackColor = Color.FromArgb(152, 185, 247);
            lMN2.BorderStyle = BorderStyle.FixedSingle;

            _CellsHeader[2] = lMN2;
            this.Controls.Add(lMN2);

            // дни от месеца
            for (int i = 0; i < _ViewDays; i++)
            {
                Label hdr = new Label();
                hdr.Text = "";
                hdr.TextAlign = ContentAlignment.MiddleCenter;
                hdr.BackColor = _HeaderColumn_BackColor;
                hdr.Height = (_HeaderColumn_Height / 2) + 1;
                hdr.Width = (int)_HeaderColumn_Width + 1;
                hdr.Left = _GridPadding.Left + _HeaderRow_Width + (int)(i * _HeaderColumn_Width);
                hdr.Top = 20;
                hdr.BorderStyle = BorderStyle.FixedSingle;
                _CellsSHeader[i] = hdr;
                this.Controls.Add(hdr);
            }
        }

        private void SetHeaderData()
        {
            // Последен ден от месеца
            DateTime dtEnd = new DateTime(_FromDate.Year, _FromDate.Month, 1, 0, 0, 0).AddMonths(1).AddDays(-1);
            // Брои дни до края на месеца
            int iLastDay = (dtEnd.Day - _FromDate.Day) + 1;
            if (iLastDay > _ViewDays)
            { iLastDay = _ViewDays; }

            // име на първия месеца
            _CellsHeader[1].Text = _FromDate.ToString("MMMM");
            _CellsHeader[1].Width = _HeaderColumn_Width + (_HeaderColumn_Width * (iLastDay-1)) + 1;
            // име на следвашия месеца
            if (iLastDay < _ViewDays)
            {
                _CellsHeader[2].Text = _FromDate.AddMonths(1).ToString("MMMM");
                _CellsHeader[2].Width = _HeaderColumn_Width + (_HeaderColumn_Width * (_ViewDays - iLastDay - 1)) + 1;
                _CellsHeader[2].Left = _GridPadding.Left + _HeaderRow_Width + (_HeaderColumn_Width * iLastDay);
                _CellsHeader[2].Visible = true;
            }
            else // има само един месец
            {
                _CellsHeader[2].Visible = false;
            }
            
            // дни от месеца
            for (int i = 0; i < _ViewDays; i++)
            {
                _CellsSHeader[i].Text = _FromDate.AddDays(i).ToString("ddd dd");
                _CellsSHeader[i].Width = (int)_HeaderColumn_Width + 1;
                _CellsSHeader[i].Left = _GridPadding.Left + _HeaderRow_Width + (int)(i * _HeaderColumn_Width);
            }
        }

        #endregion HeaderRows

        #region Grid Events

        private void ReservationGrid_Resize(object sender, EventArgs e)
        {
            if (_ControlWidth != this.Width)
            {
                _ControlWidth = this.Width;
                //
                UnSelectSell();
                DataLoad();
                SelectSell();
            }
        }

        private void RoomData_Enter(object sender, EventArgs e)
        {
            if (_SelectCell != null)
            {
                _CellsSHeader[_SelectCell.GridPos_X - 2].BackColor = _HeaderColumn_BackColor;
                _CellsHData[1, _SelectCell.GridPos_Y].BackColor = _HeaderRowB_BackColor;
            }
            //
            _SelectCell = ((RoomDetail)((Label)sender).Tag);
            // Маркира заглавието на клетката
            _CellsSHeader[_SelectCell.GridPos_X - 2].BackColor = Color.FromArgb(244, 200, 113);
            _CellsHData[1, _SelectCell.GridPos_Y].BackColor = Color.FromArgb(244, 200, 113);
            //
            if (!_SelectCell.BusyType.Equals(RStatus.fsEmpty))
            {
                tTip.ToolTipTitle = _SelectCell.ClientName;
                tTip.SetToolTip((Label)sender, "Дължи: " + _SelectCell.RateRemaining.ToString("#0.00"));
            }
        }

        private void RoomData_Click(object sender, MouseEventArgs e)
        {
            // Задава defaut ст-ст на последно избраната клетка
            if (_CurrentCell != null)
            {
                Label lbCellOld = _CellsData[_CurrentCell.GridPos_X, _CurrentCell.GridPos_Y];
                lbCellOld.Left -= 1;
                lbCellOld.Top -= 1;
                lbCellOld.Width += 2;
                lbCellOld.Height += 2;
            }
            // Маркира избраната клетка
            Label lbCell = ((Label)sender);
            _CurrentCell = ((RoomDetail)lbCell.Tag);
            // Променя размера на избраната клетка
            lbCell.Left += 1;
            lbCell.Top += 1;
            lbCell.Width -= 2;
            lbCell.Height -= 2;
            //
            if (e.Button == MouseButtons.Right)
            {
                Control cntrl = (Control)sender;
                cntxtMnStrp.Show(cntrl, 0, cntrl.Height-1);
            }
        }

        private void RoomData_DoubleClick(object sender, EventArgs e)
        {
            switch (_SelectCell.BusyType)
            {
                case RStatus.fsRegister:
                    if (HotelRoomRegister != null)
                    { HotelRoomRegister(this, _SelectCell); }
                    break;
                case RStatus.fsReserve:
                    if (HotelRoomReserve != null)
                    { HotelRoomReserve(this, _SelectCell); }
                    break;
                default:
                    if (HotelRoomProperty != null)
                    { HotelRoomProperty(this, ((RoomData)((Label)_CellsHData[0, _SelectCell.GridRowNo]).Tag)); }
                    break;
            }
        }

        private void tsmiRoomReserve_Click(object sender, EventArgs e)
        {
            if (HotelRoomReserve != null)
            { HotelRoomReserve(this, _SelectCell); }
        }

        private void tsmiRoomRegister_Click(object sender, EventArgs e)
        {
            if (HotelRoomRegister != null)
            { HotelRoomRegister(this, _SelectCell); }
        }

        private void tsmiRoomProperty_Click(object sender, EventArgs e)
        {
            if (HotelRoomProperty != null)
            { HotelRoomProperty(this, ((RoomData)((Label)_CellsHData[0, _SelectCell.GridRowNo]).Tag)); }
        }

        private void tsmiRoomClean_Click(object sender, EventArgs e)
        {
            if (HotelRoomClean != null)
            { HotelRoomClean(this, ((RoomData)((Label)_CellsHData[0, _SelectCell.GridRowNo]).Tag)); }
        }

        private void cntxtMnStrp_Opening(object sender, CancelEventArgs e)
        {
            switch (_SelectCell.BusyType)
            {
                case RStatus.fsRegister:
                    tsmiRoomReserve.Enabled = false;
                    break;
                default:
                    tsmiRoomReserve.Enabled = true;
                    break;
            }
            //
            if (((RoomData)_CellsHData[0,_SelectCell.GridRowNo].Tag).IsClean)
            { tsmiRoomClean.Text = "За почистване"; }
            else
            { tsmiRoomClean.Text = "Почистена"; }
        }

        #endregion Grid Events
    }
}
