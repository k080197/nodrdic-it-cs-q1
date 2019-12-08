using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityApp.ViewModel
{
    public class NotCompareAttribute : ValidationAttribute
    {
        public string Property { get; set; }

        public NotCompareAttribute(string property)
        {
            Property = property;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(Property);

            var propertyValue = property.GetValue(validationContext.ObjectInstance);

            if (Equals(value, propertyValue))
            {
                return new ValidationResult($"Значение свойства {Property} совпадает");
            }

            return ValidationResult.Success;
        }
    }
}
