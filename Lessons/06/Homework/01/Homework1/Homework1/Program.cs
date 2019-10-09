using System;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Введите положительное натуральное число не более 2 миллиардов:");

            var number = ReadInt();
            var div = 1;
            var evenNumbers = 0;

            do
            {
                if ((number / div) % 2 == 0)
                {
                    evenNumbers++;
                }
                div *= 10;
            }
            while (number > div);

            Console.WriteLine($" В числе {number} содержится следующее количество четных цифр: {evenNumbers}.");
            Console.ReadKey();
        }

        static int ReadInt()
        {
            while (true)
            {
                try
                {
                    var number = int.Parse(Console.ReadLine());

                    if (number > 0 && number < 2000000000)
                    {
                        return number;
                    }

                    WriteWithColor(" Введено неверное значение! Попробуйте ещё раз:", ConsoleColor.Red);
                }
                catch (FormatException exception)
                {
                    WriteWithColor("Entered incorrect data!", ConsoleColor.Red);
                    WriteWithColor(exception.Message, ConsoleColor.Red);
                }
                catch (OverflowException exception)
                {
                    WriteWithColor("Entered unsupported value", ConsoleColor.Red);
                    WriteWithColor(exception.Message, ConsoleColor.Red);
                }
            }
        }
        static void WriteWithColor(string message, ConsoleColor color)
        {
            var restoreColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = restoreColor;
        }
    }
}
