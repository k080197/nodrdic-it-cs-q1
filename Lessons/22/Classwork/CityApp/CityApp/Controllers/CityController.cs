using System.Linq;
using CityApp.Models;
using CityApp.Services;
using CityApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using Microsoft.Extensions.Logging;

namespace CityApp.Controllers
{

    // /city/list
    public class CityController : Controller
    {
        private ILogger _logger;
        private CityStorage _storage;

        public CityController(ILogger logger, CityStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        [HttpGet("cities/{id}")]
        [HttpGet("api/city/{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var city = _storage.GetById(id);

            if (city == null)
            {
                return NotFound();
            }

            return Json(new DetailCityViewModel(city));
        }

        [HttpGet("cities")]
        public IActionResult List()
        {
            var cities = _storage
                .GetAll()
                .Select(x => new CityViewModel(x))
                .OrderBy(x => x.Name)
                .ToArray();

            return base.Json(cities);
        }

        [HttpPost("cities")]
        [HttpPost("api/city")]
        public IActionResult Create([FromBody] CreateOrUpdateCityViewModel city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                var models = ModelState
                    .Select(pair => new ValidationErrorViewModel(pair.Key, pair.Value));

                return BadRequest(new { Properties = models });
            }
            
            var model = new City(
                city.Name,
                city.Description,
                city.Population);
            _storage.Create(model);

            return Ok();
        }

        [HttpPut("cities/{id}")]
        [HttpPut("api/city/{id}")]
        public IActionResult Put(Guid id, [FromBody] CreateOrUpdateCityViewModel city)
        {
            if (id == Guid.Empty || city == null)
            {
                return BadRequest();
            }

            var _city = _storage.GetById(id);

            _city.Name = city.Name;
            _city.Description = city.Description;
            _city.Population = city.Population;

            return Ok();
        }

        [HttpDelete("cities/{id}")]
        [HttpDelete("api/city/{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            _storage.Delete(_storage.GetById(id));

            return Ok();
        }
    }
}
