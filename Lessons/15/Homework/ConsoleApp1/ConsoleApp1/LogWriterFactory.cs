using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class LogWriterFactory
    {
        private static ILogWriter instance;
        private LogWriterFactory()
        {
        }
        public static ILogWriter GetLogWriter<T>(object parameters = null) where T : ILogWriter, new()
        {
            if (typeof(T) == typeof(ConsoleLogWriter))
            {
                return instance ?? (instance = new ConsoleLogWriter());
            }
            if (typeof(T) == typeof(FileLogWriter))
            {
                return instance ?? (instance = new FileLogWriter(parameters.ToString()));
            }
            if (typeof(T) == typeof(MultipleLogWriter))
            {
                return instance ?? (instance = new MultipleLogWriter((ILogWriter[])parameters));
            }
            return instance;
        }        
        
    }
}
