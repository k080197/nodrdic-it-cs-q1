using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MultipleLogWriter : Interfaces.ILogWriter
    {
        public MultipleLogWriter(List<Interfaces.ILogWriter> logWriters)
        {
            foreach(var logWriter in logWriters)
            {
                
            }
        }
        public void LogInfo(string message)
        {

        }
        public void LogWarning(string message)
        {

        }
        public void LogError(string message)
        {

        }
    }
}
