using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class ReminderItem
    {
        public DateTime AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public TimeSpan TimeToAlarm =>
            DateTime.Now - AlarmDate;
        public bool IsOutdated =>
            TimeToAlarm.Milliseconds < 0 ? false : true;

        public ReminderItem(DateTime alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public void WriteProperties()
        {
            Console.WriteLine($"Alarm date: {AlarmDate}");
            Console.WriteLine($"Alarm message: {AlarmMessage}");
            Console.WriteLine($"Time to alarm: {TimeToAlarm}");
            Console.WriteLine($"Is outdated: {IsOutdated}");
        }
    }
}
