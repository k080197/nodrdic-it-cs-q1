using System;
using Reminder.Receiver;

namespace Reminder.Domain.Tests
{
	public class ReminderReceiverFake : IReminderReceiver
	{
		public event EventHandler<MessageReceivedEventArgs> MessageReceived;

		public void Emit(
			string contactId = default,
			string message = default,
			DateTimeOffset datetime = default)
		{
			if (contactId == default)
			{
				contactId = "ContactId";
			}
			if (message == default)
			{
				message = "Message";
			}
			if (datetime == default)
			{
                datetime = DateTimeOffset.UtcNow;
			}

			var args = new MessageReceivedEventArgs(
				contactId,
				new Message(message, datetime));
			MessageReceived?.Invoke(this, args);
		}
	}
}