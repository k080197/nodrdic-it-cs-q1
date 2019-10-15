using System;
using System.Text;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbol = 'A'; // ENG

            Console.WriteLine("Введите строку из нескольких слов:");

            var text = Console.ReadLine();

            while (WordsCounter(text) < 1)
            {
                Console.WriteLine($"Слишком мало слов :( Попробуйте ещё раз:");
                text = Console.ReadLine();
            }

            Console.WriteLine($"Количество слов, начинающихся с буквы '{symbol}': {FirstSymbolCounter(text, symbol)}.");
            Console.ReadKey();
        }

        private static int FirstSymbolCounter(string text, char symbol)
        {
            text = text.ToUpper();

            var count = text[0] == symbol ? 1 : 0;

            for (int i = 0, p = 0; i < text.Length; p = i++)
            {
                var current = text[i];
                var previous = text[p];

                if (char.IsWhiteSpace(previous) &&
                    current == symbol)
                {
                    count++;
                }
            }

            return count;
        }

        private static int WordsCounter(string text)
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
    }
}
