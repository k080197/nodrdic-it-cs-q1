﻿using System;
using System.IO;
using System.IO.Compression;

namespace ConsoleApp4
{
    public class RandomDataGeneratedEventArgs : EventArgs
    {
        public byte[] RandomData { get; set; }
    }

    public class RandomDataGeneratingEventArgs
    {
        public int BytesDone { get; set; }
        public int TotalBytes { get; set; }
    }

    public class RandomDataGenerator
    {
        public event EventHandler<RandomDataGeneratingEventArgs> RandomDataGenerating;
        public event EventHandler<RandomDataGeneratedEventArgs> RandomDataGenerated;

        public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseEvent)
        {
            var result = new byte[dataSize];
            var rand = new Random();

            for (var i = 0; i < dataSize; i++)
            {
                result[i] = (byte)rand.Next(256);

                if ((i + 1) % bytesDoneToRaiseEvent == 0)
                {
                    OnRandomDataGenerating(this, i + 1, dataSize);
                }
            }

            OnRandomDataGenerated(this, result);

            return result;
        }

        protected virtual void OnRandomDataGenerating(
            object sender,
            int bytes,
            int total)
        {
            var args = new RandomDataGeneratingEventArgs
            {
                BytesDone = bytes,
                TotalBytes = total
            };
            if (RandomDataGenerating != null)
            {
                RandomDataGenerating(sender, args);
            }
        }

        protected virtual void OnRandomDataGenerated(
            object sender,
            byte[] data)
        {
            var args = new RandomDataGeneratedEventArgs
            {
                RandomData = data
            };
            if (RandomDataGenerated != null)
            {
                RandomDataGenerated(sender, args);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var gen = new RandomDataGenerator();
            gen.RandomDataGenerating += OnRandomDataGenerating;
            gen.RandomDataGenerated += OnRandomDataGenerated;

            var randomBytes = gen.GetRandomData(100000, 5000);

            // writing generated bytes to a binary file
            const string binaryFileName = "random.data";
            File.WriteAllBytes(binaryFileName, randomBytes);

            // zipping the binary file
            const string zipFileName = binaryFileName + ".zip";

            if (File.Exists(zipFileName))
            {
                File.Delete(zipFileName);
            }

            using (var zip = ZipFile.Open(binaryFileName + ".zip", ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(binaryFileName, binaryFileName);
                Console.WriteLine("\t\t\t\t1\t\t\t");
            }

            Console.ReadKey();
        }

        private static void OnRandomDataGenerating(object sender, RandomDataGeneratingEventArgs e)
        {
            Console.WriteLine($"Generated {e.BytesDone} from {e.TotalBytes} byte(s)...");
        }

        private static void OnRandomDataGenerated(object sender, RandomDataGeneratedEventArgs e)
        {
            Console.WriteLine(
                "Generation done. Random data:\n{0}",
                Convert.ToBase64String(e.RandomData));
        }
    }
}
