using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class PhoneReminderItem : ReminderItem
    {
        public PhoneReminderItem(DateTimeOffset alarmDate, string alarmMessage, string phoneNumber) :
            base (alarmDate, alarmMessage)
        {
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; set; }

        public override void WriteProperties()
        {
            Console.WriteLine(this.GetType().ToString());
            Console.WriteLine(Properties);
            Console.WriteLine($"Phone number: {PhoneNumber}\n");
        }
    }
}
