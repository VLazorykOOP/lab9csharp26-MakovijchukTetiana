using System;
using System.Collections;
using System.IO;
using System.Text;

namespace lab9
{
    // Частина 1: Обробка рядка з Backspace за допомогою ArrayList
    public class task3Part1
    {
        public static void Run()
        {
            // Вхідний рядок, де '#' діє як клавіша Backspace
            string input = "abc#d##c"; 
            
            // Створюємо динамічний масив для зберігання символів
            ArrayList charList = new ArrayList(); 

            Console.WriteLine($"Вхідний рядок (ArrayList): {input}");

            // Перебираємо кожен символ у рядку
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                // Якщо символ не '#', просто додаємо його в кінець списку
                if (currentChar != '#')
                {
                    charList.Add(currentChar);
                }
                else
                {
                    // Якщо символ '#', перевіряємо, чи масив не порожній
                    if (charList.Count != 0) 
                    {
                        // Видаляємо останній елемент за його індексом (Count - 1)
                        charList.RemoveAt(charList.Count - 1); 
                    }
                }
            }

            // Змінна для формування кінцевого рядка
            string resultString = "";
            
            // Проходимо по всіх елементах, що залишилися в ArrayList
            foreach (char c in charList)
            {
                // Поступово склеюємо символи в один рядок
                resultString += c;
            }

            Console.WriteLine($"Результат після обробки Backspace: {resultString}");
        }
    }

    // Частина 2: Обробка файлу студентів за допомогою ArrayList
    public class task3Part2
    {
        public static void Run()
        {
            // Створюємо динамічний масив для зберігання студентів з оцінками нижче 4
            ArrayList otherStudents = new ArrayList();
            
            // Використовуємо структуру Student
            task2.Student student; 
            string line;
            string filePath = "students.txt";

            // Перевіряємо наявність файлу перед початком роботи
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"[Помилка] Файл '{filePath}' не знайдено.");
                return;
            }

            try
            {
               
                StreamReader fileIn = new StreamReader(filePath, Encoding.UTF8);

                Console.WriteLine("СТУДЕНТИ, ЩО ВЧАТЬСЯ НА 4 ТА 5 (ArrayList):");
                Console.WriteLine(new string('-', 50));

                // Читаємо файл до самого кінця
                while ((line = fileIn.ReadLine()) != null) 
                {
                    // Розбиваємо рядок на слова, ігноруючи зайві пробіли
                    string[] temp = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    // Перевіряємо, чи є всі 7 потрібних елементів у рядку
                    if (temp.Length >= 7)
                    {
                        // Заповнюємо дані структури
                        student.LastName = temp[0];
                        student.FirstName = temp[1];
                        student.Patronymic = temp[2];
                        student.Group = temp[3];
                        student.Grade1 = int.Parse(temp[4]);
                        student.Grade2 = int.Parse(temp[5]);
                        student.Grade3 = int.Parse(temp[6]);

                        // Перевіряємо, чи всі оцінки >= 4
                        bool isGoodStudent = (student.Grade1 >= 4) && (student.Grade2 >= 4) && (student.Grade3 >= 4);

                        if (isGoodStudent)
                        {
                            // Відмінників та хорошистів відразу виводимо на екран
                            Console.WriteLine($"{student.LastName} {student.FirstName} \tГр: {student.Group} \tОцінки: {student.Grade1}, {student.Grade2}, {student.Grade3}");
                        }
                        else
                        {
                            // Інших додаємо в кінець динамічного масиву
                            otherStudents.Add(student); 
                        }
                    }
                }
                
                fileIn.Close();

                Console.WriteLine("\nІНШІ СТУДЕНТИ:");
                Console.WriteLine(new string('-', 50));
                
                // Перебираємо елементи масиву. Оскільки ArrayList зберігає об'єкти як тип Object, 
                foreach (task2.Student s in otherStudents) 
                {
                    Console.WriteLine($"{s.LastName} {s.FirstName} \tГр: {s.Group} \tОцінки: {s.Grade1}, {s.Grade2}, {s.Grade3}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}