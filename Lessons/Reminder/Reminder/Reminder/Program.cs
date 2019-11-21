using System;
using Reminder.Domain;
using Reminder.Domain.Models;
using Reminder.Storage.Memory;

namespace Reminder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Reminder Notifier] starting...");

            var storage = new ReminderStorage();
            var service = new ReminderService(storage);

            service.ItemNotified += OnReminderItemFired;
            service.Create(
                new CreateReminderModel(
                    "ContactId",
                    "First",
                    DateTimeOffset.UtcNow.AddSeconds(3)
                )
            );
            service.Create(
                new CreateReminderModel(
                    "ContactId",
                    "Second",
                    DateTimeOffset.UtcNow.AddMinutes(1)
                )
            );

            Console.ReadKey();
        }

        private static void OnReminderItemFired(object sender, NotifyReminderModel args)
        {
            Console.WriteLine(args.Message);
        }
    }
}
