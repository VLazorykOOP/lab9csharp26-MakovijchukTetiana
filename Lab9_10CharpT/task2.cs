using System;
using System.Collections;
using System.IO;
using System.Text;

namespace lab9
{
    public class task2
    {
        // Структура для зберігання всіх даних про одного студента
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
            // Створюємо чергу (FIFO) для студентів, які мають хоча б одну оцінку нижче 4
            Queue otherStudents = new Queue();
            Student student;
            string line;
            string filePath = "students.txt";

            // Перевіряємо, чи існує файл у поточній директорії, щоб уникнути помилки вильоту програми
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

                // Читаємо файл рядок за рядком, поки не дійдемо до кінця (null)
                while ((line = fileIn.ReadLine()) != null) 
                {
                    // Розбиваємо поточний рядок на масив слів, ігноруючи зайві пробіли та табуляції
                    string[] temp = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    // Перевіряємо, чи містить рядок усі необхідні 7 параметрів
                    if (temp.Length >= 7)
                    {
                        // Заповнюємо текстові поля структури
                        student.LastName = temp[0];
                        student.FirstName = temp[1];
                        student.Patronymic = temp[2];
                        student.Group = temp[3];
                        
                        // Перетворюємо текстові оцінки у цілочисельний тип
                        student.Grade1 = int.Parse(temp[4]);
                        student.Grade2 = int.Parse(temp[5]);
                        student.Grade3 = int.Parse(temp[6]);

                        // Перевіряємо головну умову: чи всі оцінки більше або дорівнюють 4
                        bool isGoodStudent = (student.Grade1 >= 4) && (student.Grade2 >= 4) && (student.Grade3 >= 4);

                        // Якщо студент відмінник/хорошист, відразу друкуємо його дані
                        if (isGoodStudent)
                        {
                            Console.WriteLine($"{student.LastName} {student.FirstName} \tГр: {student.Group} \tОцінки: {student.Grade1}, {student.Grade2}, {student.Grade3}");
                        }
                        else
                        {
                            // Якщо є оцінки нижче 4, ставимо студента в кінець черги
                            otherStudents.Enqueue(student);
                        }
                    }
                }
                
                fileIn.Close();

                Console.WriteLine("\nІНШІ СТУДЕНТИ:");
                Console.WriteLine(new string('-', 50));
                
                // Поки черга не порожня, витягуємо студентів по одному
                while (otherStudents.Count != 0) 
                {
                    // Дістаємо (і видаляємо) першого студента з черги та приводимо до типу Student
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