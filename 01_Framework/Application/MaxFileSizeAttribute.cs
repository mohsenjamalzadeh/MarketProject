using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _01_Framework.Application
{
    public class MaxFileSizeAttribute:ValidationAttribute,IClientModelValidator
    {
        public int MaxSize { get;private set; }
        public MaxFileSizeAttribute(int maxSize)
        {
            MaxSize = maxSize;
        }

        public string GetErrorMessage()
        {
            return $"The size of the desired file should not exceed {MaxSize / (1024*1024)} megabytes";
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file=value as IFormFile;

            if (file == null) return ValidationResult.Success;

            if (file.Length > MaxSize)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;

        }


        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val","true");
            context.Attributes.Add("data-val-maxsize",GetErrorMessage());
        }
    }
}
