using System;
using System.Collections;

namespace lab9
{
    public class task1
    {
        public static void Run()
        {
            // Вхідний рядок, де '#' діє як клавіша Backspace
            string input = "abc#d##c"; 
            
            // Створюємо порожній стек для зберігання символів
            Stack charStack = new Stack(); 

            Console.WriteLine($"Вхідний рядок: {input}");

            // Перебираємо кожен символ у вхідному рядку
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                // Якщо поточний символ не '#', поміщаємо його на верхівку стека
                if (currentChar != '#')
                {
                    charStack.Push(currentChar);
                }
                else
                {
                    // Якщо це '#', перевіряємо, чи стек не порожній, щоб уникнути помилки
                    if (charStack.Count != 0) 
                    {
                        // Видаляємо останній доданий символ 
                        charStack.Pop(); 
                    }
                }
            }

            // Створюємо масив символів розміром із залишок елементів у стеку
            char[] resultArray = new char[charStack.Count];
            
            // Встановлюємо індекс на останній елемент масиву
            int index = charStack.Count - 1;

            // Витягуємо символи зі стека, поки він не спорожніє
            while (charStack.Count != 0)
            {
                // Записуємо елементи в масив з кінця на початок 
                resultArray[index] = (char)charStack.Pop();
                index--;
            }

            // Перетворюємо масив символів назад у повноцінний рядок
            string resultString = new string(resultArray);
            Console.WriteLine($"Результат після обробки Backspace: {resultString}");
        }
    }
}