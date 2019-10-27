using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BaseDocument
    {
        public BaseDocument(string title, string number, DateTimeOffset issueDate)
        {
            Title = title;
            Number = number;
            IssueDate = issueDate;
        }

        public string Title { get; set; }
        public string Number { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public virtual string Description =>
            $"Title: {Title}, number: {Number}, data: {IssueDate.Date}";
        public void WriteToConsole()
        {
            Console.WriteLine(Description);
        }
    }
}
