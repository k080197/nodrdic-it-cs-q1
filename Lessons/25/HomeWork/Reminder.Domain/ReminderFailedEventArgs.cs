using System;
using Reminder.Sender;

namespace Reminder.Domain
{
	public class ReminderFailedEventArgs : EventArgs
	{
		public Guid Id { get; }
		public NotificationException Exception { get; }

		public ReminderFailedEventArgs(Guid id, NotificationException exception)
		{
			Id = id;
			Exception = exception;
		}
	}
}
