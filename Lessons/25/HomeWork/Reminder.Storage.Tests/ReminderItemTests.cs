using NUnit.Framework;
using System;

namespace Reminder.Storage.Tests
{
	public class ReminderItemTests
	{
		[Test]
		public void WhenConstruct_IfEmptyIdSpecified_ShouldThrow()
		{
			// Act-Assert
			Assert.Catch<ArgumentException>(() =>
				new ReminderItem(
					id: default,
					contactId: "contact",
					message: "message",
					datetimeUtc: DateTimeOffset.UtcNow)
			);
		}

		[Test]
		public void WhenConstruct_IfEmptyContactIdSpecified_ShouldThrow()
		{
			// Act-Assert
			Assert.Catch<ArgumentException>(() =>
				new ReminderItem(
					id: Guid.NewGuid(),
					contactId: default,
					message: "message",
					datetimeUtc: DateTimeOffset.UtcNow)
			);
		}

		[Test]
		public void WhenConstruct_IfEmptyMessageSpecified_ShouldThrow()
		{
			// Act-Assert
			Assert.Catch<ArgumentException>(() =>
				new ReminderItem(
					id: Guid.NewGuid(),
					contactId: "contact",
					message: default,
					datetimeUtc: DateTimeOffset.UtcNow)
			);
		}

		[Test]
		public void WhenConstruct_IfEmptyDatetimeSpecified_ShouldThrow()
		{
			// Act-Assert
			Assert.Catch<ArgumentException>(() =>
				new ReminderItem(
					id: Guid.NewGuid(),
					contactId: "contact",
					message: "message",
					datetimeUtc: default)
			);
		}

		[TestCase(ReminderItemStatus.Ready)]
		[TestCase(ReminderItemStatus.Sent)]
		[TestCase(ReminderItemStatus.Failed)]
		public void WhenReadyToSent_IfInvalidStateSpecified_ShouldThrow(ReminderItemStatus initialState)
		{
			// Arrange
			var item = new ReminderItem(Guid.NewGuid(), "Contact", "Message", DateTimeOffset.UtcNow, initialState);

			// Act-Assert
			Assert.Catch<InvalidOperationException>(() => item.ReadyToSend());
		}

		[Test]
		public void WhenReadyToSent_IfValidStatusSpecified_ShouldUpdateStatus()
		{
			// Assert
			var item = new ReminderItem(Guid.NewGuid(), "Contact", "Message", DateTimeOffset.UtcNow, ReminderItemStatus.Created);

			// Act
			item.ReadyToSend();

			// Assert
			Assert.AreEqual(ReminderItemStatus.Ready, item.Status);
		}
	}
}