using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class Person
    {
        public string Name { get; set; }
        private byte m_age;
        public byte Age
        {
            get
            {
                return m_age;
            }
            set
            {
                if (value < 0 && value > 120)
                {
                    throw new ArgumentException("Вы ввели неправильный возраст.");
                }
                m_age = value;
            }
        }
        private byte AgeAfter4Years => 
            (byte)(m_age + 4);
        public string Description =>
            $"Name: {Name}, age in 4 years: {AgeAfter4Years}";
    }
}
