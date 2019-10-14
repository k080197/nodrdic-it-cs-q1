using System;
using System.Text;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FirstSymbolCounter(Console.ReadLine(), 'a'));

            Console.ReadKey();
        }

        private static string DeleteSpaces(string text)
        {
            var result = new StringBuilder();

            for (int i = 0, p = 0; i < text.Length; p = i++)
            {
                var current = text[i];
                var previous = text[p];

                if (char.IsWhiteSpace(current) &&
                    char.IsLetter(previous))
                {
                    result.Append(' ');
                }
            }
            Console.WriteLine(result);
            return result.ToString();
        }

        private static string FirstSymbolCounter(string text, char symbol)
        {
            var word = text[0] == symbol ? 1 : 0;

            for (int i = 0, p = 0; i < text.Length; p = i++)
            {
                var current = text[i];
                var previous = text[p];
                Console.WriteLine(i +" "+ word);
                if (char.IsWhiteSpace(previous) &&
                    current == symbol)
                {
                    word++;
                } 
            }

            if (word > 0)
            {
                return $"{word} слов начинаются с буквы {symbol} {text}";
            }

            return "Вы ввели мало слов.";
        }
    }
}
