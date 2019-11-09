using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ConsoleLogWriter : LogWriter
    {
        private static ConsoleLogWriter instance;
        protected override void WriteLine(string line) => 
            Console.WriteLine(line);
        public static ConsoleLogWriter Instance
        {
            get
            {
                return instance ?? (instance = new ConsoleLogWriter());
            }
        }
        private ConsoleLogWriter()
        {
        }
    }
}
