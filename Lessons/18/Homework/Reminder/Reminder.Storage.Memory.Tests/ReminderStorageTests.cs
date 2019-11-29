using System;
using NUnit.Framework;

namespace Reminder.Storage.Memory.Tests
{
	public class ReminderStorageTests
	{
		// WhenUnit_IfCondition_ShouldExpectedResult

		[Test]
		public void WhenCreate_IfEmptyStorage_ShouldFindItemById()
		{
			// Arrange
			var item = CreateReminderItem();
			var storage = new ReminderStorage();

			// Act
			storage.Create(item);

			// Assert
			var result = storage.FindById(item.Id);
			Assert.AreEqual(item.Id, result.Id);
		}

		[Test]
		public void WhenCreate_IfNullSpecified_ShouldThrowException()
		{
			// Arrange
			var storage = new ReminderStorage();

			// Act-Assert
			Assert.Catch<ArgumentNullException>(() =>
				storage.Create(null)
			);
		}

		[Test]
		public void WhenCreate_IfExistsElementWithKey_ShouldThrowException()
		{
			// Arrange
			var item = CreateReminderItem();
			var storage = new ReminderStorage(
				item
			);

			// Act-Assert
			Assert.Catch<ArgumentException>(() =>
				storage.Create(item)
			);
		}

		private ReminderItem CreateReminderItem(
			Guid? id = default,
			string contactId = default,
			string message = default,
			DateTimeOffset? messageDate = default)
		{
			if (!id.HasValue)
			{
				id = Guid.NewGuid();
			}
			if (contactId == null)
			{
				contactId = "123";
			}
			if (message == null)
			{
				message = "Some text";
			}
			if (!messageDate.HasValue)
			{
				messageDate = DateTimeOffset.UtcNow;
			}
			return new ReminderItem(id.Value, contactId, message, messageDate.Value);
		}
	}
}