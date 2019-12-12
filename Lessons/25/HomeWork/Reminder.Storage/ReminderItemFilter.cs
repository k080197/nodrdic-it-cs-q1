using System;

namespace Reminder.Storage
{
	public class ReminderItemFilter
	{
		public DateTimeOffset DatetimeUtc { get; }

		public ReminderItemStatus Status { get; }

		public bool ByDatetime =>
			DatetimeUtc != default;

		public bool ByStatus =>
			Status != ReminderItemStatus.Undefied;

		public ReminderItemFilter(
			DateTimeOffset datetimeUtc = default,
			ReminderItemStatus status = ReminderItemStatus.Undefied)
		{
			DatetimeUtc = datetimeUtc;
			Status = status;
		}
	}
}
