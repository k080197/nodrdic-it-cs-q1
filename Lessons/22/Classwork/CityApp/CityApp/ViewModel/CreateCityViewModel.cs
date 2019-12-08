using CityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CityApp.ViewModel
{
    public class CreateCityViewModel
    {
        [Required(ErrorMessage = "Имя города не указано.")]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Описание города не указано.")]
        [MaxLength(1024)]
        [NotCompare(nameof(Name))]
        public string Description { get; set; }

        [Required]
        [Range(0, 120_000_000)]
        public int Population { get; set; }
    }

    public class DetailCityViewModel
    {
        public DetailCityViewModel(City city)
        {
            Id = city.Id.ToString("N");
            Name = city.Name;
            Description = city.Description;
            Population = city.Population;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Population { get; set; }
    }

    public class ValidationErrorViewModel
    {
        public ValidationErrorViewModel(string property,
            ModelStateEntry entry)
        {
            Property = property;
            Errors = entry.Errors.Select(error => error.ErrorMessage).ToArray();
        }

        public string Property { get; set; }
        public string[] Errors { get; set; }
    }
}
