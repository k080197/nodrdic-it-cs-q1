using Reminder.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.WebApi.ViewModels
{
    public class ReminderFilterViewModel
    {
        public ReminderItemStatus? Status { get; set; }

        public DateTimeOffset? DateTime { get; set; }
    }
}
