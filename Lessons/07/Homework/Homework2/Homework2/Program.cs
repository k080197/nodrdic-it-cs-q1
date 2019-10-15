using System;
using System.Text;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите непустую строку:");

            var text = new StringBuilder();
            text.Append(Console.ReadLine());

            while (string.IsNullOrWhiteSpace(text.ToString()))
            {
                Console.WriteLine("Вы ввели пустую строку :( Попробуйте ещё раз:");
                text.Append(Console.ReadLine());
            }

            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write(char.ToLower(text.ToString()[i]));
            }

            Console.ReadKey();
        }
    }
}
