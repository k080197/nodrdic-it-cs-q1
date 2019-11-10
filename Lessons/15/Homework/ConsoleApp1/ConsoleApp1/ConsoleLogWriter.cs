using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ConsoleLogWriter : LogWriter
    {
        protected override void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
