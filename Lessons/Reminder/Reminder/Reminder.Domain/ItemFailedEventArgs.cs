using System;
using Reminder.Sender;

namespace Reminder.Domain
{
	public class ItemFailedEventArgs : EventArgs
	{
		public Guid Id { get; }
		public NotificationException Exception { get; set; }

		public ItemFailedEventArgs(Guid id, NotificationException exception)
		{
			Id = id;
			Exception = exception;
		}
	}
}
