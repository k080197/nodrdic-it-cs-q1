using System;
using System.ComponentModel.DataAnnotations;
using Reminder.Storage;

namespace Reminder.WebApi.ViewModels
{
	public class CreateReminderItemViewModel
	{
		public Guid? Id { get; set; }

		[Required]
		[MaxLength(256)]
		public string ContactId { get; set; }

		[Required]
		[MaxLength(2048)]
		public string Message { get; set; }

		// todo: Add validation attribute
		public DateTimeOffset DateTimeUtc { get; set; }

		public ReminderItemStatus Status { get; set; }
	}
}
