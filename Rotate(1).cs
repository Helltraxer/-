using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Лаба3_1_
{
    public class Rotate
    {
        public static void Rotating() 
        {
            string inputImagePath = @"C:\Users\hp\Desktop\Важнота\2 курс\3 семестр\Прога\Лаба3(1)\bin\Debug\ReStaham.png";
            string outputImagePath = "ReStaham.png";

            RotateImage(inputImagePath, outputImagePath, RotateFlipType.Rotate90FlipNone);

            Console.WriteLine("Изображение успешно повёрнуто!");
        }

        public static void RotateImage(string inputImagePath, string outputImagePath, RotateFlipType rotateFlipType)
        {
            try
            {
                // Загружаем изображение
                using (Bitmap originalImage = new Bitmap(inputImagePath))
                {
                    // Поворачиваем изображение
                    originalImage.RotateFlip(rotateFlipType);

                    // Сохраняем результат
                    originalImage.Save(outputImagePath, ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}