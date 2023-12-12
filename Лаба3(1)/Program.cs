using System;

namespace Лаба3_1_
{
    class Program
    {
        static string Path1 = @"C:\Users\hp\Pictures\Screenshots\Снимок экрана 2023-11-18 002207.png";
        static string Path2 = @"C:\Users\hp\Pictures\Screenshots\Снимок экрана 2023-11-14 161413.png";
        static string Output = @"C:\Users\hp\Desktop\Важнота\2 курс\3 семестр\Прога\Лаба3(1)\bin\Debug\ReStaham.png";
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Обрезать");
                Console.WriteLine("2 - Повернуть");
                Console.WriteLine("3 - Сделать коллаж");
                Console.WriteLine("4 - Добавить надпись");
                Console.WriteLine("5 - Менять отдельный пиксели");
                Console.WriteLine("6 - Использовать фильтры");
                Console.WriteLine("0 - Выход");
                Console.Write("Ваш выбор: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Crop.Croping();
                        break;
                    case 2:
                        Rotate.Rotating();
                        break;
                    case 3:
                        Collage.Collaging(Path1, Path2);
                        break;
                    case 4:
                        Console.Write("Введите надпись: ");
                        string content = Console.ReadLine();   
                        Console.Write("Выберите место, куда хотите её поместить(Сверху, Снизу, Справа, Слева, Посередине): ");
                        string tmp = Console.ReadLine();
                        Nadpis.AddText(Path1, content, tmp);
                        break;
                    case 5:
                        Change.Pixel(Path1);
                        break;
                    case 6:
                        Console.WriteLine("Выберите фильтр");
                        Console.WriteLine("1 - Увеличить яркость");
                        Console.WriteLine("2 - Негатив");
                        Console.WriteLine("3 - Ч/б фильр");
                        Console.Write("Ваш выбор: ");
                        int choice1 = Convert.ToInt32(Console.ReadLine());
                        switch (choice1) 
                        {
                            case 1:
                                Filters.ApplyBrightnessFilter(Path1, Output, 2f);
                                Console.WriteLine("Фильтр успешно применен!");
                                break;
                            case 2:
                                Filters.ApplyNegativeFilter(Path1, Output);
                                Console.WriteLine("Фильтр успешно применен!");
                                break;
                            case 3:
                                Filters.ApplyGrayscaleFilter(Path1, Output);
                                Console.WriteLine("Фильтр успешно применен!");
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