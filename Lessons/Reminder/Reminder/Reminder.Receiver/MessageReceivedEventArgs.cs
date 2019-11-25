namespace Reminder.Receiver
{
	public class MessageReceivedEventArgs
	{
		public MessageReceivedEventArgs(string contactId, Message message)
		{
			ContactId = contactId;
			Message = message;
		}

		public string ContactId { get; set; }
		public Message Message { get; set; }
	}
}
