using CityApp.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CityApp.Services
{
    public class CityStorage
    {
        private static CityStorage _instance;

        public static CityStorage Instance =>
            _instance ?? (_instance = new CityStorage());
        private CityStorage()
        {
            _cities =
            new List<City>
            {
                new City("Москва", "Столица России", 16_000_000),
                new City("Санкт-Петербург", "Северная столица России", 5_000_000)
            };
        }

        public City[] GetAll()
        {
            return _cities.ToArray();
        }

        public City GetById(Guid id)
        {
            return _cities.FirstOrDefault(x => x.Id == id);
        }

        private readonly List<City> _cities;

        public void Create(City city)
        {
            _cities.Add(city);
        }

        public void Delete(City city)
        {
            _cities.Remove(city);
        }
    }
}
