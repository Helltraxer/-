using System;
using System.Drawing.Imaging;
using System.Drawing;


namespace Лаба3_1_
{
    public class Change
    {
        public static void Pixel(string Path1)
        {
            string outputImagePath = @"C:\Users\hp\Desktop\Важнота\2 курс\3 семестр\Прога\Лаба3(1)\bin\Debug\ReStaham.png";

            // Цвет, который вы хотите заменить (например, красный)
            Color targetColor = Color.White;

            // Цвет, на который вы хотите заменить целевой цвет (например, синий)
            Color replacementColor = Color.Red;

            ReplaceColor(Path1, outputImagePath, targetColor, replacementColor);

            Console.WriteLine("Замена цвета успешно выполнена!");
        }

        public static void ReplaceColor(string imagePath, string outputImagePath, Color targetColor, Color replacementColor)
        {
            try
            {
                // Загружаем изображение
                using (Bitmap originalImage = new Bitmap(imagePath))
                {
                    // Проходим по каждому пикселю изображения
                    for (int y = 0; y < originalImage.Height; y++)
                    {
                        for (int x = 0; x < originalImage.Width; x++)
                        {
                            // Получаем цвет текущего пикселя
                            Color currentColor = originalImage.GetPixel(x, y);

                            // Проверяем, насколько близки цвета, в пределах погрешности
                            if (ColorDistance(currentColor, targetColor) < 30) // Указывайте подходящую погрешность
                            {
                                // Заменяем цвет текущего пикселя
                                originalImage.SetPixel(x, y, replacementColor);
                            }
                        }
                    }

                    // Сохраняем результат
                    originalImage.Save(outputImagePath, ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        // Функция для вычисления расстояния между двумя цветами
        static int ColorDistance(Color c1, Color c2)
        {
            int rDiff = Math.Abs(c1.R - c2.R);
            int gDiff = Math.Abs(c1.G - c2.G);
            int bDiff = Math.Abs(c1.B - c2.B);

            return rDiff + gDiff + bDiff;
        }
    }
}
