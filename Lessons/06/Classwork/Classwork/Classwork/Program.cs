using System;

namespace Classwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var marks = new[]
            {
                new [] { 2, 3, 3, 2, 3}, // Monday (it was a good weekend :)
                new [] { 2, 4, 5, 3}, // Tuesday (anyway better than Monday)
                null, // Wednesday (felt sick, stayed at home :( )
                new [] { 5, 5, 5, 5}, // Thursday (God mode :)
                new [] { 4 } // Friday (a very short day)
            };            var numberOfMarks = 0.0;
            var totalSum = 0.0;

            for (int i = 0; i < marks.Length; i++)
            {
                var marksSum = 0.0;

                if (marks[i] == null)
                {
                    Console.WriteLine($"The average mark for {(DayOfWeek)(i + 1)} - N/A");
                    continue;
                }

                for (int j = 0; j < marks[i].Length; j++)
                {
                    marksSum += marks[i][j];
                    totalSum += marks[i][j];
                    numberOfMarks++;
                }

                var average = marksSum / marks[i].Length;

                Console.WriteLine("The average mark for {0} - {1:0.0}", (DayOfWeek)(i + 1), average);
            }

            Console.WriteLine("Average rating for week - {0:0.0}", totalSum / numberOfMarks);
            Console.ReadKey();
        }
    }
}
