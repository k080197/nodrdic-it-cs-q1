using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = new FileLogWriter("Привет!");
            var consoleLogWriter = new ConsoleLogWriter("Привет!");
            var MultipleLogWriter = new MultipleLogWriter(new List<Interfaces.ILogWriter>(fileLogWriter, consoleLogWriter));
        }
    }
}
