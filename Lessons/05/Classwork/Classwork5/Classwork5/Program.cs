using System;

namespace Classwork5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number from 0 to 99:");

            var number = int.Parse(Console.ReadLine());
            
            switch(number % 10)
            {
                case 1 when number / 10 != 1:
                    Console.WriteLine($"{number} год.");
                    break;
                case 2 when number / 10 != 1:
                case 3 when number / 10 != 1:
                case 4 when number / 10 != 1:
                    Console.WriteLine($"{number} года.");
                    break;
                default:
                    Console.WriteLine($"{number} лет.");
                    break;
            }
            
            Console.ReadKey();
        }
    }
}
