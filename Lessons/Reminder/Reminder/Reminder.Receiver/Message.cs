using System;

namespace Reminder.Receiver
{
	public class Message
	{
		public Message(string text, DateTimeOffset datetime)
		{
			Text = text;
			Datetime = datetime;
		}

		public string Text { get; set; }
		public DateTimeOffset Datetime { get; set; }

		public static (Message message, string error) TryParse(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				return (null, "Строка пустая");
			}

			var separatorIndex = message.IndexOf(",", StringComparison.Ordinal);
			if (separatorIndex < 0)
			{
				return (null, "Отсутствует разделитель");
			}

			var text = message.Substring(0, separatorIndex);
			if (string.IsNullOrWhiteSpace(text))
			{
				return (null, "Отсутствует текст сообщения");
			}

			if (!DateTimeOffset.TryParse(message.Substring(separatorIndex + 1), out var datetime))
			{
				return (null, "Отсуствует дата сообщения");
			}

			return (new Message(text, datetime), null);
		}
	}
}
