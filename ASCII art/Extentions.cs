using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII_art
{
    public static class Extentions // расширения для основного класса
    {
        public static void ToGrayScale(this Bitmap bitmap) // конвертируем цвет пикселя в градацию серого
        {
            for (int y = 0; y < bitmap.Height; y++) // пройдемся по всем пикселям
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    int avg = (pixel.R + pixel.G + pixel.B) / 3; // серый это средняя арифм. от РГБ
                    bitmap.SetPixel(x, y, Color.FromArgb(pixel.A, avg, avg, avg)); // переприсваиваем цвет
                                                                                   // A (альфа канал) - прозрачность
                }
            }
        }






    }
}
