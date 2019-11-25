using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Reminder.Sender.Telegram
{
	public class ReminderSender : IReminderSender
	{
		private readonly TelegramBotClient _client;

		public ReminderSender(string token)
		{
			_client = new TelegramBotClient(token);
		}

		public void Send(Notification notification)
		{
			try
			{
				var chatId = new ChatId(int.Parse(notification.ContactId));
				var _ = _client.SendTextMessageAsync(chatId, notification.Message).Result;
			}
			catch (Exception ex)
			{
				throw new NotificationException("Не удалось отправить сообщение", ex);
			}
		}
	}
}
