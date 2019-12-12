using System;
using Reminder.Storage;

namespace Reminder.WebApi.ViewModels
{
	public class ReminderItemFilterViewModel
	{
		public DateTimeOffset DateTime { get; set; }

		public ReminderItemStatus Status { get; set; }
	}
}
