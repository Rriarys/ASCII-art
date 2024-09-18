using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // подключил отдельно
using System.Drawing;
using System.Drawing.Text; // -//-

namespace ASCII_art
{
    internal class Program
    {
        private const double WIDTH_OFFSET = 1.5; // компенсация размера
        private const int MAX_WIDTH = 250;

        [STAThread] // Single Thread Apartment, главный поток должен работать в однопоточном режиме

        static void Main(string[] args)
        {
            var openFileDialog = new OpenFileDialog // диалоговое окно открытия файла
            {
                Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG" // филтр типа файлов
            };

            Console.WriteLine("Press enter to start...");

            while (true)
            {
                Console.ReadLine(); // стопим, чтобы не перезапускать саму прогу каждый раз

                if (openFileDialog.ShowDialog() != DialogResult.OK) // если файл не открылся, все зхново
                    continue;

                Console.Clear(); // очищаем консоль если до этого была картинка

                var bitmap = new Bitmap(openFileDialog.FileName); // помещаем в мпеременную даныне полученные из файла

                bitmap = ResizeBitmap(bitmap); // сразу подгоняем размер

                bitmap.ToGrayScale(); // конвертируем в ч/б

                var converter = new BitmapToASCIIConverter(bitmap);
                var rows = converter.Convert(); // получаем строки с символами

                foreach ( var row in rows )
                    Console.WriteLine(row);

                Console.SetCursorPosition(0,0); // возвращаемся в начало чтобы видеть всю картинку
                //конец while(true) 
            }

            

            //конец Main()
        }

        private static Bitmap ResizeBitmap(Bitmap bitmap) // чтобы изменять размер картинки, который получаем на вход
        {
            var maxWidth = MAX_WIDTH;
            var newHeight = bitmap.Height / WIDTH_OFFSET * maxWidth / bitmap.Width; // выравниваем по размеру

            if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(maxWidth, (int)newHeight));

            return bitmap;
        }


        // конец класса Program
    }
}
