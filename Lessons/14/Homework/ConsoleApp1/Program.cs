using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = FileLogWriter.GetInstance();
            fileLogWriter._fileName = "log.log";
            fileLogWriter.LogWarning("Warning!");

            var consoleLogWriter = ConsoleLogWriter.Instance;
            consoleLogWriter.LogInfo("Information.");

            var multipleLogWriter = new MultipleLogWriter(
                ConsoleLogWriter.Instance,
                ConsoleLogWriter.Instance,
                FileLogWriter.GetInstance()
            );

            multipleLogWriter.LogError("Some Error!");

            Console.ReadKey();
        }
    }
}
