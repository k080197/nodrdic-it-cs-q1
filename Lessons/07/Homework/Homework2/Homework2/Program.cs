using System;
using System.Text;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new StringBuilder();
            text.Append(InputText());

            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write(char.ToLower(text.ToString()[i]));
            }

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
