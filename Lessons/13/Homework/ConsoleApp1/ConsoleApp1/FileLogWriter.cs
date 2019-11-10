using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class FileLogWriter : LogWriter
    {
        private readonly string _fileName;

        public FileLogWriter(string fileName)
        {
            _fileName = fileName;
        }
        protected override void WriteLine(string line)
        {
            File.AppendAllText(_fileName, line);
        }
    }
}
