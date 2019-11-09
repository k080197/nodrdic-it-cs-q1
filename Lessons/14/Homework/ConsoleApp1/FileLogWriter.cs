using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    enum MessageTypes : byte
    {
        Info,
        Warning,
        Error
    }

    class FileLogWriter : LogWriter
    {
        private static FileLogWriter instance;

        private readonly string _fileName;

        private FileLogWriter(string fileName)
        {
            _fileName = fileName;
        }
        protected override void WriteLine(string line)
        {
            File.AppendAllText(_fileName, line);
        }
        public static FileLogWriter GetInstance(string fileName)
        {
            return instance ?? (instance = new FileLogWriter(fileName));
        }
    }
}
