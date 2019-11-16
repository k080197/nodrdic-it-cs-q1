using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class WritingCompletedEventArgs: EventArgs
    {
        public byte[] RandomData { get; set; }
    }
}
