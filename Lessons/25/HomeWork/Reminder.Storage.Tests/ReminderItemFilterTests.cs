using System;
using NUnit.Framework;

namespace Reminder.Storage.Tests
{
	public class ReminderItemFilterTests
	{
		[Test]
		public void WhenConstruct_IfDatetimeSpecified_FilterByDatetimeShouldBeTrue()
		{
			// Arrange-Act
			var filter = new ReminderItemFilter(datetimeUtc: DateTimeOffset.UtcNow);

			// Assert
			Assert.IsTrue(filter.ByDatetime);
		}

		[Test]
		public void WhenConstruct_IfStatus_FilterByStatusShouldBeTrue()
		{
			// Arrange-Act
			var filter = new ReminderItemFilter(status: ReminderItemStatus.Created);

			// Assert
			Assert.IsTrue(filter.ByStatus);
		}
	}
}
