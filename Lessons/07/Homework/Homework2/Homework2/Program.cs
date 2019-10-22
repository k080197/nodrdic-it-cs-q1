using System;
using System.Text;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new StringBuilder(InputText());
            var result = new StringBuilder();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                result.Append(char.ToLower(text[i]));
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }

        static string InputText()
        {
            while (true)
            {
                Console.WriteLine("Введите непустую строку:");
                var text = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(text))
                {
                    return text;
                }
            }
        }
    }
}
