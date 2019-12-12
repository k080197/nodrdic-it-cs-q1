using NUnit.Framework;
namespace Reminder.Receiver.Tests
{
	public class MessageTests
	{
		[TestCase("")]
		[TestCase("     ")]
		[TestCase("      ,       ")]
		[TestCase("    ,   asas")]
		[TestCase("text, ")]
		[TestCase("  , 2018.11.12 14:00:00")]
		public void TryParse_IfFormatInvalid_ShouldReturnError(string text)
		{
			// Arrange-Act
			var (message, error) = Message.TryParse(text);

			// Assert
			Assert.Null(message);
			Assert.NotNull(error);
		}

		[TestCase("message, 2018.11.12 14:00:00")]
		public void TryParse_IfFormatValid_ShouldReturnMessage(string text)
		{
			// Arrange-Act
			var (message, error) = Message.TryParse(text);

			// Assert
			Assert.NotNull(message);
			Assert.Null(error);
		}
	}
}
