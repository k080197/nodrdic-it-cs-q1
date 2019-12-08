using CityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityApp.ViewModel
{
    public class CityViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Population { get; set; }
        public CityViewModel(City city)
        {
            Id = city.Id.ToString("N");
            Name = city.Name;
            Description = city.Description;
            Population = city.Population;
        }
    }
}
