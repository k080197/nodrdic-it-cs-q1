using System;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 2 числа и операцию над ними (+, -, *, /, остаток от деления %, возведение в степень ^):");

            var s1 = double.Parse(Console.ReadLine());
            var s2 = double.Parse(Console.ReadLine());
            var s3 = Console.ReadLine();

            if (s3 == "+")
            {
                Console.WriteLine(s1 + s2);
            }
            else if (s3 == "-")
            {
                Console.WriteLine(s1 - s2);
            }
            else if (s3 == "*")
            {
                Console.WriteLine(s1 * s2);
            }
            else if (s3 == "/")
            {
                Console.WriteLine(s1 / s2);
            }
            else if (s3 == "%")
            {
                Console.WriteLine(s1 % s2);
            }
            else if (s3 == "^")
            {
                Console.WriteLine(Math.Pow(s1, s2));
            }
            else
            {
                Console.WriteLine("Ошибка.");
            }

            Console.ReadKey();
        }
    }
}
