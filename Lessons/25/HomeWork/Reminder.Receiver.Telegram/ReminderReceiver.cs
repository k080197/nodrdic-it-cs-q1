using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Reminder.Receiver.Telegram
{
	public class ReminderReceiver : IReminderReceiver
	{
		public event EventHandler<MessageReceivedEventArgs> MessageReceived;

		private readonly TelegramBotClient _client;

		public ReminderReceiver(string token)
		{
			_client = new TelegramBotClient(token);
			_client.OnMessage += OnMessage;
			_client.StartReceiving();
		}

		private void OnMessage(object sender, MessageEventArgs args)
		{
			var contactId = args.Message.From.Id.ToString();
			var (message, error) = Message.TryParse(args.Message.Text);

			if (!string.IsNullOrWhiteSpace(error))
			{
				_client.SendTextMessageAsync(new ChatId(contactId), error);
			}
			else
			{
				MessageReceived?.Invoke(this, new MessageReceivedEventArgs(contactId, message));
			}
		}
	}
}
