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

        public override string Properties =>
            base.Properties +
            $"Phone number: {PhoneNumber}\n";
    }
}
