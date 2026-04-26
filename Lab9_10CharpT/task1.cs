using System;
using System.Collections;

namespace lab9
{
    public class task1
    {
        public static void Run()
        {
            string input = "abc#d##c"; 
            Stack charStack = new Stack(); 

            Console.WriteLine($"Вхідний рядок: {input}");

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar != '#')
                {
                    charStack.Push(currentChar);
                }
                else
                {
                    if (charStack.Count != 0) 
                    {
                        charStack.Pop(); 
                    }
                }
            }

            char[] resultArray = new char[charStack.Count];
            int index = charStack.Count - 1;

            while (charStack.Count != 0)
            {
                resultArray[index] = (char)charStack.Pop();
                index--;
            }

            string resultString = new string(resultArray);
            Console.WriteLine($"Результат після обробки Backspace: {resultString}");
        }
    }
}