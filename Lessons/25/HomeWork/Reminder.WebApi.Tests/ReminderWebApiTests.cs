using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Reminder.Storage;
using Reminder.Storage.WebApi;

namespace Reminder.WebApi.Tests
{
	// Microsoft.AspNetCore.TestHost

	public class ReminderWebApiTests
	{
		public IHost TestHost { get; private set; }
			
		public HttpClient TestClient { get; private set; }

		[SetUp]
		public void Setup()
		{
			TestHost = new HostBuilder()
				.ConfigureWebHost(webhost => webhost
					.UseStartup<Startup>()
					.UseTestServer())
				.Start();
			TestClient = TestHost.GetTestClient();
		}

		[Test]
		public void WhenCreate_IfSpecifiedValidBody_ShouldRetulnResult()
		{
			// Arrange
			var storage = new ReminderStorage(TestClient);

			// Act
			var item = new ReminderItem(Guid.NewGuid(), "ContactId", "Message", DateTimeOffset.UtcNow);
			storage.Add(item);

			// Assert
			var actualItem = storage.FindById(item.Id);
			Assert.AreEqual(item, actualItem);
		}
	}
}