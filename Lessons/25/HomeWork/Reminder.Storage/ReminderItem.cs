using System;

namespace Reminder.Storage
{
	/// <summary>
	/// The single Reminder Item
	/// </summary>
	public class ReminderItem : IEquatable<ReminderItem>
	{
		/// <summary>
		/// The unique identity
		/// </summary>
		public Guid Id { get; }

		/// <summary>
		/// The Contact Identifier
		/// </summary>
		public string ContactId { get; private set; }

		/// <summary>
		/// The actual message associated with remider item
		/// </summary>
		public string Message { get; private set; }

		/// <summary>
		/// The sending date and time in UTC
		/// </summary>
		public DateTimeOffset DatetimeUtc { get; private set; }

		/// <summary>
		/// The sending time in UTC
		/// </summary>
		public TimeSpan SendTimeUtc =>
			DatetimeUtc - DateTimeOffset.UtcNow;

		/// <summary>
		/// The status of reminder item
		/// </summary>
		public ReminderItemStatus Status { get; private set; }

		/// <summary>
		/// Initialize new instance of Reminder Item
		/// </summary>
		public ReminderItem(
			Guid id,
			string contactId,
			string message,
			DateTimeOffset datetimeUtc,
			ReminderItemStatus status = ReminderItemStatus.Created)
		{
			if (id == default)
			{
				throw new ArgumentException("The identity is empty", nameof(id));
			}
			if (string.IsNullOrWhiteSpace(contactId))
			{
				throw new ArgumentException("The contact id is empty", nameof(contactId));
			}
			if (string.IsNullOrWhiteSpace(message))
			{
				throw new ArgumentException("The message is empty", nameof(message));
			}
			if (datetimeUtc == default)
			{
				throw new ArgumentException("The message DateTime is empty", nameof(datetimeUtc));
			}

			Id = id;
			ContactId = contactId;
			Message = message;
			DatetimeUtc = datetimeUtc;
			Status = status;
		}

		/// <summary>
		/// Update status to <see cref="ReminderItemStatus.Ready"/>
		/// </summary>
		public ReminderItem ReadyToSend() =>
			UpdateStatus(ReminderItemStatus.Ready, ReminderItemStatus.Created);

		/// <summary>
		/// Update status to <see cref="ReminderItemStatus.Sent"/>
		/// </summary>
		public ReminderItem Sent() =>
			UpdateStatus(ReminderItemStatus.Sent, ReminderItemStatus.Ready);

		/// <summary>
		/// Update status to <see cref="ReminderItemStatus.Failed"/>
		/// </summary>
		public ReminderItem Failed() =>
			UpdateStatus(ReminderItemStatus.Failed, ReminderItemStatus.Ready);

		public bool Equals(ReminderItem other)
		{
			if (other == default)
			{
				return false;
			}

			return
				Id == other.Id &&
				ContactId == other.ContactId &&
				Message == other.Message &&
				DatetimeUtc.ToUnixTimeMilliseconds() == other.DatetimeUtc.ToUnixTimeMilliseconds() &&
				Status == other.Status;
		}

		private ReminderItem UpdateStatus(
			ReminderItemStatus updatedStatus,
			ReminderItemStatus currentStatus)
		{
			if (Status != currentStatus)
			{
				throw new InvalidOperationException(
					$"Операция недопустим для текущего статуса: {Status}, необходимый статус: {currentStatus}");
			}

			Status = updatedStatus;
			return this;
		}
	}
}
