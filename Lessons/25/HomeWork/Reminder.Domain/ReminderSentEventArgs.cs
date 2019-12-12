using System;

namespace Reminder.Domain
{
	public class ReminderSentEventArgs : EventArgs
	{
		public Guid Id { get; }

		public ReminderSentEventArgs(Guid id)
		{
			Id = id;
		}
	}
}
