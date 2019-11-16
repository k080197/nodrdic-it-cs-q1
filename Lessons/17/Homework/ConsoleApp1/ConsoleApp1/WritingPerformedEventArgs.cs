using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class WritingPerformedEventArgs: EventArgs
    {
        public int BytesDone { get; set; }
    }
}
