using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII_art
{
    public class BitmapToASCIIConverter
    {
        private readonly char[] _asciiTable = { '.', ',', ':', '+', '*', '?', '%', '$', '#', '@' }; // заменители пикселей, от тусклого к яркому
        
        private readonly Bitmap _bitmap; // ссылка, в качестве полей

        public BitmapToASCIIConverter(Bitmap bitmap) // конструктор
        {
            _bitmap = bitmap;
        }

        public char[][] Convert() // отрисовываем целую строку благодаря 2 мерному массиву
        {
            var result = new char[_bitmap.Height][];

            for (int y = 0; y < _bitmap.Height; y++) // проходим по высоте
            {
                result[y] = new char[_bitmap.Width]; // одна строка

                for (int x = 0; x < _bitmap.Width; x++)
                {
                    int mapIndex = (int)Map(_bitmap.GetPixel(x,y).R, 0, 255, 0, _asciiTable.Length - 1); // получим индекс соответсвия из РГБ в символы
                    result[y][x] = _asciiTable[mapIndex];
                }
            }

            return result;
        }

        private float Map(float valueToMap, float start1, float stop1, float start2, float stop2) // 1 - диапазон bitmap | 2 - диапазон массива символов
        {                                                                                         // color в bitmap -> 0..255
            return ((valueToMap - start1) / (stop1 - start1)) * (stop2 - start2) + start2; // отмапим значение из одного диапазона в другой диапазон
        }


    }
}
