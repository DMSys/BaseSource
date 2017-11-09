using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DMSys.Controls
{
    public class ControlTools
    {
        private static float _FontSizeW = 6.060606F;
        private static float _FontSizeH = 1.81818187F;

        /// <summary>
        /// Задава размер на Font
        /// </summary>
        public static void SetFontSize(Control ctr, float aSize)
        {
            if (aSize < 0)
            {
                ctr.Font = new Font(ctr.Font.FontFamily
                                   , 1
                                   , ctr.Font.Style);
            }
            else
            {
                ctr.Font = new Font(ctr.Font.FontFamily
                                   , aSize
                                   , ctr.Font.Style);
            }
        }

        public static void TextFill(Control ctr)
        {
            float fFontSizeW = ctr.Width / _FontSizeW;
            float fFontSizeH = ctr.Height / _FontSizeH;


            if (fFontSizeW < fFontSizeH)
            {
                SetFontSize(ctr, fFontSizeW);
            }
            else
            {
                SetFontSize(ctr, fFontSizeH);
            }

        }
    }
}
