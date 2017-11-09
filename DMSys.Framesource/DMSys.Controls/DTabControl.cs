using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace DMSys.Controls
{
    /// <summary>
    /// Summary description for UserControl1.
    /// </summary>
    public class DTabControl : System.Windows.Forms.TabControl
    {
        #region Properties

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private ContextMenu _ItemMenu = null;
        public ContextMenu ItemMenu
        {
            get
            { return _ItemMenu; }
            set
            { _ItemMenu = value; }
        }

        #endregion Properties

        #region Events

        public delegate void OnHeaderCloseDelegate(object sender, TabClosedEventArgs e);
        public event OnHeaderCloseDelegate TabClosed;

        #endregion Events

        public DTabControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            this.TabStop = false;

            // TODO: Add any initialization after the InitComponent call

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemSize = new System.Drawing.Size(150, 24);
            this.SizeMode = TabSizeMode.Fixed;
        }

        #endregion

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Bounds != RectangleF.Empty)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                RectangleF tabTextArea = RectangleF.Empty;

                for (int nIndex = 0; nIndex < this.TabCount; nIndex++)
                {
                    if (nIndex != this.SelectedIndex)
                    {
                        tabTextArea = (RectangleF)this.GetTabRect(nIndex);
                        
                        using (LinearGradientBrush _Brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                        {
                            ColorBlend _ColorBlend = new ColorBlend(3);

                            // Drawing Item
                            DrawItemDark(e.Graphics, _Brush, _ColorBlend, tabTextArea);
                            
                            // Drawing Close Button
                            DrawCloseButton_Inactive(e.Graphics, _Brush, tabTextArea, _ColorBlend);

                            if (_ItemMenu != null)
                            {
                                // Drawing menu button
                                DrawMenuButton_Inactive(e.Graphics, _Brush, tabTextArea, _ColorBlend);
                            }
                        }
                    }
                    else
                    {
                        tabTextArea = (RectangleF)this.GetTabRect(nIndex);

                        using (LinearGradientBrush _Brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                        {
                            ColorBlend _ColorBlend = new ColorBlend(3);

                            // Drawing Item
                            DrawItemLight(e.Graphics, _Brush, _ColorBlend, tabTextArea);

                            // Drawing Close Button
                            DrawCloseButton_Active(e.Graphics, _Brush, tabTextArea, _ColorBlend);

                            if (_ItemMenu != null)
                            {
                                // Drawing menu button
                                DrawMenuButton_Active(e.Graphics, _Brush, tabTextArea, _ColorBlend);
                            }
                        }
                    }
                    // Текст
                    DrawText(e.Graphics , this.TabPages[nIndex], tabTextArea);
                }
            }

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!DesignMode)
            {
                RectangleF tabTextArea = (RectangleF)this.GetTabRect(SelectedIndex);
                // зона на бутона
                RectangleF buttonArea = CreateButtonRectangle(tabTextArea, 1);
                if (buttonArea.Contains(e.X, e.Y))
                {
                    if (TabClosed != null)
                    {
                        TabClosedEventArgs tabClosedEA = new TabClosedEventArgs(this.SelectedIndex);
                        TabClosed(this, tabClosedEA);
                        if (tabClosedEA.CloseReason)
                        {
                            this.TabPages.RemoveAt(this.SelectedIndex);
                        }
                    }
                }
                // Ако има меню
                if (_ItemMenu != null)
                {
                    // зона на бутона
                    buttonArea = CreateButtonRectangle(tabTextArea, 2);
                    if (buttonArea.Contains(e.X, e.Y))
                    {
                        // отваря менюто
                        Point pointMenu = new Point((int)buttonArea.X, (int)(buttonArea.Y + buttonArea.Height));
                        _ItemMenu.Show(this, pointMenu);
                    }
                }
            }
        }

        #region DrawItem

        /// <summary>
        /// Drawing Item
        /// </summary>
        private void DrawItemDark(Graphics graphics, LinearGradientBrush brush, ColorBlend colorBlend, RectangleF tabTextArea)
        {
            RectangleF rectanglePath = new RectangleF(tabTextArea.X, tabTextArea.Y, tabTextArea.Width, tabTextArea.Height);
            using (GraphicsPath _Path = new GraphicsPath())
            {
                _Path.AddRectangle(rectanglePath);

                colorBlend.Colors = new Color[]
                {
                    SystemColors.ControlLightLight, 
                    Color.FromArgb(255, SystemColors.ControlLight),
                    SystemColors.ControlDark,
                    SystemColors.ControlLightLight
                };
                colorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                brush.InterpolationColors = colorBlend;

                graphics.FillPath(brush, _Path);

                using (Pen pen = new Pen(SystemColors.ActiveBorder))
                {
                    graphics.DrawPath(pen, _Path);
                }
                _Path.Dispose();
            }
        }

        /// <summary>
        /// Drawing Item
        /// </summary>
        private void DrawItemLight(Graphics graphics, LinearGradientBrush brush, ColorBlend colorBlend, RectangleF tabTextArea)
        {
            RectangleF rectanglePath = new RectangleF(tabTextArea.X, tabTextArea.Y, tabTextArea.Width, tabTextArea.Height);
            using (GraphicsPath _Path = new GraphicsPath())
            {
                _Path.AddRectangle(rectanglePath);
                
                colorBlend.Colors = new Color[]
                {
                    SystemColors.ControlLightLight, 
                    Color.FromArgb(255, SystemColors.Control),
                    SystemColors.ControlLight,
                    SystemColors.Control
                };
                colorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                brush.InterpolationColors = colorBlend;
                graphics.FillPath(brush, _Path);
                using (Pen pen = new Pen(SystemColors.ActiveBorder))
                {
                    graphics.DrawPath(pen, _Path);
                }
                _Path.Dispose();
            }
        }

        #endregion DrawItem

        #region DrawCloseButton

        /// <summary>
        /// // Drawing Close Button
        /// </summary>
        private void DrawCloseButton(Graphics graphics, LinearGradientBrush brush, RectangleF buttonRectangle)
        {
            float borderWidth = 2;
            // Първа рамка
            graphics.FillRectangle(brush, buttonRectangle.X, buttonRectangle.Y, buttonRectangle.Width, buttonRectangle.Height);
            // Втора рамка
            graphics.DrawRectangle(Pens.White, buttonRectangle.X + borderWidth, buttonRectangle.Y + borderWidth
                , buttonRectangle.Width - (borderWidth * 2), buttonRectangle.Height - (borderWidth * 2));
            // Хикса
            using (Pen pen = new Pen(Color.White, 2))
            {
                float imgWidth = buttonRectangle.Width - (borderWidth * 6);
                float imgHeight = buttonRectangle.Height - (borderWidth * 6);
                float imgX = buttonRectangle.X + (borderWidth * 3);
                float imgY = buttonRectangle.Y + (borderWidth * 3);

                graphics.DrawLine(pen, imgX, imgY - 1, imgX + imgWidth, imgY + imgHeight);
                graphics.DrawLine(pen, imgX, imgY + imgHeight, imgX + imgWidth, imgY - 1);
            }
        }

        /// <summary>
        /// Drawing Close Button: Inactive
        /// </summary>
        private void DrawCloseButton_Inactive(Graphics graphics, LinearGradientBrush brush, RectangleF tabTextArea, ColorBlend colorBlend)
        {
            colorBlend.Colors = new Color[]
            {
                SystemColors.ActiveBorder, 
                SystemColors.ActiveBorder,
                SystemColors.ActiveBorder,
                SystemColors.ActiveBorder
            };
            colorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
            brush.InterpolationColors = colorBlend;

            RectangleF buttonRectangle = CreateButtonRectangle(tabTextArea, 1);
            DrawCloseButton(graphics, brush, buttonRectangle);
        }

        /// <summary>
        /// Drawing Close Button: Active
        /// </summary>
        private void DrawCloseButton_Active(Graphics graphics, LinearGradientBrush brush, RectangleF tabTextArea, ColorBlend colorBlend)
        {
            colorBlend.Colors = new Color[]
            {
                Color.FromArgb(255,231,164,152), 
                Color.FromArgb(255,231,164,152),
                Color.FromArgb(255,197,98,79),
                Color.FromArgb(255,197,98,79)
            };
            colorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
            brush.InterpolationColors = colorBlend;

            RectangleF buttonRectangle = CreateButtonRectangle(tabTextArea, 1);
            DrawCloseButton(graphics, brush, buttonRectangle);
        }

        #endregion DrawCloseButton

        #region DrawMenuButton

        /// <summary>
        /// Drawing menu button
        /// </summary>
        private void DrawMenuButton(Graphics graphics, LinearGradientBrush brush, RectangleF buttonRectangle)
        {
            float borderWidth = 2;

            graphics.FillRectangle(brush, buttonRectangle.X, buttonRectangle.Y,
                buttonRectangle.Width, buttonRectangle.Height);
            using (Pen pen = new Pen(Color.White))
            {
                graphics.DrawRectangle(pen, buttonRectangle.X + borderWidth, buttonRectangle.Y + borderWidth,
                    buttonRectangle.Width - (borderWidth * 2), buttonRectangle.Height - (borderWidth * 2));
            }
            using (Pen pen = new Pen(Color.White, 2))
            {
                float imgWidth = buttonRectangle.Width - (borderWidth * 6);
                float imgHeight = buttonRectangle.Height - (borderWidth * 6);
                float imgX = buttonRectangle.X + (borderWidth * 3);
                float imgY = buttonRectangle.Y + (borderWidth * 3);

                graphics.DrawLine(pen, imgX, imgY, imgX + (imgWidth / 2), imgY + imgHeight);
                graphics.DrawLine(pen, imgX + (imgWidth / 2), imgY + imgHeight, imgX + imgWidth, imgY);
            }
        }

        /// <summary>
        /// Drawing menu button
        /// </summary>
        private void DrawMenuButton_Inactive(Graphics graphics, LinearGradientBrush brush, RectangleF tabTextArea, ColorBlend colorBlend)
        {
            colorBlend.Colors = new Color[]
            {
                SystemColors.ActiveBorder, 
                SystemColors.ActiveBorder,
                SystemColors.ActiveBorder,
                SystemColors.ActiveBorder
            };
            colorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
            // assign the color blend to the pathgradientbrush
            brush.InterpolationColors = colorBlend;

            RectangleF buttonRectangle = CreateButtonRectangle(tabTextArea, 2);
            DrawMenuButton(graphics, brush, buttonRectangle);
        }

        /// <summary>
        /// Drawing menu button
        /// </summary>
        private void DrawMenuButton_Active(Graphics graphics, LinearGradientBrush brush, RectangleF tabTextArea, ColorBlend colorBlend)
        {
            colorBlend.Colors = new Color[]
            {
                Color.FromArgb(255,170,213,243), 
                Color.FromArgb(255,170,213,243),
                Color.FromArgb(255,44,137,191),
                Color.FromArgb(255,44,137,191)
            };
            colorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
            brush.InterpolationColors = colorBlend;

            RectangleF buttonRectangle = CreateButtonRectangle(tabTextArea, 2);
            DrawMenuButton(graphics, brush, buttonRectangle);
        }

        #endregion DrawMenuButton

        private void DrawText(Graphics graphics, TabPage tabPage, RectangleF tabArea)
        {
            // Форматиране на текст
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.FormatFlags = StringFormatFlags.NoWrap;
            // Цвят
            SolidBrush brush = new SolidBrush(tabPage.ForeColor);
            // Зона
            float buttonsWidth = (tabArea.Height - 3) * ((this._ItemMenu == null) ? 1 : 2);
            RectangleF textRectangle = new RectangleF(tabArea.X + 3, tabArea.Y
                , ((tabArea.Width > buttonsWidth) ? (tabArea.Width - buttonsWidth) : 0)
                , tabArea.Height);

            graphics.DrawString(tabPage.Text, this.Font, brush, textRectangle, stringFormat);
        }

        /// <summary>
        /// Зона на бутона
        /// </summary>
        private RectangleF CreateButtonRectangle(RectangleF tabArea, int buttonNo)
        {
            float buttonMargin = 3;
            float buttonWidth = tabArea.Height - 3;
            float buttonHeight = tabArea.Height - 5;
            float buttonX = (tabArea.X + tabArea.Width) - ((buttonWidth * buttonNo) + buttonMargin);
            float buttonY = 4;    

            return new RectangleF(buttonX, buttonY, buttonWidth, buttonHeight);
        }
    }

    public class TabClosedEventArgs : EventArgs
    {
        public TabClosedEventArgs(int tabIndex)
        {
            this._TabIndex = tabIndex;
        }

        private int _TabIndex = -1;
        public int TabIndex
        {
            get
            { return this._TabIndex; }
        }

        private bool _CloseReason = true;
        public bool CloseReason
        {
            get
            { return this._CloseReason; }
            set
            { this._CloseReason = value; }
        }
    }
}