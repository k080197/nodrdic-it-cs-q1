using System;

namespace Reminder.Sender
{
	public class Notification
	{
		public string ContactId { get; set; }
		public string Message { get; set; }
		public DateTimeOffset Datetime { get; set; }

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
