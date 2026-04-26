using System;
using System.Collections;
using System.IO;
using System.Text;

namespace lab9
{
   
    public class task3Part1
    {
        public static void Run()
        {
            string input = "abc#d##c"; 
            ArrayList charList = new ArrayList(); 

            Console.WriteLine($"Вхідний рядок (ArrayList): {input}");

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar != '#')
                {
                    charList.Add(currentChar);
                }
                else
                {
                    if (charList.Count != 0) 
                    {
                        charList.RemoveAt(charList.Count - 1); 
                    }
                }
            }

            string resultString = "";
            foreach (char c in charList)
            {
                resultString += c;
            }

            Console.WriteLine($"Результат після обробки Backspace: {resultString}");
        }
    }

    public class task3Part2
    {
        public static void Run()
        {
            ArrayList otherStudents = new ArrayList();
            task2.Student student; // Використовуємо структуру з Lab9Task2
            string line;
            string filePath = "students.txt";

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

                while ((line = fileIn.ReadLine()) != null) 
                {
                    string[] temp = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    if (temp.Length >= 7)
                    {
                        student.LastName = temp[0];
                        student.FirstName = temp[1];
                        student.Patronymic = temp[2];
                        student.Group = temp[3];
                        student.Grade1 = int.Parse(temp[4]);
                        student.Grade2 = int.Parse(temp[5]);
                        student.Grade3 = int.Parse(temp[6]);

                        bool isGoodStudent = (student.Grade1 >= 4) && (student.Grade2 >= 4) && (student.Grade3 >= 4);

                        if (isGoodStudent)
                        {
                            Console.WriteLine($"{student.LastName} {student.FirstName} \tГр: {student.Group} \tОцінки: {student.Grade1}, {student.Grade2}, {student.Grade3}");
                        }
                        else
                        {
                            otherStudents.Add(student); // Використовуємо Add замість Enqueue
                        }
                    }
                }
                fileIn.Close();

                Console.WriteLine("\nІНШІ СТУДЕНТИ:");
                Console.WriteLine(new string('-', 50));
                
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