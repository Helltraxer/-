using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Лаба3_1_
{
    public class Crop
    {
        public static void Croping()
        {
            string inputImagePath = @"C:\Users\hp\Pictures\Saved Pictures\стахам.png";
            using (Image originalImage = Image.FromFile(inputImagePath))
            {
                // Создание прямоугольника для обрезки (пример: левый верхний угол 50,50 и ширина/высота 200,200)
                Rectangle cropArea = new Rectangle(0, 0, 400, 800);

                // Создание нового изображения для обрезки
                using (Bitmap croppedImage = new Bitmap(cropArea.Width, cropArea.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(croppedImage))
                    {
                        // Обрезка изображения
                        graphics.DrawImage(originalImage, new Rectangle(0, 0, cropArea.Width, cropArea.Height), cropArea, GraphicsUnit.Pixel);

                        // Сохранение обработанного изображения
                        string outputImagePath = "ReStaham.png";
                        croppedImage.Save(outputImagePath, ImageFormat.Jpeg);

                        Console.WriteLine("Изображение успешно обработано и сохранено.");
                    }
                }
            }
        }
    }
}
