using System;

namespace Лаба3_1_
{
    [Serializable]
    class Program
    {
        [NonSerialized]
        static string Path1 = @"C:\Users\hp\Desktop\Важнота\2 курс\3 семестр\Прога\Лаба3(1)\1.png"; // загружаем картинки
        static string Path2 = @"C:\Users\hp\Desktop\Важнота\2 курс\3 семестр\Прога\Лаба3(1)\2.png";
        static string Output = @"C:\Users\hp\Desktop\Важнота\2 курс\3 семестр\Прога\Лаба3(1)\Re.jpeg";
        static void Main()
        {
            while (true) // меню
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Обрезать");
                Console.WriteLine("2 - Повернуть");
                Console.WriteLine("3 - Сделать коллаж");
                Console.WriteLine("4 - Добавить надпись");
                Console.WriteLine("5 - Менять отдельные пиксели");
                Console.WriteLine("6 - Использовать фильтры");
                Console.WriteLine("0 - Выход");
                Console.Write("Ваш выбор: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) // в зависимости от цифры выбирается свой случай
                {
                    case 1:
                        Crop.Croping(Path1,Output);
                        Console.WriteLine($"Файл сохранен по пути: {Output}");
                        break;
                    case 2:
                        Rotate.Rotating(Path1,Output);
                        Console.WriteLine($"Файл сохранен по пути: {Output}");
                        break;
                    case 3:
                        Collage.Collaging(Path1, Path2, Output);
                        Console.WriteLine($"Файл сохранен по пути: {Output}");
                        break;
                    case 4:
                        Console.Write("Введите надпись: ");
                        string content = Console.ReadLine();   
                        Console.Write("Выберите место, куда хотите её поместить(Сверху, Снизу, Справа, Слева, Посередине): ");
                        string tmp = Console.ReadLine();
                        Nadpis.AddText(Path1, content, tmp, Output);
                        Console.WriteLine($"Файл сохранен по пути: {Output}");
                        break;
                    case 5:
                        Change.Pixel(Path1, Output);
                        Console.WriteLine($"Файл сохранен по пути: {Output}");
                        break;
                    case 6:
                        Console.WriteLine("Выберите фильтр");
                        Console.WriteLine("1 - Увеличить яркость");
                        Console.WriteLine("2 - Уменьшить яркость");
                        Console.WriteLine("3 - Негатив");
                        Console.WriteLine("4 - Ч/б фильр");
                        Console.Write("Ваш выбор: ");
                        int choice1 = Convert.ToInt32(Console.ReadLine());
                        switch (choice1) 
                        {
                            case 1:
                                Filters.ApplyBrightnessFilter(Path1, Output, 2f);
                                Console.WriteLine("Фильтр успешно применен!");
                                Console.WriteLine($"Файл сохранен по пути: {Output}");
                                break;
                            case 2:
                                Filters.ApplyBrightnessFilter1(Path1, Output, 0.5f);
                                Console.WriteLine("Фильтр успешно применен!");
                                Console.WriteLine($"Файл сохранен по пути: {Output}");
                                break;
                            case 3:
                                Filters.ApplyNegativeFilter(Path1, Output);
                                Console.WriteLine("Фильтр успешно применен!");
                                Console.WriteLine($"Файл сохранен по пути: {Output}");
                                break;
                            case 4:
                                Filters.ApplyGrayscaleFilter(Path1, Output);
                                Console.WriteLine("Фильтр успешно применен!");
                                Console.WriteLine($"Файл сохранен по пути: {Output}");
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор");    
                                break;
                        }

                        break;
                    case 0:
                        return;

                    default:
                        Console.WriteLine("Некорректный выбор");
                        break;
                }
            }
        }
    }
}