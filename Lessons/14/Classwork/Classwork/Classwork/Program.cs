using System;
using System.Collections.Generic;

namespace Classwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfErrors = new List<string>();

            using (ErrorList errorList = new ErrorList("Errors", listOfErrors))
            {
                errorList.Add("Ошибка 1");
                errorList.Add("Ошибка 2");
                errorList.Add("Ошибка 3");

                foreach(var errors in errorList)
                {
                    Console.WriteLine(errorList.Category + " : " + errors);
                }
            }

            Console.ReadKey();
        }
    }
}
