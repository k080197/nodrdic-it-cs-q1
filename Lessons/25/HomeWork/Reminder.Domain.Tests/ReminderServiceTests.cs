using System;
using System.Threading;
using NUnit.Framework;
using Reminder.Receiver;
using Reminder.Sender;
using Reminder.Storage;
using Reminder.Storage.Memory;

namespace Reminder.Domain.Tests
{
	public class ReminderServiceTests
	{
		private ReminderServiceParameters ServiceParameters { get; } =
			new ReminderServiceParameters(
				TimeSpan.FromMilliseconds(100),
				TimeSpan.Zero,
				TimeSpan.FromMilliseconds(100),
				TimeSpan.Zero
			);

		private IReminderSender FailedSender { get; } =
			new FakeReminderSender(failed: true);

		private IReminderSender SuccessfullSender { get; } =
			new FakeReminderSender(failed: false);

		private FakeReminderReceiver Receiver { get; } =
			new FakeReminderReceiver();

		private IReminderStorage Storage =>
			new ReminderStorage();

		[Test]
		public void WhenStart_IfReminderItemReady_ShouldRaiseReminderSentEvent()
		{
			// Arrange
			var eventRaised = false;
			var storage = new ReminderStorage(
				CreateReminderItem(status: ReminderItemStatus.Ready)
			);
			using var service = new ReminderService(
				storage,
				SuccessfullSender,
				Receiver,
				ServiceParameters
			);
			service.ReminderSent += (sender, args) => eventRaised = true;

			// Act
			service.Start();
			WaitTimers();

			// Assert
			Assert.IsTrue(eventRaised);
		}

		[TestCase(ReminderItemStatus.Sent)]
		[TestCase(ReminderItemStatus.Failed)]
		public void WhenStart_IfReminderItemNotReady_ShouldNotRaiseReminderSentEvent(ReminderItemStatus status)
		{
			// Arrange
			var eventRaised = false;
			var storage = new ReminderStorage(
				CreateReminderItem(status: status)
			);
			using var service = new ReminderService(storage, SuccessfullSender, Receiver, ServiceParameters);
			service.ReminderSent += (sender, args) => eventRaised = true;

			// Act
			service.Start();
			WaitTimers();

			// Assert
			Assert.IsFalse(eventRaised);
		}

		[Test]
		public void WhenStart_IfReceivedMessageIsAboutToNotify_ShouldRaiseEvent()
		{
			// Arrange
			var eventRaised = false;
			var message = CreateMessage(datetime: DateTimeOffset.UtcNow.AddMinutes(-1));
			using var service = new ReminderService(Storage, SuccessfullSender, Receiver, ServiceParameters);
			service.ReminderSent += (sender, args) => eventRaised = true;

			// Act
			service.Start();
			Receiver.Emit(message);
			WaitTimers();

			// Assert
			Assert.IsTrue(eventRaised);
		}

		[Test]
		public void WhenStart_IfSenderIsFailed_ShouldRaiseReminderFailedEvent()
		{
			// Arrange
			var eventRaised = false;
			var message = CreateMessage(datetime: DateTimeOffset.UtcNow.AddMinutes(-1));
			using var service = new ReminderService(Storage, FailedSender, Receiver, ServiceParameters);
			service.ReminderFailed += (sender, args) => eventRaised = true;

			// Act
			service.Start();
			Receiver.Emit(message);
			WaitTimers();

			// Assert
			Assert.IsTrue(eventRaised);
		}

		private Message CreateMessage(string message = default, DateTimeOffset? datetime = default) =>
			new Message(message ?? "Some text", datetime ?? DateTimeOffset.UtcNow);

		private ReminderItem CreateReminderItem(DateTimeOffset? datetime = default, ReminderItemStatus status = ReminderItemStatus.Created) =>
			new ReminderItem(Guid.NewGuid(), "Contact", "Message", datetime ?? DateTimeOffset.UtcNow, status);

		private void WaitTimers() => Thread.Sleep(
				2 * (ServiceParameters.CreateTimerDelay + ServiceParameters.ReadyTimerDelay) +
				2 * (ServiceParameters.CreateTimerInterval + ServiceParameters.ReadyTimerInternval)
			);
	}
}
