using System;
using Reminder.Sender;

namespace Reminder.Domain.Tests
{
	public class ReminderSenderFake : IReminderSender
	{
		private bool _shouldRaiseError;

		public ReminderSenderFake(bool shouldRaiseError = false)
		{
			_shouldRaiseError = shouldRaiseError;
		}

		public void Send(Notification notification)
		{
			if (_shouldRaiseError)
			{
				throw new NotificationException();
			}
		}
	}
}