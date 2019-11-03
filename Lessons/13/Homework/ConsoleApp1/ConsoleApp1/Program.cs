using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = new FileLogWriter("Привет!");
            var consoleLogWriter = new ConsoleLogWriter("Привет!");

            var MultipleLogWriter = new MultipleLogWriter(new List<Interfaces.ILogWriter> {
                new FileLogWriter("Привет!"),
                new ConsoleLogWriter("Привет!")
            });

            Console.ReadKey();
        }
    }
}
