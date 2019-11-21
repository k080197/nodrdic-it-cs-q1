using System;

namespace Reminder.Storage
{
    public class ReminderItem
    {
        public Guid Id { get; }
        public string ContactId { get; private set; }
        public string Message { get; private set; }
        public DateTimeOffset MessageDate { get; private set; }
        public ReminderItemStatus Status { get; private set; }

        public ReminderItem(
            Guid id,
            string contactId,
            string message,
            DateTimeOffset messageDate,
            ReminderItemStatus status = ReminderItemStatus.Created)
        {
            if (id == default)
            {
                throw new ArgumentException("Идентификатор пустой", nameof(id));
            }
            if (string.IsNullOrWhiteSpace(contactId))
            {
                throw new ArgumentException("Идентификатор контакта пустой", nameof(contactId));
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Сообщение пустое", nameof(message));
            }
            if (messageDate == default)
            {
                throw new ArgumentException("Дата сообщения не задана", nameof(messageDate));
            }

            Id = id;
            ContactId = contactId;
            Message = message;
            MessageDate = messageDate;
            Status = status;
        }

        public ReminderItem ReadyToSend() =>
            UpdateStatus(ReminderItemStatus.Ready, ReminderItemStatus.Created);

        public ReminderItem Sent() =>
            UpdateStatus(ReminderItemStatus.Sent, ReminderItemStatus.Ready);

        public ReminderItem Failed() =>
            UpdateStatus(ReminderItemStatus.Failed, ReminderItemStatus.Ready);

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
