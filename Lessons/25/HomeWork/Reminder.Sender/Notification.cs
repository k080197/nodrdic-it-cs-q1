using System;

namespace Reminder.Sender
{
	public class Notification
	{
		public string ContactId { get; }
		public string Message { get; }
		public DateTimeOffset Datetime { get; }

		public Notification(
			string contactId,
			string message,
			DateTimeOffset datetime)
		{
			ContactId = contactId;
			Message = message;
			Datetime = datetime;
		}
	}
}
