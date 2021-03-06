﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class ReminderItem
    {
        public DateTimeOffset AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public TimeSpan TimeToAlarm =>
            DateTimeOffset.Now - AlarmDate;
        public bool IsOutdated =>
            TimeToAlarm.Milliseconds >= 0;

        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public virtual string Properties =>
            $"Alarm date: {AlarmDate}\n" +
            $"Alarm message: {AlarmMessage}\n" +
            $"Time to alarm: {TimeToAlarm}\n" +
            $"Is outdated: {IsOutdated}\n";

        public void WriteProperties()
        {
            Console.WriteLine(GetType()); 
            Console.WriteLine(Properties);
        }
    }
}
