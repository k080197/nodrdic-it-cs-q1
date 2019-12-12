using System;

namespace Reminder.Sender
{
	public class NotificationException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyException"/> class
		/// </summary>
		public NotificationException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NotificationException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		public NotificationException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NotificationException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		/// <param name="inner">The exception that is the cause of the current exception. </param>
		public NotificationException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
