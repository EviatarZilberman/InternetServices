using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InternetServices.Annotations
{
    public class RoleInUse : ValidationAttribute
    {
        public RoleInUse(string query)
        {
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            return new ValidationResult(string.Empty);
        }

    }
}
