using System;
using System.Collections.Generic;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var reminderItems = new List<ReminderItem>();

            reminderItems.Add(new ReminderItem(DateTimeOffset.Parse("2017-09-23"), "Будильник 1"));
            reminderItems.Add(new PhoneReminderItem(
                DateTimeOffset.Parse("2017-09-23"), 
                "Звонок", 
                "8 (999) 842-13-95"
                ));
            reminderItems.Add(new ChatReminderItem(
                DateTimeOffset.Parse("2017-09-23"), 
                "Напоминание", 
                "Чат №1", 
                "Константин"
                ));

            foreach (var reminderItem in reminderItems)
            {
                reminderItem.WriteProperties();
            }

            Console.ReadKey();
        }
    }
}
