using System;
using Reminder.Receiver;

namespace Reminder.Domain.Tests
{
	public class FakeReminderReceiver : IReminderReceiver
	{
		public event EventHandler<MessageReceivedEventArgs> MessageReceived;

		public void Emit(Message message) => 
			MessageReceived?.Invoke(this, new MessageReceivedEventArgs("contact", message));
	}
}
