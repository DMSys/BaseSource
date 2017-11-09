using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace DMSys.Controls
{
    public class DLabel : Label
    {
        #region Properties

        private bool _AutoSizeText = false;
        [Category("Layout")]
        [DefaultValue(false)]
        [Description("Автоматично определяне на размера на текста")]
        public bool AutoSizeText
        {
            get
            { return _AutoSizeText; }
            set
            { _AutoSizeText = value; }
        }

        #endregion Properties

        public DLabel()
        {
            /*this.Paint += new PaintEventHandler(this.OnPaint);*/

        //    this.Resize += new System.EventHandler(this.OnResize);
        }
        /*
        private void OnResize(object sender, EventArgs e)
        {
            //  float emSize = this.Font.Size*(ClientRectangle.Size.Height / this.Font.Height);
            //
            float emSize = this.Font.Size * ((float)this.Height) / ((float)this.Font.Height);
            emSize = (emSize < 1) ? 1 : emSize;

            //   this.Text = this.Height.ToString() +", "+this.Font.Height+", "+emSize.ToString();
            //
            this.Font = new Font(this.Font.FontFamily, emSize);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
          //  base.OnPaint(e);
            //
            if (_AutoSizeText)
            {
                //
                float emSize = this.Font.Size * ((float)this.Height) / ((float)this.Font.Height);
                emSize = (emSize < 1) ? 1 : emSize;
                //
                this.Font = new Font(this.Font.FontFamily, emSize);
            }
        }*/

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Ако е включено автоматично определяне на размера на текста
            if (_AutoSizeText && (this.Text.Length > 0))
            {
                SizeF size = new SizeF();
                using (Graphics g = this.CreateGraphics())
                {
                    size = g.MeasureString(this.Text, this.Font);
                }
                // Размер на височината
                float emSizeHeight = this.Font.Size * ((float)this.Height) / size.Height;
                emSizeHeight = (emSizeHeight < 1) ? 1 : emSizeHeight;
                // Размер на ширината
                float emSizeWidth = this.Font.SizeInPoints * (float)(this.Width - 20) / size.Width;
                emSizeWidth = (emSizeWidth < 1) ? 1 : emSizeWidth;

                // Създава фонта с определения размер
                float emSize = (emSizeWidth < emSizeHeight) ? emSizeWidth : emSizeHeight;
                this.Font = new Font(this.Font.FontFamily, emSize);               
            }
        } 
    }
}
