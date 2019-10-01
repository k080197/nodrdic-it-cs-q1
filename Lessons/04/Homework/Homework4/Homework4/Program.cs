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

            while (litres > 0)
            {
                if (litres >= 20)
                {
                    litres -= 20;
                    containers |= Containers.Twenty;
                    countOfContainers[0]++;
                    continue;
                }
                if (litres >= 5)
                {
                    litres -= 5;
                    containers |= Containers.Five;
                    countOfContainers[1]++;
                    continue;
                }
                if (litres >= 1)
                {
                    litres -= 1;
                    containers |= Containers.One;
                    countOfContainers[2]++;
                    continue;
                }
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
