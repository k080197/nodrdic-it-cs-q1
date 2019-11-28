using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityApp.Controllers
{
    // Обработка логики по управлению городами

    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
    }

    public class CityStorage
    {
        public List<City> Cities { get; } =
            new List<City>
            {
                new City
                {
                    Id = Guid.NewGuid(),
                    Name = "Москва",
                    Population = 16_000_000
                },
                new City
                {
                    Id = Guid.NewGuid(),
                    Name = "Екатеринбург",
                    Population = 3_000_000
                },
                new City
                {
                    Id = Guid.NewGuid(),
                    Name = "Санкт-Петербург",
                    Population = 5_000_000
                }
            };
    }

    // /city/list
    public class CityController : Controller
    {
        public IActionResult List()
        {
            var storage = new CityStorage();
            var cities = storage.Cities;
            var json = Json(cities);

            return json;
        }
    }
}
