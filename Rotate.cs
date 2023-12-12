using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Лаба3_1_
{
    [Serializable]
    public class Rotate
    {
        public static int Rotating(string inputImagePath, string outputImagePath)
        {
            if (RotateImage(inputImagePath, outputImagePath, RotateFlipType.Rotate90FlipNone))
            {
                Console.WriteLine("Изображение успешно повёрнуто!");
                return 1;
            }
            else
            {
                Console.WriteLine("Ошибка при повороте изображения.");
                return 0;
            }
        }

        public static bool RotateImage(string inputImagePath, string outputImagePath, RotateFlipType rotateFlipType)
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

                return true; // Возвращаем true при успешном повороте изображения
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                return false; // Возвращаем false при возникновении ошибки
            }
        }
    }
}
