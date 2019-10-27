using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var documents = new BaseDocument[3];

            documents[0] = new BaseDocument("Расписка", "АБ-1234", DateTimeOffset.Parse("2010-11-12"));
            documents[1] = new Passport("2341 123456", DateTimeOffset.Parse("2017-01-20"), "Russia", "Constantine Sotskov");
            documents[2] = new BaseDocument("Доверенность", "АС-1234", DateTimeOffset.Parse("2016-05-09"));

            foreach (var document in documents)
            {
                if (document is Passport passport)
                {
                    passport.ChangeIssueDate(DateTimeOffset.Now);
                }

                document.WriteToConsole();
            }

            Console.ReadKey();
        }
    }
}
