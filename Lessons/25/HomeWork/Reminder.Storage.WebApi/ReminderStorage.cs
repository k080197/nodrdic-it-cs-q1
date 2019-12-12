using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Reminder.Storage.WebApi
{
	internal class ReminderItemRaw
	{
		public string Id { get; set; }

		public string ContactId { get; set; }

		public string Message { get; set; }

		public long DateTimeUtc { get; set; }

		public int Status { get; set; }
	}

	public class ReminderStorage : IReminderStorage
	{
		private readonly HttpClient _client;

		public ReminderStorage(HttpClient client)
		{
			_client = client;
		}

		// POST /api/remidners
		public void Add(ReminderItem item)
		{
			var response = Execute("/api/reminders", HttpMethod.Post, item.ToContent());
			response.EnsureSuccessStatusCode();
		}

		// GET /api/remidners?status=
		public List<ReminderItem> FindBy(ReminderItemFilter filter)
		{
			var response = Execute($"/api/reminders?status={filter.Status}&datetime={filter.DatetimeUtc}", HttpMethod.Get);
			response.EnsureSuccessStatusCode();

			return response.Content.ToObject<List<ReminderItem>>();
		}

		// GET /api/remidners/id
		public ReminderItem FindById(Guid id)
		{
			var response = Execute($"/api/reminders/{id}", HttpMethod.Get);
			response.EnsureSuccessStatusCode();

			return response.Content.ToObject<ReminderItemRaw>().ToItem();
		}

		// PUT /api/remidners/id
		public void Update(ReminderItem item)
		{
			var response = Execute($"/api/reminders/{item.Id}", HttpMethod.Put, item.ToContent());
			response.EnsureSuccessStatusCode();
		}

		private HttpResponseMessage Execute(
			string url,
			HttpMethod method,
			StringContent content = default)
		{
			var request = new HttpRequestMessage(method, url)
			{
				Content = content
			};

			var response = _client.SendAsync(request)
				.GetAwaiter()
				.GetResult();

			return response;
		}
	}
}
