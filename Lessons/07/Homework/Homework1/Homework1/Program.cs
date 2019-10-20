using System;
using System.Text;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Количество слов, начинающихся с буквы 'A': {CountFirstSymbol(InputText(), 'A')}.");
            Console.ReadKey();
        }

        private static int CountFirstSymbol(string[] words, char symbol)
        {
            var count = 0;

            foreach (string word in words)
            {
                if (word[0] == symbol || word[0] == char.ToLower(symbol))
                {
                    count++;
                }
            }

            return count;
        }

        static string[] InputText()
        {
            while (true)
            {
                Console.WriteLine("Введите строку из нескольких слов: ");
                var text =  Console.ReadLine();

                if (!string.IsNullOrEmpty(text))
                {
                    var textArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (textArray.Length > 1)
                    {
                        return textArray;
                    }
                }
            }
        }
    }
}
