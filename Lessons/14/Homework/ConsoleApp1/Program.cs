using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = FileLogWriter.GetInstance("log1.log");
            fileLogWriter.LogWarning("Warning!");

            var consoleLogWriter = ConsoleLogWriter.Instance;
            consoleLogWriter.LogInfo("Information.");

            var multipleLogWriter = MultipleLogWriter.GetInstance(
                ConsoleLogWriter.Instance,
                ConsoleLogWriter.Instance,
                FileLogWriter.GetInstance("log2.log")
            );

            multipleLogWriter.LogError("Some Error!");

            Console.ReadKey();
        }
    }
}
