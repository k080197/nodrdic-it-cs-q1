using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Passport : BaseDocument
    {
        public Passport(string number, DateTimeOffset issueDate, string country, string personName) :
            base (title: "Passport", number, issueDate)
        {
            Country = country;
            PersonName = personName;
        }
        public string Country { get; set; }
        public string PersonName { get; set; }
        public void ChangeIssueDate(DateTimeOffset newIssueDate)
        {
            IssueDate = newIssueDate;
        }
    }
}
