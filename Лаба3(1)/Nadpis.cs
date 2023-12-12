using System;
using System.Drawing.Imaging;
using System.Drawing;


namespace Лаба3_1_
{
    public class Nadpis
    {
        public static void AddText(string Path1, string content, string tmp)
        {
            string outputImagePath = @"C:\Users\hp\Desktop\Важнота\2 курс\3 семестр\Прога\Лаба3(1)\bin\Debug\ReStaham.png";

            AddTextToImage(Path1, outputImagePath, content, tmp);

            Console.WriteLine("Надпись успешно добавлена!");
        }

        public static void AddTextToImage(string imagePath, string outputImagePath, string text, string position)
        {
            try
            {
                // Загружаем изображение
                using (Bitmap originalImage = new Bitmap(imagePath))
                {
                    using (Graphics g = Graphics.FromImage(originalImage))
                    {
                        // Шрифт и цвет для надписи
                        Font font = new Font("Arial", 32);
                        SolidBrush brush = new SolidBrush(Color.White); // Используйте цвет, который вы хотите для текста

                        // Определение позиции для надписи
                        int x = 0, y = 0;

                        switch (position.ToLower())
                        {
                            case "cверху":
                                x = (originalImage.Width - (int)g.MeasureString(text, font).Width) / 2;
                                y = 10; // Расстояние от верхнего края
                                break;
                            case "снизу":
                                x = (originalImage.Width - (int)g.MeasureString(text, font).Width) / 2;
                                y = originalImage.Height - 30; // Расстояние от нижнего края
                                break;
                            case "слева":
                                x = 10; // Расстояние от левого края
                                y = (originalImage.Height - (int)g.MeasureString(text, font).Height) / 2;
                                break;
                            case "справа":
                                x = originalImage.Width - (int)g.MeasureString(text, font).Width - 10; // Расстояние от правого края
                                y = (originalImage.Height - (int)g.MeasureString(text, font).Height) / 2;
                                break;
                            case "посередине":
                                x = (originalImage.Width - (int)g.MeasureString(text, font).Width) / 2;
                                y = (originalImage.Height - (int)g.MeasureString(text, font).Height) / 2;
                                break;
                            default:
                                Console.WriteLine("Недопустимая позиция для надписи.");
                                return;
                        }

                        // Рисуем текст на изображении
                        g.DrawString(text, font, brush, x, y);
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
    }
}
