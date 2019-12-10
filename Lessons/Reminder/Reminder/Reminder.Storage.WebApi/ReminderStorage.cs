using System;
using System.Collections.Generic;

namespace Reminder.Storage.WebApi
{
    public class ReminderStorage : IReminderStorage
    {
        public void Create(ReminderItem item)
        {
            throw new NotImplementedException();
        }

        public List<ReminderItem> FindBy(ReminderItemFilter filter)
        {
            throw new NotImplementedException();
        }

        public ReminderItem FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ReminderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
