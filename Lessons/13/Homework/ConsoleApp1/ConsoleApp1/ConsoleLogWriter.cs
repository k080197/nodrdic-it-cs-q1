using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ConsoleLogWriter : Interfaces.ILogWriter
    {
        public void LogInfo(string message)
        {
            Console.WriteLine(DateTimeOffset.Now + "\t" + MessageTypes.Info + "\t" + message);
        }
        public void LogWarning(string message)
        {
            Console.WriteLine(DateTimeOffset.Now + "\t" + MessageTypes.Warning + "\t" + message);
        }
        public void LogError(string message)
        {
            Console.WriteLine(DateTimeOffset.Now + "\t" + MessageTypes.Error + "\t" + message);
        }
        public ConsoleLogWriter(string message)
        {
            LogInfo(message);
            LogWarning(message);
            LogError(message);
        }
    }
}
