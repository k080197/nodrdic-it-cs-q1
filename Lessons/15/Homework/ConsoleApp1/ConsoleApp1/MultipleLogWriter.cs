using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MultipleLogWriter : ILogWriter
    {
        private readonly ILogWriter[] _writers;

        public MultipleLogWriter()
        {
        }
        public MultipleLogWriter(params ILogWriter[] writers)
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
    }
}
