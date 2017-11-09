using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DMSys.Controls
{
    public partial class DImageBox : UserControl
    {
        private string _ImgPath = "";
        public string ImgPath
        {
            get
            { return _ImgPath; }
            set
            { _ImgPath = value; }
        }

        /// <summary>
        /// Картинка на клапан - затворен
        /// </summary>
        private Image _ImgValue = null;

        public DImageBox()
        {
            InitializeComponent();
            //
            LoadImg();
        }

        /// <summary>
        /// Зарежда изображение
        /// </summary>
        public void LoadImg()
        {
            if (_ImgValue != null)
            {
                _ImgValue.Dispose();
                _ImgValue = null;
                GC.Collect();
            }
            try
            {
                if (File.Exists(_ImgPath))
                {
                    _ImgValue = Image.FromFile(_ImgPath);
                }
                this.Refresh();
            }
            catch { }
        }

        private void DImageBox_Paint(object sender, PaintEventArgs e)
        {
            if (_ImgValue != null)
            { e.Graphics.DrawImage(_ImgValue, 0, 0,this.Width,this.Height); }
        }
    }
}
