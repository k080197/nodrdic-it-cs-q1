using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //var logWriterFactory1 = LogWriterFactory.GetLogWriter<ConsoleLogWriter>();

            //var logWriterFactory2 = LogWriterFactory.GetLogWriter<FileLogWriter>("log.log");

            var logWriterFactory3 = LogWriterFactory.GetLogWriter<MultipleLogWriter>(
                new ILogWriter[]{
                    new ConsoleLogWriter(),
                    new ConsoleLogWriter(),
                    new ConsoleLogWriter(),
                    new ConsoleLogWriter(),
                    new FileLogWriter("log1.log"),
                    new FileLogWriter("log2.log")
                }
            );

            logWriterFactory3.LogError("Some Error!");

            Console.ReadKey();
        }
    }
}
