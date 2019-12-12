namespace Reminder.Sender
{
	public interface IReminderSender
	{
		void Send(Notification notification);
	}
}
