using System;

namespace Homework4
{
    enum Containers : int
    {
        None = 0x0,
        One = 0x1,
        Five = 0x1 << 1,
        Twenty = 0x1 << 2
    }
    class Program
    {
        static void Main(string[] args)
        {
            var litres = Math.Ceiling(ReadNumber());
            var countOfContainers = new int[3];
            var containers = Containers.None;

            if (litres >= 20)
            {
                var remainder = (int)Math.Floor(litres / 20); 
                countOfContainers[0] = remainder;
                litres -= remainder * 20;
                containers |= Containers.Twenty;
            }
            if (litres >= 5)
            {
                var remainder = (int)Math.Floor(litres / 5);
                countOfContainers[1] = remainder;
                litres -= remainder * 5;
                containers |= Containers.Five;
            }
            if (litres >= 1)
            {
                countOfContainers[2] = (int)Math.Round(litres);
                containers |= Containers.One;
            }

            Console.WriteLine($"Вам потребуются следующие контейнеры:");

            if((containers & Containers.Twenty) == Containers.Twenty)
            {
                Console.WriteLine($"20 л: {countOfContainers[0]} шт.");
            }
            if ((containers & Containers.Five) == Containers.Five)
            {
                Console.WriteLine($"5 л: {countOfContainers[1]} шт.");
            }
            if ((containers & Containers.One) == Containers.One)
            {
                Console.WriteLine($"1 л: {countOfContainers[2]} шт.");
            }

            Console.ReadKey();
        }

        static decimal ReadNumber()
        {
            while (true)
            {
                Console.WriteLine($"Какой объем сока (в литрах) требуется упаковать?");

                if (decimal.TryParse(Console.ReadLine(), out var operand))
                {
                    return operand;
                }

                Console.WriteLine("Wrong value! ");
            }
        }

    }
}
