using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Reminder.Storage.WebApi
{
	internal static class Converter
	{
		public static StringContent ToContent<T>(this T item)
		{
			var json = JsonSerializer.Serialize<T>(item);
			return new StringContent(json, Encoding.UTF8, "application/json");
		}

		public static T ToObject<T>(this HttpContent content)
		{
			var json = content.ReadAsStringAsync()
				.GetAwaiter()
				.GetResult();
			var properties = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};
			var result = JsonSerializer.Deserialize<T>(json, properties);
			return result;
		}

		public static ReminderItem ToItem(this ReminderItemRaw source)
		{
			return new ReminderItem(
				Guid.Parse(source.Id),
				source.ContactId,
				source.Message,
				DateTimeOffset.FromUnixTimeMilliseconds(source.DateTimeUtc),
				(ReminderItemStatus)source.Status);
		}
	}
}
