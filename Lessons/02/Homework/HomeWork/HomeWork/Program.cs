using System;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 2 числа и операцию над ними (+, -, *, /, остаток от деления %, возведение в степень ^):");

            var firstOperand = double.Parse(Console.ReadLine());
            var secondOperand = double.Parse(Console.ReadLine());
            var operation = Console.ReadLine();

            if (operation == "+")
            {
                Console.WriteLine(firstOperand + secondOperand);
            }
            else if (operation == "-")
            {
                Console.WriteLine(firstOperand - secondOperand);
            }
            else if (operation == "*")
            {
                Console.WriteLine(firstOperand * secondOperand);
            }
            else if (operation == "/")
            {
                Console.WriteLine(firstOperand / secondOperand);
            }
            else if (operation == "%")
            {
                Console.WriteLine(firstOperand % secondOperand);
            }
            else if (operation == "^")
            {
                Console.WriteLine(Math.Pow(firstOperand, secondOperand));
            }
            else
            {
                Console.WriteLine("Ошибка.");
            }

            Console.ReadKey();
        }
    }
}
