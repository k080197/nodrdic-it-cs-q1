using System;

namespace Reminder.Domain
{
	public class ReminderServiceParameters
	{
		public static ReminderServiceParameters Default =>
			new ReminderServiceParameters(
				TimeSpan.FromSeconds(1),
				TimeSpan.Zero,
				TimeSpan.FromSeconds(1),
				TimeSpan.Zero);

		public ReminderServiceParameters(
			TimeSpan createTimerInterval,
			TimeSpan createTimerDelay,
			TimeSpan readyTimerInterval,
			TimeSpan readyTimerDelay)
		{
			CreateTimerInterval = createTimerInterval;
			CreateTimerDelay = createTimerDelay;
			ReadyTimerInternval = readyTimerInterval;
			ReadyTimerDelay = readyTimerDelay;
		}

		public TimeSpan CreateTimerInterval { get; }
		public TimeSpan CreateTimerDelay { get; }
		public TimeSpan ReadyTimerInternval { get; }
		public TimeSpan ReadyTimerDelay { get; }
	}
}
