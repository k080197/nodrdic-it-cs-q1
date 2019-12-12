using Reminder.Storage;

namespace Reminder.WebApi.ViewModels
{
	public class ReminderItemViewModel
	{
		public string Id { get; set; }

		public string ContactId { get; set; }

		public string Message { get; set; }

		public long DateTimeUtc { get; set; }

		public int Status { get; set; }

		public ReminderItemViewModel(ReminderItem item)
		{
			Id = item.Id.ToString("N");
			ContactId = item.ContactId;
			Message = item.Message;
			DateTimeUtc = item.DatetimeUtc.ToUnixTimeMilliseconds();
			Status = (int) item.Status;
		}
	}
}
