using System;
using System.Linq;
using System.Collections.Generic;

namespace Reminder.Storage.Memory
{
	public class ReminderStorage : IReminderStorage
	{
		private readonly Dictionary<Guid, ReminderItem> _dictionary;

		internal ReminderStorage(params ReminderItem[] items)
		{
			_dictionary = items.ToDictionary(item => item.Id);
		}

		public ReminderStorage()
		{
			_dictionary = new Dictionary<Guid, ReminderItem>();
		}

		public void Add(ReminderItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			if (_dictionary.ContainsKey(item.Id))
			{
				throw new ArgumentException($"The element with specified key {item.Id} already exists", nameof(item.Id));
			}

			_dictionary[item.Id] = item;
		}

		public void Update(ReminderItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			if (!_dictionary.ContainsKey(item.Id))
			{
				throw new ArgumentException($"The element with specified key {item.Id} not found", nameof(item.Id));
			}

			_dictionary[item.Id] = item;
		}

		public ReminderItem FindById(Guid id)
		{
			if (id == default)
			{
				throw new ArgumentException(nameof(id));
			}

			if (!_dictionary.TryGetValue(id, out var item))
			{
				throw new ArgumentException($"The element with specified key {id} not found", nameof(id));
			}

			return item;
		}

		public List<ReminderItem> FindBy(ReminderItemFilter filter)
		{
			if (filter == null)
			{
				throw new ArgumentNullException(nameof(filter));
			}

			var result = _dictionary.Values.AsEnumerable();

			if (filter.ByStatus)
			{
				result = result.Where(item => item.Status == filter.Status);
			}

			if (filter.ByDatetime)
			{
				result = result.Where(item => item.DatetimeUtc < filter.DatetimeUtc);
			}

			return result.ToList();
		}
	}
}
