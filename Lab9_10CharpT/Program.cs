using System;
using System.Text;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(" Лабораторна робота 9: Колекції ");
                Console.WriteLine("1. Завдання 1 (Stack: обробка символу Backspace '#')");
                Console.WriteLine("2. Завдання 2 (Queue: обробка файлу студентів)");
                Console.WriteLine("3. Завдання 3.1 (ArrayList: обробка символу '#')");
                Console.WriteLine("4. Завдання 3.2 (ArrayList: обробка файлу студентів)");
                Console.WriteLine("5. Завдання 4 (Hashtable: Музичний каталог)");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВиберіть номер завдання: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": task1.Run(); break;
                    case "2": task2.Run(); break;
                    case "3": task3Part1.Run(); break;
                    case "4": task3Part2.Run(); break;
                    case "5": task4.Run(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір. Спробуйте ще раз."); break;
                }
                
                
                Console.WriteLine("Натисніть Enter, щоб повернутися до меню...");
                Console.ReadLine();
            }
        }
    }
}