using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    enum MessageTypes : byte
    {
        Info,
        Warning,
        Error
    }

    class FileLogWriter : Interfaces.ILogWriter
    {
        public void LogInfo(string message)
        {
            File.AppendAllText(@"/file.txt", DateTimeOffset.Now + "\t" + MessageTypes.Info +"\t" + message);
        }
        public void LogWarning(string message)
        {
            File.AppendAllText(@"/file.txt", DateTimeOffset.Now + "\t" + MessageTypes.Warning + "\t" + message);
        }
        public void LogError(string message)
        {
            File.AppendAllText(@"/file.txt", DateTimeOffset.Now + "\t" + MessageTypes.Error + "\t" + message);
        }
        public FileLogWriter(string message)
        {
            LogInfo(message);
            LogWarning(message);
            LogError(message);
        }
    }
}
