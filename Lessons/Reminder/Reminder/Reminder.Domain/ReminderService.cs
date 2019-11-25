using System;
using System.Threading;
using Reminder.Sender;
using Reminder.Storage;
using Reminder.Receiver;

namespace Reminder.Domain
{
	public class ReminderService : IDisposable
	{
		public event EventHandler<ItemSentEventArgs> ItemSent;
		public event EventHandler<ItemFailedEventArgs> ItemFailed;

		private readonly IReminderStorage _storage;
		private readonly IReminderSender _sender;
		private readonly IReminderReceiver _receiver;
		private readonly ReminderServiceParameters _parameters;
		private Timer _createdItemTimer;
		private Timer _readyItemTimer;

		public ReminderService(
			IReminderStorage storage,
			IReminderSender sender,
			IReminderReceiver receiver,
			ReminderServiceParameters parameters)
		{
			_storage = storage ?? throw new ArgumentNullException(nameof(storage));
			_sender = sender ?? throw new ArgumentNullException(nameof(sender));
			_receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
			_receiver.MessageReceived += OnMessageReceived;
			_parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
		}

		public void Start()
		{
			_createdItemTimer = new Timer(OnCreatedItemTimerTick, null,
				_parameters.CreateTimerDelay,
				_parameters.CreateTimerInterval);
			_readyItemTimer = new Timer(OnReadyItemTimerTick, null,
				_parameters.ReadyTimerDelay,
				_parameters.ReadyTimerInternval);
		}

		public void Dispose()
		{
			_createdItemTimer.Dispose();
			_readyItemTimer.Dispose();
			_receiver.MessageReceived -= OnMessageReceived;
		}

		private void OnCreatedItemTimerTick(object _)
		{
			var filter = ReminderItemFilter
				.ByStatus(ReminderItemStatus.Created)
				.At(DateTimeOffset.Now);
			var items = _storage.FindBy(filter);

			foreach (var item in items)
			{
				_storage.Update(item.ReadyToSend());
			}
		}

		private void OnReadyItemTimerTick(object _)
		{
			var filter = ReminderItemFilter.ByStatus(ReminderItemStatus.Ready);
			var items = _storage.FindBy(filter);

			foreach (var item in items)
			{
				try
				{
					var notification = new Notification(
						item.ContactId,
						item.Message,
						item.MessageDate);

					_sender.Send(notification);
					OnItemSent(item);
				}
				catch (NotificationException exception)
				{
					OnItemFailed(item, exception);
				}
			}
		}

		private void OnItemSent(ReminderItem item)
		{
			_storage.Update(item.Sent());
			ItemSent?.Invoke(this, new ItemSentEventArgs(item.Id));
		}

		private void OnItemFailed(ReminderItem item, NotificationException exception)
		{
			_storage.Update(item.Failed());
			ItemFailed?.Invoke(this, new ItemFailedEventArgs(item.Id, exception));
		}

		private void OnMessageReceived(object sender, MessageReceivedEventArgs args)
		{
			var item = new ReminderItem(
				Guid.NewGuid(),
				args.ContactId,
				args.Message.Text,
				args.Message.Datetime);

			_storage.Create(item);
		}
	}
}
