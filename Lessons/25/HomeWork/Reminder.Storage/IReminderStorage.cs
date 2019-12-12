using System;
using System.Collections.Generic;

namespace Reminder.Storage
{
	/// <summary>
	///   The Reminder Items storage interface
	/// </summary>
	public interface IReminderStorage
	{
		/// <summary>
		///   Add new element to internal storage system <see cref="ReminderItem"/>
		/// </summary>
		/// <param name="item">The ReminderItem</param>
		void Add(ReminderItem item);

		/// <summary>
		///   Update Reminder Item stage in internal storage system<see cref="ReminderItem"/>
		/// </summary>
		/// <param name="item">Элемент ReminderItem</param>
		void Update(ReminderItem item);

		/// <summary>
		///   Find one of <see cref="ReminderItem"/> with specified identity
		/// </summary>
		/// <param name="id">The Reminder Item Id</param>
		/// <returns>Founded reminder item<see cref="ReminderItem"/></returns>
		ReminderItem FindById(Guid id);

		/// <summary>
		///   Find all reminder items <see cref="ReminderItem" /> matching specified filter
		/// </summary>
		/// <param name="filter">The filter object <see cref="ReminderItemFilter" /></param>
		/// <returns>The reminder items collection <see cref="ReminderItem" /></returns>
		List<ReminderItem> FindBy(ReminderItemFilter filter);
	}
}
