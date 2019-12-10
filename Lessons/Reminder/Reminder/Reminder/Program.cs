using System;
using Reminder.Domain;
using Reminder.Receiver.Telegram;
using Reminder.Storage.Memory;
using Reminder.Sender.Telegram;

namespace Reminder
{
	class Program
	{
		static void Main(string[] args)
		{
			var key = "910292812:AAG11CN09Q4Q9EjW-4PSyJWzHbtQw82C74M";
            using (var service = new ReminderService(
                storage: new ReminderStorage(),
                sender: new ReminderSender(key),
                receiver: new ReminderReceiver(key),
                parameters: ReminderServiceParameters.Default
            ))
            {
                service.ItemSent += OnItemSent;
                service.ItemFailed += OnItemFailed;

                Console.WriteLine("[Reminder] starting...");
                service.Start();
                Console.WriteLine("[Reminder] started. Press any key to stop service");
                Console.ReadKey();
                Console.WriteLine("[Reminder] stopped.");
            }
		}

		private static void OnItemSent(object sender, ItemSentEventArgs args)
		{
			Console.WriteLine($"[Reminder notification] sent with id: {args.Id:N}");
		}

		private static void OnItemFailed(object sender, ItemFailedEventArgs args)
		{
			Console.WriteLine($"[Reminder notification] sent with id: {args.Id:N}, error: {args.Exception}");
		}
	}
}
