using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace DMSys.Utility
{
    public static class ConvertImage
    {
        public static byte[] ToByteArray(System.Drawing.Image image)
        {
            if (image == null)
            { return null; }
            using (MemoryStream ms = new MemoryStream())
            {
                if (ImageFormat.Jpeg.Equals(image.RawFormat)
                    || ImageFormat.Bmp.Equals(image.RawFormat)
                    || ImageFormat.Emf.Equals(image.RawFormat)
                    || ImageFormat.Exif.Equals(image.RawFormat)
                    || ImageFormat.Gif.Equals(image.RawFormat)
                    || ImageFormat.Icon.Equals(image.RawFormat)
                    || ImageFormat.MemoryBmp.Equals(image.RawFormat)
                    || ImageFormat.Png.Equals(image.RawFormat)
                    || ImageFormat.Tiff.Equals(image.RawFormat)
                    || ImageFormat.Wmf.Equals(image.RawFormat)
                    )
                { 
                    image.Save(ms, image.RawFormat);
                }
                else
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                return ms.ToArray();
            }
        }

        public static byte[] ToByteArray(string fileName)
        {
            if (fileName.Trim() == "")
            { return null; }
            byte[] pgByteA;
            using (FileStream pgFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader pgReader = new BinaryReader(new BufferedStream(pgFileStream)))
                {
                    pgByteA = pgReader.ReadBytes(Convert.ToInt32(pgFileStream.Length));
                }
            }
            return pgByteA;
        }

        public static Image ToImage(byte[] imageBytes)
        {
            if (imageBytes == null)
            { return null; }
            Image img = null;
            using (Stream imageStream = new MemoryStream(imageBytes))
            {
                img = Image.FromStream(imageStream);
            }
            return img;
        }
    }
}
