namespace Reminder.Receiver
{
	public class MessageReceivedEventArgs
	{
		public string ContactId { get; }
		public Message Message { get; }

		public MessageReceivedEventArgs(string contactId, Message message)
		{
			ContactId = contactId;
			Message = message;
		}
	}
}
