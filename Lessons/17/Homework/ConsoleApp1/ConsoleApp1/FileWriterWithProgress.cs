using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class FileWriterWithProgress
    {
        public event EventHandler<WritingPerformedEventArgs> WritingPerformed;
        public event EventHandler<WritingCompletedEventArgs> WritingCompleted;
        public void WriteBytes(string fileName, byte[] data, float percentageToFireEvent)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (FileStream fileStream = new FileStream(fileName, FileMode.CreateNew))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
                var growPercentage = percentageToFireEvent;

                for (int i = 0; i < data.Length; i++)
                {
                    streamWriter.WriteLine(data[i]);

                    var currentPercent = (float)(i + 1) / data.Length;
                    var nextPercent = (float)(i + 2) / data.Length;

                    if (growPercentage >= currentPercent && growPercentage < nextPercent)
                    {
                        OnWritingPerformed(this, (int)(currentPercent * 100));
                        growPercentage += percentageToFireEvent;
                    }
                }

                OnWritingCompleted(this, data);
            }
        }



        protected virtual void OnWritingPerformed(
            object sender,
            int bytes)
        {
            var args = new WritingPerformedEventArgs
            {
                BytesDone = bytes
            };

            WritingPerformed?.Invoke(sender, args);
        }

        protected virtual void OnWritingCompleted(
            object sender,
            byte[] data)
        {
            var args = new WritingCompletedEventArgs
            {
                RandomData = data
            };

            WritingCompleted?.Invoke(sender, args);
        }
    }
}
