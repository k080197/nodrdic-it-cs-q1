using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class FileLogWriter : LogWriter
    {
        private static FileLogWriter instance;

        public string _fileName;

        private FileLogWriter()
        {
        }
        protected override void WriteLine(string line)
        {
            if (_fileName != null)
            {
                File.AppendAllText(_fileName, line);
            }
            else
            {
                Console.WriteLine("Укажите имя файла.");
            }
            
        }
        public static FileLogWriter GetInstance()
        {
            return instance ?? (instance = new FileLogWriter());
        }
    }
}
