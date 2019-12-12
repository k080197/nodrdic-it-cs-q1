using Reminder.Sender;

namespace Reminder.Domain.Tests
{
	public class FakeReminderSender : IReminderSender
	{
		private readonly bool _failed;

		public FakeReminderSender(bool failed)
		{
			_failed = failed;
		}

		public void Send(Notification notification)
		{
			if (_failed)
			{
				throw new NotificationException();
			}
		}
	}
}
