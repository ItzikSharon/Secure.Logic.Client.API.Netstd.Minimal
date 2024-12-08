using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace securelogic.prosigner.client.api.common
{
    internal class ImageUtils
    {
        public static void ConvertRGBSamples(byte[] data, int width, int height)
        {
            int num = data.Length / height;
            int num2 = 0;
            while (num2 < height)
            {
                int num3 = num * num2;
                int num4 = num3 + (width * 3);
                int index = num3;
                while (true)
                {
                    if (index >= num4)
                    {
                        num2++;
                        break;
                    }
                    byte num6 = data[index + 2];
                    data[index + 2] = data[index];
                    data[index] = num6;
                    index += 3;
                }
            }
        }
        //public static byte[] GetImageRasterBytes(Bitmap bmp, PixelFormat format)
        //{
        //    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        //    byte[] destination = null;
        //    try
        //    {
        //        BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, format);
        //        destination = new byte[bitmapdata.Stride * bitmapdata.Height];
        //        Marshal.Copy(bitmapdata.Scan0, destination, 0, destination.Length);
        //        bmp.UnlockBits(bitmapdata);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    return destination;
        //}
        //public static Bitmap ResizeImage(Image image, int width, int height)
        //{
        //    Rectangle destRect = new Rectangle(0, 0, width, height);
        //    Bitmap bitmap = new Bitmap(width, height);
        //    bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        graphics.CompositingMode = CompositingMode.SourceCopy;
        //        graphics.CompositingQuality = CompositingQuality.HighQuality;
        //        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //        using (ImageAttributes attributes = new ImageAttributes())
        //        {
        //            attributes.SetWrapMode(WrapMode.TileFlipXY);
        //            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
        //        }
        //    }
        //    return bitmap;
        //}
    }
}
