using System;
using System.Collections;

namespace lab9
{
    public class task4
    {
        // Головна хеш-таблиця. 
        static Hashtable catalog = new Hashtable();

        public static void Run()
        {
            // Очищуємо каталог при кожному запуску цього пункту меню, щоб дані не дублювалися
            catalog.Clear(); 

            Console.WriteLine("Ініціалізація каталогу \n");

            // Створюємо нові диски
            AddDisk("Rock Hits 80s");
            AddDisk("Pop Music 2026");

            Console.WriteLine();
            
            // Наповнюємо диски піснями
            AddSong("Rock Hits 80s", "Bohemian Rhapsody", "Queen");
            AddSong("Rock Hits 80s", "We Will Rock You", "Queen");
            AddSong("Pop Music 2026", "Blinding Lights", "The Weeknd");

            // Виводимо весь вміст
            PrintCatalog();

            // Переглядаємо конкретний диск
            PrintDisk("Rock Hits 80s");

            // Шукаємо пісні конкретного виконавця
            SearchArtist("Queen");

            Console.WriteLine("\n Видалення даних ");
            
            // Видаляємо одну пісню і цілий диск
            RemoveSong("Rock Hits 80s", "We Will Rock You");
            RemoveDisk("Pop Music 2026");

            // Перевіряємо результат після видалення
            PrintCatalog();
        }

        static void AddDisk(string diskName)
        {
            // Перевіряємо, чи немає вже диска з такою назвою (унікальність ключа)
            if (!catalog.ContainsKey(diskName))
            {
                // Додаємо новий елемент: ключ — назва, значення — нова порожня Hashtable для пісень
                catalog.Add(diskName, new Hashtable());
                Console.WriteLine($" Диск '{diskName}' успішно додано.");
            }
            else
            {
                Console.WriteLine($" Диск '{diskName}' вже існує.");
            }
        }

        static void RemoveDisk(string diskName)
        {
            // Якщо диск знайдено за ключем — видаляємо його разом з усіма піснями всередині
            if (catalog.ContainsKey(diskName))
            {
                catalog.Remove(diskName);
                Console.WriteLine($" Диск '{diskName}' видалено.");
            }
        }

        static void AddSong(string diskName, string songName, string artist)
        {
            // Спочатку перевіряємо, чи існує потрібний диск
            if (catalog.ContainsKey(diskName))
            {
                // Отримуємо доступ до внутрішньої таблиці диска. 
                // Потрібне явне приведення типу (Hashtable), оскільки колекція зберігає Object
                Hashtable disk = (Hashtable)catalog[diskName];
                
                // Перевіряємо, чи немає вже такої пісні (унікальність ключа)
                if (!disk.ContainsKey(songName))
                {
                    // Додаємо пісню у внутрішню таблицю: ключ — пісня, значення — виконавець
                    disk.Add(songName, artist);
                    Console.WriteLine($" Пісню '{songName}' додано на диск '{diskName}'.");
                }
            }
        }

        static void RemoveSong(string diskName, string songName)
        {
            if (catalog.ContainsKey(diskName))
            {
                Hashtable disk = (Hashtable)catalog[diskName];
                
                // Якщо пісня є на диску — видаляємо її за ключем
                if (disk.ContainsKey(songName))
                {
                    disk.Remove(songName);
                    Console.WriteLine($" Пісню '{songName}' видалено з диска '{diskName}'.");
                }
            }
        }

        static void PrintDisk(string diskName)
        {
            if (catalog.ContainsKey(diskName))
            {
                Console.WriteLine($"\n Диск: [{diskName}] ");
                Hashtable disk = (Hashtable)catalog[diskName];
                
                if (disk.Count == 0) Console.WriteLine("  (диск порожній)");
                else
                {
                    // Перебираємо всі ключі (назви пісень) внутрішньої таблиці
                    foreach (string songName in disk.Keys)
                        // disk[songName] повертає значення (виконавця) для відповідного ключа
                        Console.WriteLine($"   {songName} - {disk[songName]}");
                }
            }
        }

        static void PrintCatalog()
        {
            Console.WriteLine("\n ВЕСЬ КАТАЛОГ ");
            if (catalog.Count == 0) Console.WriteLine("Каталог порожній.");
            else
            {
                // Перебираємо всі ключі (назви дисків) головної таблиці
                foreach (string diskName in catalog.Keys) 
                    PrintDisk(diskName); // Викликаємо метод друку для кожного знайденого диска
            }
        }

        static void SearchArtist(string artist)
        {
            Console.WriteLine($"\n Пошук пісень виконавця: {artist}...");
            bool found = false;

            // Крок 1: Проходимо по всіх дисках у каталозі
            foreach (string diskName in catalog.Keys)
            {
                Hashtable disk = (Hashtable)catalog[diskName];
                
                // Крок 2: Проходимо по всіх піснях на поточному диску
                foreach (string songName in disk.Keys)
                {
                    // Порівнюємо значення (виконавця) із шуканим. 
                    // StringComparison.OrdinalIgnoreCase ігнорує регістр (великі/малі літери)
                    if (disk[songName].ToString().Equals(artist, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"  -> Знайдено: '{songName}' на диску '{diskName}'");
                        found = true;
                    }
                }
            }
            if (!found) Console.WriteLine("  Пісень не знайдено.");
        }
    }
}