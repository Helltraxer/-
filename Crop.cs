using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Лаба3_1_
{
    [Serializable]
    public class Crop
    {
        public static int Croping(string inputImagePath, string outputImagePath)
        {
            
            using (Image originalImage = Image.FromFile(inputImagePath)) // используем наше изображение
            {
                try
                {
                   
                    int x = 600;
                    int y = 600;



                    // Создание прямоугольника для обрезки (пример: левый верхний угол 50,50 и ширина/высота 200,200)
                    Rectangle cropArea = new Rectangle(0, 0, x, y); // задаём координаты обрезки

                    // Создание нового изображения для обрезки
                    using (Bitmap croppedImage = new Bitmap(cropArea.Width, cropArea.Height)) // используем библиотеку для обрезки
                    {
                        using (Graphics graphics = Graphics.FromImage(croppedImage))
                        {
                            // Обрезка изображения
                            graphics.DrawImage(originalImage, new Rectangle(0, 0, cropArea.Width, cropArea.Height), cropArea, GraphicsUnit.Pixel);

                            // Сохранение обработанного изображения
                            croppedImage.Save(outputImagePath, ImageFormat.Jpeg);

                            Console.WriteLine("Изображение успешно обработано и сохранено.");
                        }
                    }
                }
                catch (Exception err) // ловим ошибку
                {
                    Console.WriteLine(err.Message);
                    return 0;
                }
            }
            return 1;
        }
    }
}
