using System;
using System.Threading;
using NUnit.Framework;
using Reminder.Sender;
using Reminder.Storage.Memory;

namespace Reminder.Domain.Tests
{
	public class ReminderServiceTests
	{
		private ReminderServiceParameters Parameters { get; } =
			new ReminderServiceParameters(
				createTimerInterval: TimeSpan.FromMilliseconds(50),
				createTimerDelay: TimeSpan.Zero,
				readyTimerInterval: TimeSpan.FromMilliseconds(50),
				readyTimerDelay: TimeSpan.Zero
			);

		private ReminderStorage Storage =>
			new ReminderStorage();

		private IReminderSender SuccessSender =>
			new ReminderSenderFake();

		private IReminderSender FailedSender =>
			new ReminderSenderFake(shouldRaiseError: true);

		[Test]
		public void ItemSent_WhenReminderNotificationSent_ShouldRaiseEvent()
		{
			// Arrange
			var eventRaised = false;
			var receiver = new ReminderReceiverFake();
            using (var service = new ReminderService(Storage, SuccessSender, receiver, Parameters))
            {
                // Act
                service.ItemSent += (sender, args) => eventRaised = true;
                service.Start();
                receiver.Emit();
                WaitTimers();

                // Assert
                Assert.IsTrue(eventRaised);
            }
		}

		[Test]
		public void ItemFailed_WhenReminderNotificationFailed_ShouldRaiseEvent()
		{
			// Arrange
			var eventRaised = false;
			var receiver = new ReminderReceiverFake();
            using (var service = new ReminderService(Storage, FailedSender, receiver, Parameters))
            {
                // Act
                service.ItemFailed += (sender, args) => eventRaised = true;
                service.Start();
                receiver.Emit();
                WaitTimers();

                // Assert
                Assert.IsTrue(eventRaised);
            }
		}

		private void WaitTimers()
		{
			Thread.Sleep(
				(Parameters.CreateTimerDelay + Parameters.ReadyTimerDelay) * 2 +
				(Parameters.CreateTimerInterval + Parameters.ReadyTimerInternval) * 2
			);
		}
	}
}