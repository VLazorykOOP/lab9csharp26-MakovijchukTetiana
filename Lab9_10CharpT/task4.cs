using System;
using System.Collections;

namespace lab9
{
    
    public class task4
    {
        static Hashtable catalog = new Hashtable();

        public static void Run()
        {
            // Очищуємо каталог при кожному запуску цього пункту меню
            catalog.Clear(); 

            Console.WriteLine("Ініціалізація каталогу \n");

            AddDisk("Rock Hits 80s");
            AddDisk("Pop Music 2026");

            Console.WriteLine();
            
            AddSong("Rock Hits 80s", "Bohemian Rhapsody", "Queen");
            AddSong("Rock Hits 80s", "We Will Rock You", "Queen");

            AddSong("Pop Music 2026", "Blinding Lights", "The Weeknd");

            PrintCatalog();

            PrintDisk("Rock Hits 80s");

            SearchArtist("Queen");

            Console.WriteLine("\n Видалення даних ");
            RemoveSong("Rock Hits 80s", "We Will Rock You");
            RemoveDisk("Pop Music 2026");

            PrintCatalog();
        }

        static void AddDisk(string diskName)
        {
            if (!catalog.ContainsKey(diskName))
            {
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
            if (catalog.ContainsKey(diskName))
            {
                catalog.Remove(diskName);
                Console.WriteLine($" Диск '{diskName}' видалено.");
            }
        }

        static void AddSong(string diskName, string songName, string artist)
        {
            if (catalog.ContainsKey(diskName))
            {
                Hashtable disk = (Hashtable)catalog[diskName];
                if (!disk.ContainsKey(songName))
                {
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
                    foreach (string songName in disk.Keys)
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
                foreach (string diskName in catalog.Keys) PrintDisk(diskName);
            }
        }

        static void SearchArtist(string artist)
        {
            Console.WriteLine($"\n Пошук пісень виконавця: {artist}...");
            bool found = false;

            foreach (string diskName in catalog.Keys)
            {
                Hashtable disk = (Hashtable)catalog[diskName];
                foreach (string songName in disk.Keys)
                {
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