using System;
using System.Threading;
using Reminder.Receiver;
using Reminder.Sender;
using Reminder.Storage;

namespace Reminder.Domain
{
	public class ReminderService : IDisposable
	{
		public event EventHandler<ReminderSentEventArgs> ReminderSent;
		public event EventHandler<ReminderFailedEventArgs> ReminderFailed;

		private readonly IReminderStorage _storage;
		private readonly IReminderSender _sender;
		private readonly IReminderReceiver _receiver;
		private readonly ReminderServiceParameters _parameters;
		private Timer _createdTimer;
		private Timer _readyTimer;

		public ReminderService(
			IReminderStorage storage,
			IReminderSender sender,
			IReminderReceiver receiver,
			ReminderServiceParameters parameters)
		{
			_storage = storage ?? throw new ArgumentNullException(nameof(storage));
			_sender = sender ?? throw new ArgumentNullException(nameof(sender));
			_receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
			_parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
		}

		public void Start()
		{
			_createdTimer = new Timer(OnCreatedTimerTick, null,
				_parameters.CreateTimerDelay,
				_parameters.CreateTimerInterval);
			_readyTimer = new Timer(OnReadyTimerTick, null,
				_parameters.ReadyTimerDelay,
				_parameters.ReadyTimerInternval);
			_receiver.MessageReceived += OnMessageReceived;
		}

		public void Dispose()
		{
			_receiver.MessageReceived -= OnMessageReceived;
			_createdTimer.Dispose();
			_readyTimer.Dispose();
		}

		private void OnCreatedTimerTick(object _)
		{
			var filter = new ReminderItemFilter(DateTimeOffset.UtcNow, ReminderItemStatus.Created);
			var items = _storage.FindBy(filter);

			foreach (var item in items)
			{
				_storage.Update(item.ReadyToSend());
			}
		}

		private void OnReadyTimerTick(object _)
		{
			var filter = new ReminderItemFilter(status: ReminderItemStatus.Ready);
			var items = _storage.FindBy(filter);

			foreach (var item in items)
			{
				try
				{
					var notification = new Notification(
						item.ContactId,
						item.Message,
						item.DatetimeUtc);

					_sender.Send(notification);
					OnReminderSent(item);
				}
				catch (NotificationException exception)
				{
					OnReminderFailed(item, exception);
				}
			}
		}

		private void OnReminderSent(ReminderItem item)
		{
			_storage.Update(item.Sent());
			ReminderSent?.Invoke(this, new ReminderSentEventArgs(item.Id));
		}

		private void OnReminderFailed(ReminderItem item, NotificationException exception)
		{
			_storage.Update(item.Failed());
			ReminderFailed?.Invoke(this, new ReminderFailedEventArgs(item.Id, exception));
		}

		private void OnMessageReceived(object sender, MessageReceivedEventArgs args)
		{
			var item = new ReminderItem(
				Guid.NewGuid(),
				args.ContactId,
				args.Message.Text,
				args.Message.Datetime);

			_storage.Add(item);
		}
	}
}
