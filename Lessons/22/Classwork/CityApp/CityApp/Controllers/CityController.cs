using System.Linq;
using CityApp.Models;
using CityApp.Services;
using CityApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;

namespace CityApp.Controllers
{

    // /city/list
    public class CityController : Controller
    {
        [HttpGet("cities/{id}")]
        [HttpGet("api/city/{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var city = CityStorage.Instance.GetById(id);

            if (city == null)
            {
                return NotFound();
            }

            return Json(new DetailCityViewModel(city));
        }

        [HttpGet("cities")]
        public IActionResult List()
        {
            var cities = CityStorage.Instance
                .GetAll()
                .Select(x => new CityViewModel(x))
                .OrderBy(x => x.Name)
                .ToArray();

            return base.Json(cities);
        }

        [HttpPost("cities")]
        [HttpPost("api/city")]
        public IActionResult Create([FromBody] CreateCityViewModel city)
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
            CityStorage.Instance.Create(model);

            return Ok();
        }

        [HttpPut("cities/{id}")]
        [HttpPut("api/city/{id}")]
        public IActionResult Put(Guid id, [FromBody] CreateCityViewModel city)
        {
            if (id == Guid.Empty || city == null)
            {
                return BadRequest();
            }

            var _city = CityStorage.Instance.GetById(id);

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

            CityStorage.Instance.Delete(CityStorage.Instance.GetById(id));

            return Ok();
        }
    }
}
