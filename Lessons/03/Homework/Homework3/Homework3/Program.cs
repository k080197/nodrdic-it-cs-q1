using System;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new string[3];
            var ages = new byte[3];

            InputOutput(names, ages);
        }

        static void InputOutput(string[] names, byte[] ages)
        {
            for (int i = 0; i<names.Length; i++)
            {
                names[i] = ReadName(names[i], i + 1);
                ages[i] = ReadAge(names[i]);
            }

            Console.Clear();

            for (int i = 0; i<names.Length; i++)
            {
                Console.WriteLine($"Name: {names[i]}, age in 4 years: {ages[i] + 4}");
            }

            Console.ReadKey();
        }

        static string ReadName(string name, int index)
        {
            while(true)
            {
                Console.Write($"Enter the {index} name: ");

                name = Console.ReadLine();

                if (!name.Equals(""))
                {
                    return name;
                }
                WriteWithColor("Wrong value! ", ConsoleColor.Red);
            }
        }
        static byte ReadAge(string name)
        {
            while (true)
            {
                Console.Write($"Enter the age of {name}: ");
                
                if (byte.TryParse(Console.ReadLine(), out var operand))
                {
                    return operand;
                }
                WriteWithColor("Wrong value! ", ConsoleColor.Red);
            }
        }

        static void WriteWithColor(string text, ConsoleColor color)
        {
            var restoreColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = restoreColor;
        }
    }
}
