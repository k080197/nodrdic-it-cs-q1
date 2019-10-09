using System;

namespace Homework5
{
    [Flags]
    enum Shapes : int
    {
        Circle,
        Triangle,
        Rectangle
    };

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Choose a shape:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{(Shapes)i} - {i}");
            }

            switch(ReadEnum())
            {
                case 0:
                    CircleArea(ReadInt("diameter"));
                    break;
                case 1:
                    TriangleArea(ReadInt("edge"));
                    break;
                case 2:
                    RectangleArea(ReadInt("length"), ReadInt("width"));
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

        static void CircleArea(int diameter)
        {
            Console.WriteLine($"Circle area: { Math.PI * Math.Pow(diameter / 2, 2) }");
            Console.WriteLine($"Circle perimeter: { 2 * Math.PI * (diameter / 2) }");
        }

        static void TriangleArea(int edge)
        {
            Console.WriteLine($"Triangle area: { (edge * edge * Math.Sqrt(3)) / 4 }");
            Console.WriteLine($"Triangle perimeter: { 3 * edge }");
        }

        static void RectangleArea(int length, int width)
        {
            Console.WriteLine($"Rectangle area: { length * width }");
            Console.WriteLine($"Rectangle perimeter: { 2 * (length + width) }");
        }

        static int ReadEnum()
        {
            while (true)
            {
                if (Enum.TryParse(typeof(Shapes), Console.ReadLine(), out var result))
                {
                    return (int)result;
                }

                WriteWithColor("Entered incorrect data!", ConsoleColor.Red);
            }
        }

        static int ReadInt(string name)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Enter integer value of {name}");
                    return int.Parse(Console.ReadLine());
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
