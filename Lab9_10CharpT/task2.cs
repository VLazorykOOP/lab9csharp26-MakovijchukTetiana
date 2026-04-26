using System;
using System.Collections;
using System.IO;
using System.Text;

namespace lab9
{
    
    public class task2
    {
        public struct Student 
        {
            public string LastName;
            public string FirstName;
            public string Patronymic;
            public string Group;
            public int Grade1;
            public int Grade2;
            public int Grade3;
        }

        public static void Run()
        {
            Queue otherStudents = new Queue();
            Student student;
            string line;
            string filePath = "students.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"[Помилка] Файл '{filePath}' не знайдено. Створіть його у папці з програмою.");
                return;
            }

            try
            {
                StreamReader fileIn = new StreamReader(filePath, Encoding.UTF8);

                Console.WriteLine("СТУДЕНТИ, ЩО ВЧАТЬСЯ НА 4 ТА 5:");
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
                            otherStudents.Enqueue(student);
                        }
                    }
                }
                fileIn.Close();

                Console.WriteLine("\nІНШІ СТУДЕНТИ:");
                Console.WriteLine(new string('-', 50));
                
                while (otherStudents.Count != 0) 
                {
                    student = (Student)otherStudents.Dequeue();
                    Console.WriteLine($"{student.LastName} {student.FirstName} \tГр: {student.Group} \tОцінки: {student.Grade1}, {student.Grade2}, {student.Grade3}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при роботі з файлом: {ex.Message}");
            }
        }
    }
}