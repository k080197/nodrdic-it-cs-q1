using System;
using Reminder.Storage;

namespace Reminder.Domain.Models
{
    public class NotifyReminderModel
    {
        public string ContactId { get; set; }
        public string Message { get; set; }
        public DateTimeOffset Datetime { get; set; }

        public NotifyReminderModel(ReminderItem item)
        {
            Message = item.Message;
            ContactId = item.ContactId;
        }
    }
}
