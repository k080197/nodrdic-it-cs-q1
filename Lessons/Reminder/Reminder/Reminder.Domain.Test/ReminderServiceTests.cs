using System;
using NUnit.Framework;
using Reminder.Storage.Memory;
using Reminder.Domain.Models;
using System.Threading;

namespace Reminder.Domain.Tests
{
	public class ReminderServiceTests
	{

		[Test]
		public void ItemSent_WhenReminderItemAdded_SouldRaiseIvent()
		{
			var parameters = new ReminderServiceParameters(
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromMilliseconds(50)
			);
			var storage = new ReminderStorage();
			var service = new ReminderService(storage, parameters);
			var eventRaised = false;

			service.ItemSent += (sender, args) => eventRaised = true;
			service.Create(
				new CreateReminderModel("ContactID", "Message", DateTimeOffset.UtcNow)
			);
			Thread.Sleep(TimeSpan.FromMilliseconds(300));

			Assert.IsTrue(eventRaised);
		}

		private CreateReminderModel CreateReminderModel(
			string contactId = default,
			string message = default,
			DateTimeOffset dateTime = default)
		{

		}
	}
}