using System;

namespace Reminder.Domain
{
	public class ItemSentEventArgs : EventArgs
	{
		public Guid Id { get; }

		public ItemSentEventArgs(Guid id)
		{
			Id = id;
		}
	}
}
