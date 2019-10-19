using System;
using System.Diagnostics;

namespace Classwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            var array = GenerateRandomArray(100000, 100);
            var bubbleSort = (int[])array.Clone();
            var fastSort = (int[])array.Clone();

            stopwatch.Start();
            Array.Sort(fastSort);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            BubbleSotrting(bubbleSort);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static int[] GenerateRandomArray(int length, int maxValue)
        {
            var arr = new int[length];

            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = new Random().Next(maxValue);
            }

            return arr;
        }

        static int[] BubbleSotrting(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var buf = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = buf;
                    }
                }
            }

            return array;
        }
    }
}
