using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var reminderItem1 = new ReminderItem(new DateTime(2019, 10, 10, 6, 30, 15), "Будильник 1");
            var reminderItem2 = new ReminderItem(new DateTime(2019, 11, 10, 6, 30, 15), "Будильник 2");

            reminderItem1.WriteProperties();
            reminderItem2.WriteProperties();

            Console.ReadKey();
        }
    }
}
