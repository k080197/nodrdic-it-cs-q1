using System;
using System.IO;
using System.IO.Compression;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var gen = new RandomDataGenerator();
            gen.RandomDataGenerating += OnRandomDataGenerating;
            gen.RandomDataGenerated += OnRandomDataGenerated;

            var randomBytes = gen.GetRandomData(1000, 50);

            var writer = new FileWriterWithProgress();

            writer.WritingPerformed += OnWritingPerformed;
            writer.WritingCompleted += OnWritingCompleted;

            writer.WriteBytes("byte.txt", randomBytes, 0.1f);
            // будет 11 событrandomBytesий - 10 событий WritingPerformed при достижении 10%, 20%, …, 100% записи
            // + 1 событие WritingCompleted при завершении.
            writer.WriteBytes("byte.txt", gen.GetRandomData(1000, 50), 0.15f);
            // будет 7 событий - 6 событий WritingPerformed при достижении 15%, 30%, …, 90% записи
            //+ 1 событие WritingCompleted при завершении.


            Console.ReadKey();
        }

        private static void OnWritingCompleted(object sender, WritingCompletedEventArgs e)
        {
            Console.WriteLine("File recorded successfully.\n\n");
        }

        private static void OnWritingPerformed(object sender, WritingPerformedEventArgs e)
        {
            Console.WriteLine($"Writed {e.BytesDone}% from 100% ...");
        }

        private static void OnRandomDataGenerating(object sender, RandomDataGeneratingEventArgs e)
        {
            Console.WriteLine($"Generated {e.BytesDone} from {e.TotalBytes} byte(s)...");
        }

        private static void OnRandomDataGenerated(object sender, RandomDataGeneratedEventArgs e)
        {
            Console.WriteLine(
                "Generation done.\n\n");
        }
    }
}
