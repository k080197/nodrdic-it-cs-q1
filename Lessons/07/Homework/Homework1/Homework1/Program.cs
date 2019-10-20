using System;
using System.Text;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbol = 'A'; // ENG
            var text = InputText();

            Console.WriteLine($"Количество слов, начинающихся с буквы '{symbol}': {CountFirstSymbol(text, symbol)}.");
            Console.ReadKey();
        }

        private static int CountFirstSymbol(string text, char symbol)
        {
            text = text.ToUpper();
            var count = 0;
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (word[0] == symbol)
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountWords(string text)
        {

            var count = 1;

            for (int i = 0, p = 0; i < text.Length; p = i++)
            {
                var current = text[i];
                var previous = text[p];

                if (char.IsWhiteSpace(previous) &&
                    char.IsLetter(current))
                {
                    count++;
                }
            }

            return count;
        }

        static string InputText()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите строку из нескольких слов: ");
                    var text =  Console.ReadLine();

                    if (CountWords(text) > 1)
                    {
                        return text;
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Вы ввели пустую строку!");
                }
            }
        }
    }
}
