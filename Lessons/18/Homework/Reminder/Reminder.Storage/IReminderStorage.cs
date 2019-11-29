using System;
using System.Collections.Generic;

namespace Reminder.Storage
{
	/// <summary>
	///   Определяет основные методы хранилища напоминаний
	/// </summary>
	public interface IReminderStorage
	{
		/// <summary>
		///   Сохраняет новый элемент <see cref="ReminderItem"/>
		/// </summary>
		/// <param name="item">Элемент ReminderItem</param>
		void Create(ReminderItem item);

		/// <summary>
		///   Обновляет данные элемента <see cref="ReminderItem"/>
		/// </summary>
		/// <param name="item">Элемент ReminderItem</param>
		void Update(ReminderItem item);

		/// <summary>
		///   Реализует поиск элемента <see cref="ReminderItem"/> по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор элемента</param>
		/// <returns>Найденный элемент <see cref="ReminderItem"/></returns>
		ReminderItem FindById(Guid id);

		/// <summary>
		///   Возвращает все элементы <see cref="ReminderItem"/> не позднее указанной даты
		/// </summary>
		/// <param name="dateTime">Дата</param>
		/// <returns>Коллекция элементов <see cref="ReminderItem"/></returns>
		List<ReminderItem> FindByDateTime(DateTimeOffset dateTime);
	}
}
