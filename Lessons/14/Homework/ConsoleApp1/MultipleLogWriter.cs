using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MultipleLogWriter : ILogWriter
    {
        private static MultipleLogWriter instance;

        private readonly ILogWriter[] _writers;

        private MultipleLogWriter(params ILogWriter[] writers)
        {
            _writers = writers;
        }

        public void LogError(string message)
        {
            foreach (var writer in _writers)
            {
                writer.LogError(message);
            }
        }

        public void LogInfo(string message)
        {
            foreach (var writer in _writers)
            {
                writer.LogInfo(message);
            }
        }

        public void LogWarning(string message)
        {
            foreach (var writer in _writers)
            {
                writer.LogWarning(message);
            }
        }
        public static MultipleLogWriter GetInstance(params ILogWriter[] writers)
        {
            return instance ?? (instance = new MultipleLogWriter(writers));
        }
    }
}
