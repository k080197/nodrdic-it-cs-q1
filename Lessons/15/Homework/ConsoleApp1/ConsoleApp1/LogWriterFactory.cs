using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class LogWriterFactory
    {
        private static LogWriterFactory instance;
        private LogWriterFactory()
        {
        }
        public static LogWriterFactory Instance
        {
            get
            {
                return instance ?? (instance = new LogWriterFactory());
            }
        }
        public ILogWriter GetLogWriter<T>(object parameters = null) where T : ILogWriter, new()
        {
            if (typeof(T) == typeof(ConsoleLogWriter))
            {
                return new ConsoleLogWriter();
            }
            if (typeof(T) == typeof(FileLogWriter))
            {
                return new FileLogWriter(parameters.ToString());
            }
            if (typeof(T) == typeof(MultipleLogWriter)) 
            {
                return new MultipleLogWriter((ILogWriter[])parameters);
            }
            return null;
        }        
        
    }
}
