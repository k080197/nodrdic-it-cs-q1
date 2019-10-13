using System;
using System.Text;

namespace Classwork
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = " lorem ipsum dolor sit amet ";
            var result = new StringBuilder();

            Console.WriteLine(FormatAndUppercaseWord(text));
            Console.WriteLine(RemoveLastWord(text));
            Console.ReadKey();
        }

        private static string FormatAndUppercaseWord(string text)
        {
            var result = new StringBuilder();

            for (int i = 0, p = 0, word = -1; i < text.Length; p = i++)
            {
                var current = text[i];
                var previous = text[p];

                if (char.IsWhiteSpace(previous) &&
                    char.IsLetter(current))
                {
                    word++;
                }

                if (char.IsLetter(current))
                {
                    result.Append(word == 1 ? char.ToUpper(current) : current);
                }

                if (char.IsWhiteSpace(current) &&
                    char.IsLetter(previous))
                {
                    result.Append(' ');
                }
            }

            return result.ToString();
        }

        private static string RemoveLastWord(string text)
        {
            var result = new StringBuilder();

            for (int i = 0, p = 0, word = -1; i < text.Length; p = i++)
            {
                var wordToRemove = 4;
                var current = text[i];
                var previous = text[p];

                if (char.IsWhiteSpace(previous) &&
                    char.IsLetter(current))
                {
                    word++;
                }

                if (char.IsLetter(current) &&
                    word < wordToRemove)
                {
                    result.Append(word == 1 ? char.ToUpper(current) : current);
                }

                if (char.IsWhiteSpace(current) && 
                    word < wordToRemove - 1)
                {
                    result.Append(' ');
                }
            }

            return result.ToString();
        }
    }
}
