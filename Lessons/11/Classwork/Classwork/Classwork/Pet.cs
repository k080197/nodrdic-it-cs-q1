using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork
{
    class Pet
    {
        public string Kind;
        public string Name;
        public char Sex;
        public DateTime DateOfBirth;

        public byte GetAge()
        {
            TimeSpan difference = DateTime.Now - DateOfBirth;
            return (byte)Math.Floor(difference.TotalDays / 365);
        }

        public string Description =>
            $"{Name} is a {Kind} ({Sex}) of {GetAge()} years old.";
        public string ShortDescription =>
            $"{Name} is a {Kind}.";

        public void Display(bool isDescription)
        {
            Console.WriteLine(isDescription ? Description : ShortDescription);
        }
    }
}
