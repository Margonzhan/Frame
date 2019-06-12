using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using HalconDotNet;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
namespace Vision
{
    class ImageOperate
    {
        [DllImport("Kernel32.dll")]
        internal static extern void CopyMemory(Int64 dest, Int64 source, Int64 size);
        private void HObject2Bpp8(HObject image, out Bitmap res)
        {
            HTuple hpoint, type, width, height;
            const int Alpha = 255;
            Int64[] ptr = new Int64[2];
            HOperatorSet.GetImagePointer1(image, out hpoint, out type, out width, out height);
            res = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            ColorPalette pal = res.Palette;
            for (int i = 0; i <= 255; i++)
            {
                pal.Entries[i] = Color.FromArgb(Alpha, i, i, i);
            }

           

            res.Palette = pal;
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData bmpData = res.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            int PixelSize = Bitmap.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            ptr[0] = bmpData.Scan0.ToInt64();
            ptr[1] = hpoint.L;
            if (width % 4 == 0)
                CopyMemory(ptr[0], ptr[1], width * height * PixelSize);
            else
            {
                for (int i = 0; i < height - 1; i++)
                {
                    ptr[1] += width;

                    CopyMemory(ptr[0], ptr[1], width * PixelSize);
                    ptr[0] += bmpData.Stride;
                }
            }
            res.UnlockBits(bmpData);
        }  
    }
}
