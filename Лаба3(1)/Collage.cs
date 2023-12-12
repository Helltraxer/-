using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace Лаба3_1_
{
    public class Collage
    {
        public static void Collaging(string Path1, string Path2)
        {
            // Пример использования функции CreateCollage
            string outputImagePath = @"C:\Users\hp\Desktop\Важнота\2 курс\3 семестр\Прога\Лаба3(1)\bin\Debug\ReStaham.png";

            CreateCollage(Path1, Path2, outputImagePath);

            Console.WriteLine("Коллаж успешно создан!");
        }

        public static void CreateCollage(string imagePath1, string imagePath2, string outputImagePath)
        {
            try
            {
                // Загружаем изображения
                using (Bitmap image1 = new Bitmap(imagePath1))
                using (Bitmap image2 = new Bitmap(imagePath2))
                {
                    // Создаем новое изображение (коллаж) с размерами, равными максимальным из двух изображений
                    int collageWidth = Math.Max(image1.Width, image2.Width);
                    int collageHeight = Math.Max(image1.Height, image2.Height);

                    using (Bitmap collage = new Bitmap(collageWidth * 2, collageHeight))
                    {
                        using (Graphics g = Graphics.FromImage(collage))
                        {
                            // Рисуем первое изображение
                            g.DrawImage(image1, new Rectangle(0, 0, image1.Width, image1.Height));

                            // Рисуем второе изображение, масштабируя его к размерам коллажа
                            g.DrawImage(image2, new Rectangle(image1.Width, 0, collageWidth, collageHeight));
                        }

                        // Сохраняем результат
                        collage.Save(outputImagePath, ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
