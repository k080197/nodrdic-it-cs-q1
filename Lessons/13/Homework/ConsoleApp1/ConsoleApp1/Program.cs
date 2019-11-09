using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = new FileLogWriter("log1.log");
            fileLogWriter.LogWarning("Warning!");

            var consoleLogWriter = new ConsoleLogWriter();
            consoleLogWriter.LogInfo("Information.");

            var multipleLogWriter = new MultipleLogWriter(
                new ConsoleLogWriter(),
                new ConsoleLogWriter(),
                new ConsoleLogWriter(),
                new ConsoleLogWriter(),
                new FileLogWriter("log1.log"),
                new FileLogWriter("log2.log")
            );

            multipleLogWriter.LogError("Some Error!");

            Console.ReadKey();
        }
    }
}
