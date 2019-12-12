using System;

namespace Reminder.Receiver
{
	public class Message
	{
		public string Text { get; }
		public DateTimeOffset Datetime { get; }

		public Message(string text, DateTimeOffset datetime)
		{
			Text = text;
			Datetime = datetime;
		}

		public static (Message message, string error) TryParse(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				return (null, "The string is empty or whitespace");
			}

			var separatorIndex = message.IndexOf(",", StringComparison.Ordinal);
			if (separatorIndex < 0)
			{
				return (null, "Missing divisor");
			}

			var text = message.Substring(0, separatorIndex);
			if (string.IsNullOrWhiteSpace(text))
			{
				return (null, "The message text is empty");
			}

			if (!DateTimeOffset.TryParse(message.Substring(separatorIndex + 1), out var datetime))
			{
				return (null, "The message datetime is ivalid");
			}

			return (new Message(text, datetime), null);
		}
	}
}
