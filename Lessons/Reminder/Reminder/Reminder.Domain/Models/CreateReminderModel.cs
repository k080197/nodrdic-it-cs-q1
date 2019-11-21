using System;

namespace Reminder.Domain.Models
{
    public class CreateReminderModel
    {
        public string ContactId { get; set; }
        public string Message { get; set; }
        public DateTimeOffset Datetime { get; set; }

        public CreateReminderModel(
            string contactId,
            string message,
            DateTimeOffset datetime)
        {
            ContactId = contactId;
            Message = message;
            Datetime = datetime;
        }
    }
}
