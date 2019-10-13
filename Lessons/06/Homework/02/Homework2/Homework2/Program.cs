using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сумму первоначального взноса в\n рублях:");
            var deposit = ReadNumber();

            Console.WriteLine("Введите ежедневный процент дохода в виде десятичной дроби (1% = 0.01):");
            var percent = ReadNumber();

            Console.WriteLine("Введите желаемую сумму накопления в рублях:");
            var accumulation = ReadNumber();

            var days = 0;
            var revenue = 0.0;

            do
            {
                days++;
                revenue += deposit * percent;
            }
            while (revenue < accumulation);

            Console.WriteLine($"Необходимое количество дней для накопления желаемой суммы: {days}.");
            Console.ReadKey();
        }

        static double ReadNumber()
        {
            while (true)
            {
                try
                {
                    var number = double.Parse(Console.ReadLine().Replace('.', ','));

                    if (number > 0)
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
