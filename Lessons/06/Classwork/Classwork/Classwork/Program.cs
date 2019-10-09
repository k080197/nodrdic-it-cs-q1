using System;

namespace Classwork
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите exit для выхода");
            }
            while (string.Equals(Console.ReadLine(), "exit", StringComparison.OrdinalIgnoreCase));
        }
    }
}
