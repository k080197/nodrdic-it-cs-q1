using System;
using System.Linq;

namespace Classwork4
{
    [Flags]
    enum Colors : int
    {
        None = 0x0,
        Black = 0x1,
        Blue = 0x1 << 1,
        Cyan = 0x1 << 2,
        Grey = 0x1 << 3,
        Green = 0x1 << 4,
        Magneta = 0x1 << 5,
        Red = 0x1 << 6,
        White = 0x1 << 7,
        Yellow = 0x1 << 8
    }
    class Program
    {
        static void Main(string[] args)
        {
            Colors favoriteColors = Colors.None;

            Console.WriteLine("Enter four color numbers for the palette: ");

            for (int i = 0; i < 8; i++)
            {
                int shiftOperand = 0x1 << i;

                Console.WriteLine($"{(Colors)shiftOperand} - {shiftOperand}");
            }

            for (int i = 0; i < 4; i++)
            {
                favoriteColors = favoriteColors | (Colors)ReadNumber(favoriteColors);
            }

            Console.WriteLine("Favorite colors: ");

            for (int i = 0; i < 8; i++)
            {
                int shiftOperand = 0x1 << i;

                if ((favoriteColors & (Colors)shiftOperand) == (Colors)shiftOperand)
                {
                    Console.WriteLine($"{(Colors)shiftOperand} - {shiftOperand}");
                }
            }

            Console.WriteLine("Unfavorite colors: ");

            for (int i = 0; i < 8; i++)
            {
                int shiftOperand = 0x1 << i;

                if ((favoriteColors & (Colors)shiftOperand) != (Colors)shiftOperand)
                {
                    Console.WriteLine($"{(Colors)shiftOperand} - {shiftOperand}");
                }
            }

            Console.ReadKey();
        }

        static int ReadNumber(Colors colors)
        {
            while (true)
            {
                Console.Write($"Enter the number: ");
                
                var numbers = new int[] { 1, 2, 4, 8, 16, 32, 64, 128 };

                if (int.TryParse(Console.ReadLine(), out var operand) && numbers.Contains(operand))
                {
                    if ((colors & (Colors)operand) != (Colors)operand)
                    {
                        return operand;
                    }
                }

                Console.WriteLine("Wrong value! ");
            }
        }


    }
}
