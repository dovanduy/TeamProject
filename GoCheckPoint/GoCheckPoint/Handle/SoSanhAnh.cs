using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoCheckPoint.Handle
{
    public class SoSanhAnh
    {
        private SoSanhAnh()
        {
        }
        public static SoSanhAnh getInstance { get { return NestedSelenium.instance; } }
        private class NestedSelenium
        {
            static NestedSelenium()
            {
            }
            internal static readonly SoSanhAnh instance = new SoSanhAnh();
        }

        #region xử lý
        private List<List<bool>> MangPixel;

        public double SoSanh(Bitmap Imgcp, Bitmap ImgAl)
        {
            double num5 = 0;
            //lấy ảnh checkpoit
            //Bitmap Imgcp = GetImage(ImgCp);
            int widthCp = Imgcp.Size.Width;
            int heightCp = Imgcp.Size.Height;

            //lấy ảnh từ album bạn bè cần so
            //Bitmap ImgAl = GetImage(ImgAlbum);
            //đưa ảnh cần so về đúng kích thước của ảnh checkpoit lệch size bỏ qua
            Dictionary<string, int> Resize = new Dictionary<string, int>();
            Resize = ResizeByWidth(ImgAl, widthCp);
            if (Resize["Height"] != heightCp)//ảnh ko cùng kích thước bỏ qua
            {
                return 0;
            }

            Bitmap bmp = new Bitmap(Resize["Width"], Resize["Height"]);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(ImgAl, 0, 0, widthCp, heightCp);
            graphic.Dispose();

            long num = 0L;
            long num2 = 0L;
            this.KhoiTaoMangPixel(Imgcp.Width, Imgcp.Height);
            for (int i = Imgcp.Width / 3; i < Imgcp.Width * 2 / 3 - 1; i++)
            {
                for (int j = 0; j < Imgcp.Height * 3 / 4 - 1; j++)
                {
                    Color pixel = Imgcp.GetPixel(i, j);
                    byte b = Convert.ToByte((int)((pixel.R + pixel.G + pixel.B) / 3));
                    Imgcp.SetPixel(i, j, Color.FromArgb((int)b, (int)b, (int)b));
                    int num3 = i - 5;
                    while (num3 <= i + 5 && num3 >= Imgcp.Width / 3 && num3 < Imgcp.Width * 2 / 3 - 1)
                    {
                        int num4 = j - 5;
                        while (num4 <= j + 5 && num4 >= 0 && num4 < bmp.Height * 3 / 4 - 1)
                        {
                            Color pixel2 = bmp.GetPixel(num3, num4);
                            byte b2 = Convert.ToByte((int)((pixel2.R + pixel2.G + pixel2.B) / 3));
                            if (b == b2 && !this.MangPixel[num3][num4])
                            {
                                num += 1L;
                                this.MangPixel[num3][num4] = true;
                            }
                            num4++;
                        }
                        num3++;
                    }
                    num2 += 1L;
                }
            }
            num5 = (double)(num * 100L / num2);
            return num5;
        }

        public Bitmap GetImage(string url)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            Bitmap bitmap = new Bitmap(responseStream);
            return bitmap;
        }

        private void KhoiTaoMangPixel(int width, int height)
        {
            this.MangPixel = new List<List<bool>>();
            for (int i = 0; i < width; i++)
            {
                this.MangPixel.Add(new List<bool>());
                for (int j = 0; j < height; j++)
                {
                    this.MangPixel[i].Add(false);
                }
            }
            return;
        }

        public Dictionary<string, int> ResizeByWidth(Bitmap img, int width)
        {
            Dictionary<string, int> r = new Dictionary<string, int>();
            int originalW = img.Width;
            int originalH = img.Height;

            int resizedW = width;
            int resizedH = (originalH * resizedW) / originalW;

            r["Width"] = resizedW;
            r["Height"] = resizedH;

            return r;
        }
        #endregion
    }
}
