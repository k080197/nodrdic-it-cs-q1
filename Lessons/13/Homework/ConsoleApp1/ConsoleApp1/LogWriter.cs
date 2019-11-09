using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    abstract class LogWriter : ILogWriter
    {
        public void LogError(string message) => 
            LogMessage(message, MessageTypes.Error);

        public void LogInfo(string message) => 
            LogMessage(message, MessageTypes.Info);

        public void LogWarning(string message) => 
            LogMessage(message, MessageTypes.Warning);

        protected abstract void WriteLine(string line);

        protected void LogMessage(string message, MessageTypes messageType) => 
            WriteLine(FormatMessage(message, messageType));

        protected string FormatMessage(string message, MessageTypes messageType) => 
            $"[{DateTime.UtcNow}]\t[{messageType.ToString()}]:\t{message}";
    }
}
