using System;
using System.IO;
using System.IO.Compression;

namespace ConsoleApp4
{

    class RandomDataGeneratedArgs
    {
        public byte[] RandomData { get; set; }
    }

    class RandomDataGeneratingArgs
    {
        public int BytesDone { get; set; }
        public int TotalBytes { get; set; }
    }

    public delegate void RandomDataGeneratedHandler(int bytesDone, int totalBytes);

    public class RandomDataGenerator
    {
        public event RandomDataGeneratedHandler RandomDataGenerating;
        public event EventHandler RandomDataGenerated;

        public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseEvent)
        {
            var result = new byte[dataSize];
            var rand = new Random();

            for (var i = 0; i < dataSize; i++)
            {
                result[i] = (byte)rand.Next(256);

                if ((i + 1) % bytesDoneToRaiseEvent == 0)
                {
                    OnRandomDataGenerating(i + 1, dataSize);
                }
            }

            OnRandomDataGenerated(this, EventArgs.Empty);

            return result;
        }

        protected virtual void OnRandomDataGenerating(int bytesDone, int totalBytes)
        {
            if (RandomDataGenerating != null)
            {
                RandomDataGenerating(bytesDone, totalBytes);
            }
        }

        protected virtual void OnRandomDataGenerated(object sender, EventArgs e)
        {
            if (RandomDataGenerated != null)
            {
                RandomDataGenerated(sender, e);
            }
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {
            var gen = new RandomDataGenerator();
            gen.RandomDataGenerating += OnRandomDataGenerating;
            gen.RandomDataGenerated += OnRandomDataGenerated;

            var randomBytes = gen.GetRandomData(100000, 5000);

            Console.WriteLine(
                "Random data: {0}",
                Convert.ToBase64String(randomBytes));
            
            const string binaryFileName = "random.data";
            File.WriteAllBytes(binaryFileName, randomBytes);
            
            const string zipFileName = binaryFileName + ".zip";

            if (File.Exists(zipFileName))
            {
                File.Delete(zipFileName);
            }

            using (var zip = ZipFile.Open(binaryFileName + ".zip", ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(binaryFileName, binaryFileName);
            }
        }

        private static void OnRandomDataGenerating(int bytesDone, int totalBytes)
        {
            Console.WriteLine($"Generated {bytesDone} from {totalBytes} byte(s)...");
        }

        private static void OnRandomDataGenerated(object sender, EventArgs e)
        {
            Console.WriteLine($"Generation DONE");
        }
    }
}
