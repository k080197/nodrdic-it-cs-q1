using System;

namespace Homework5
{
    class Program
    {
        [Flags]
        enum Shapes { Circle, Triangle, Rectangle };
        static void Main(string[] args)
        {
            ViewShapes();

            do
            {
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
                break;
            } while (true);

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
                int number = default;

                try

                {
                    number = int.Parse(Console.ReadLine());
                    return number;
                }
                catch (FormatException exception) when (number < 0 || number > 2)
                {
                    WriteWithColor("Entered wrong number!", ConsoleColor.Red);
                    WriteWithColor(exception.Message, ConsoleColor.Red);
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
        static void ViewShapes()
        {
            Console.WriteLine($"Choose a shape:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{(Shapes)i} - {i}");
            }
        }
    }
}
