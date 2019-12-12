namespace Reminder.Storage
{
	/// <summary>
	/// The status of Reminder Item
	/// </summary>
	public enum ReminderItemStatus
	{
		/// <summary>
		/// Undefied state
		/// </summary>
		Undefied = 0,

		/// <summary>
		/// Created 
		/// </summary>
		Created,

		/// <summary>
		/// Ready to sent
		/// </summary>
		Ready,

		/// <summary>
		/// Successfully sent
		/// </summary>
		Sent,

		/// <summary>
		/// Error occured while sending reminder item
		/// </summary>
		Failed
	}
}
