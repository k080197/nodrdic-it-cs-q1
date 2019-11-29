using System;
using System.Linq;
using System.Collections.Generic;

namespace Reminder.Storage.Memory
{
	public class ReminderStorage : IReminderStorage
	{
		private readonly Dictionary<Guid, ReminderItem> _map;

		internal ReminderStorage(params ReminderItem[] items)
		{
			_map = items.ToDictionary(item => item.Id);
		}

		public ReminderStorage()
		{
			_map = new Dictionary<Guid, ReminderItem>();
		}

		public void Create(ReminderItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			if (_map.ContainsKey(item.Id))
			{
				throw new ArgumentException($"Уже существует элемент с идентификатором {item.Id}");
			}

			// 
			_map[item.Id] = item;
		}

		public List<ReminderItem> FindByDateTime(DateTimeOffset dateTime)
		{
            var ReminderList = new List<ReminderItem>();

            foreach (var item in _map)
            {
                if (item.Value.MessageDate == dateTime)
                {
                    ReminderList.Add(item.Value);
                }
            }

            return ReminderList;
		}

		public ReminderItem FindById(Guid id)
		{
			if (!_map.ContainsKey(id))
			{
				throw new ArgumentException($"Не найден элемент с ключом {id}", nameof(id));
			}

			return _map[id];
		}

		public void Update(ReminderItem item)
		{
			throw new NotImplementedException();
		}
	}
}
