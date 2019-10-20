using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new Person[3];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person();
                persons[i].Name = InputName(i);
                persons[i].Age = InputAge(i);
            }

            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine(persons[i].Description);
            }

            Console.ReadKey();
        }

        static string InputName(int index)
        {
            while (true)
            {
                Console.WriteLine($"Input {index + 1} name:");
                var text = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(text))
                {
                    return text;
                }

                Console.WriteLine("Wrong value!");
            }
        }

        static byte InputAge(int index)
        {
            while (true)
            {
                Console.WriteLine($"Input {index + 1} age:");

                if (byte.TryParse(Console.ReadLine(), out var operand))
                {
                    if (operand > 0 && operand < 120)
                    {
                        return operand;
                    }
                }

                Console.WriteLine("Wrong value!");
            }
        }
    }
}
