using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Storage;
using Reminder.WebApi.ViewModels;

namespace Reminder.WebApi.Controllers
{
	[Route("api/reminders")]
	public class ReminderController : Controller
	{
		private readonly ILogger _logger;
		private readonly IReminderStorage _storage;

		public ReminderController(ILogger<ReminderController> logger, IReminderStorage storage)
		{
			_logger = logger;
			_storage = storage;
		}

		[HttpGet("{id}", Name = nameof(GetById))]
		public IActionResult GetById(Guid id)
		{
			if (id == default)
			{
				return BadRequest();
			}

			var item = _storage.FindById(id);
			if (item == default)
			{
				return NotFound();
			}

			var model = new ReminderItemViewModel(item);
			return Ok(model);
		}

		[HttpGet(Name = nameof(GetAll))]
		public IActionResult GetAll([FromQuery] ReminderItemFilterViewModel filter)
		{
			if (filter == default)
			{
				return BadRequest();
			}

			var items = _storage.FindBy(
				new ReminderItemFilter(
					datetimeUtc: filter.DateTime,
					status: filter.Status
				)
			);
			var models = items.Select(_ => new ReminderItemViewModel(_));
			return Ok(models);
		}

		[HttpPost(Name = nameof(Create))]
		public IActionResult Create([FromBody] CreateReminderItemViewModel model)
		{
			if (model == default)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var item = new ReminderItem(
				model.Id ?? Guid.NewGuid(),
				model.ContactId,
				model.Message,
				model.DateTimeUtc);

			_storage.Add(item);

			return CreatedAtRoute(nameof(GetById), new { item.Id }, new ReminderItemViewModel(item));
		}

		[HttpPut("{id}", Name = nameof(Update))]
		public IActionResult Update(Guid id, [FromBody] UpdateReminderItemViewModel model)
		{
			if (id == default ||
				model == default)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existsItem = _storage.FindById(id);
			if (existsItem == default)
			{
				return NotFound();
			}

			var item = new ReminderItem(
				id,
				model.ContactId,
				model.Message,
				model.DateTimeUtc,
				model.Status);

			_storage.Update(item);

			return Ok();
		}
	}
}
