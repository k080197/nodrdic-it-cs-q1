using System;
using NUnit.Framework;

namespace Reminder.Storage.Memory.Tests
{
	public class ReminderStorageTests
	{
		// Tests naming
		// WhenUnit_IfCondition_ShouldExpectedResult

		[Test]
		public void WhenAdd_IfEmptyStorage_ShouldFindItemById()
		{
			// Arrange
			var item = CreateReminderItem();
			var storage = new ReminderStorage();

			// Act
			storage.Add(item);

			// Assert
			var result = storage.FindById(item.Id);
			Assert.AreEqual(item.Id, result.Id);
		}

		[Test]
		public void WhenAdd_IfNullSpecified_ShouldThrowException()
		{
			// Arrange
			var storage = new ReminderStorage();

			// Act-Assert
			Assert.Catch<ArgumentNullException>(() =>
				storage.Add(null)
			);
		}

		[Test]
		public void WhenAdd_IfExistsElementWithSameKey_ShouldThrowException()
		{
			// Arrange
			var item = CreateReminderItem();
			var storage = new ReminderStorage(item);

			// Act-Assert
			Assert.Catch<ArgumentException>(() =>
				storage.Add(item)
			);
		}

		[Test]
		public void WhenUpdate_IfNullSpecified_ShouldThrowException()
		{
			// Arrange
			var storage = new ReminderStorage();

			// Act-Assert
			Assert.Catch<ArgumentNullException>(() =>
				storage.Update(null)
			);
		}

		[Test]
		public void WhenUpdate_IfElementNotFound_ShouldThrow()
		{
			// Arrange
			var item = CreateReminderItem();
			var storage = new ReminderStorage();

			// Act-Assert
			Assert.Catch<ArgumentException>(() =>
				storage.Update(item)
			);
		}

		[Test]
		public void WhenUpdate_IfElementExists_ShouldReturnUpdatedVersion()
		{
			// Arrange
			var id = Guid.NewGuid();
			var item = CreateReminderItem(id: id, message: "updated message");
			var storage = new ReminderStorage(
				CreateReminderItem(id: id, message: "old message")
			);

			// Act
			storage.Update(item);

			// Assert
			Assert.AreEqual("updated message", storage.FindById(id).Message);
		}

		[Test]
		public void WhenFindById_IfEmptyIdSpecified_ShouldThrowException()
		{
			// Arrange
			var storage = new ReminderStorage();

			// Act-Assert
			Assert.Catch<ArgumentException>(() =>
				storage.FindById(default)
			);
		}

		[Test]
		public void WhenFindById_IfItemNotFound_ShouldThrowException()
		{
			// Arrange
			var storage = new ReminderStorage();

			// Act-Assert
			Assert.Catch<ArgumentException>(() =>
				storage.FindById(Guid.NewGuid())
			);
		}

		[Test]
		public void WhenFindById_IfItemExists_ShouldReturnIt()
		{
			// Arrange
			var id = Guid.NewGuid();
			var storage = new ReminderStorage(
				CreateReminderItem(id: id)
			);

			// Act
			var item = storage.FindById(id);

			// Assert
			Assert.AreEqual(id, item.Id);
		}

		[Test]
		public void WhenFindBy_IfNullSpecified_ShouldThrowException()
		{
			// Arrange
			var storage = new ReminderStorage();

			// Act-Assert
			Assert.Catch<ArgumentNullException>(() =>
				storage.FindBy(null)
			);
		}

		[TestCase("", ReminderItemStatus.Undefied, 4)]
		[TestCase("", ReminderItemStatus.Ready, 2)]
		[TestCase("now", ReminderItemStatus.Undefied, 2)]
		[TestCase("now", ReminderItemStatus.Created, 1)]
		public void WhenFindBy_IfItemsExists_ShouldReturnMatchingElements(string datetime, ReminderItemStatus status, int expectedItems)
		{
			// Arrange
			var now = DateTimeOffset.UtcNow;
			var filter = new ReminderItemFilter(datetime == "now" ? now : default, status);
			var storage = new ReminderStorage(
				CreateReminderItem(status: ReminderItemStatus.Created, datetime: now.AddMinutes(-1)),
				CreateReminderItem(status: ReminderItemStatus.Ready, datetime: now.AddMinutes(-1)),
				CreateReminderItem(status: ReminderItemStatus.Created, datetime: now.AddMinutes(1)),
				CreateReminderItem(status: ReminderItemStatus.Ready, datetime: now.AddMinutes(1))
			);

			// Act
			var items = storage.FindBy(filter);

			// Assert
			Assert.AreEqual(expectedItems, items.Count);
		}

		private ReminderItem CreateReminderItem(
			Guid? id = default,
			string contactId = default,
			string message = default,
			DateTimeOffset? datetime = default,
			ReminderItemStatus? status = default)
		{
			return new ReminderItem(
				id ?? Guid.NewGuid(), 
				contactId ?? "123", 
				message ?? "message", 
				datetime ?? DateTimeOffset.UtcNow,
				status ?? ReminderItemStatus.Created);
		}
	}
}