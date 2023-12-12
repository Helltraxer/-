using System;
using System.Drawing.Imaging;
using System.Drawing;


namespace Лаба3_1_
{
    [Serializable]
    public class Filters
    {

        // Фильтр для изменения яркости изображения
        public static void ApplyBrightnessFilter(string imagePath, string outputImagePath, float brightnessFactor)
        {
            try
            {
                using (Bitmap originalImage = new Bitmap(imagePath))
                {
                    using (Graphics g = Graphics.FromImage(originalImage))
                    {
                        // Используем матрицу цветов для изменения яркости
                        ColorMatrix brightnessMatrix = new ColorMatrix(new float[][]
                        {
                        new float[] {brightnessFactor, 0, 0, 0, 0},
                        new float[] {0, brightnessFactor, 0, 0, 0},
                        new float[] {0, 0, brightnessFactor, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                        });

                        ImageAttributes attributes = new ImageAttributes();
                        attributes.SetColorMatrix(brightnessMatrix);

                        // Рисуем изображение с применением фильтра
                        g.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                            0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
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

        public static void ApplyBrightnessFilter1(string imagePath, string outputImagePath, float brightnessFactor)
        {
            try
            {
                using (Bitmap originalImage = new Bitmap(imagePath))
                {
                    using (Graphics g = Graphics.FromImage(originalImage))
                    {
                        // Создаем матрицу цветов для изменения яркости
                        ColorMatrix brightnessMatrix = new ColorMatrix(new float[][]
                        {
                    new float[] {brightnessFactor, 0, 0, 0, 0},
                    new float[] {0, brightnessFactor, 0, 0, 0},
                    new float[] {0, 0, brightnessFactor, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                        });

                        ImageAttributes attributes = new ImageAttributes();
                        attributes.SetColorMatrix(brightnessMatrix);

                        // Создаем новый Bitmap для применения фильтра
                        Bitmap filteredImage = new Bitmap(originalImage.Width, originalImage.Height);

                        using (Graphics gFiltered = Graphics.FromImage(filteredImage))
                        {
                            gFiltered.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                                0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
                        }

                        // Сохраняем результат
                        filteredImage.Save(outputImagePath, ImageFormat.Jpeg);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        // Фильтр для создания негатива изображения
        public static void ApplyNegativeFilter(string imagePath, string outputImagePath)
        {
            try
            {
                using (Bitmap originalImage = new Bitmap(imagePath))
                {
                    using (Graphics g = Graphics.FromImage(originalImage))
                    {
                        // Инвертируем цвета
                        ImageAttributes attributes = new ImageAttributes();
                        attributes.SetColorMatrix(new ColorMatrix(new float[][]
                        {
                        new float[] {-1, 0, 0, 0, 0},
                        new float[] {0, -1, 0, 0, 0},
                        new float[] {0, 0, -1, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {1, 1, 1, 0, 1}
                        }));

                        // Рисуем изображение с применением фильтра
                        g.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                            0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
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

        // Фильтр для преобразования изображения в черно-белый цвет
        public static void ApplyGrayscaleFilter(string imagePath, string outputImagePath)
        {
            try
            {
                using (Bitmap originalImage = new Bitmap(imagePath))
                {
                    using (Graphics g = Graphics.FromImage(originalImage))
                    {
                        // Используем матрицу цветов для преобразования в черно-белый цвет
                        ColorMatrix grayscaleMatrix = new ColorMatrix(new float[][]
                        {
                        new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                        new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                        new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                        });

                        ImageAttributes attributes = new ImageAttributes();
                        attributes.SetColorMatrix(grayscaleMatrix);

                        // Рисуем изображение с применением фильтра
                        g.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                            0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
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
