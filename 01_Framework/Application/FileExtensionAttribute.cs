using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _01_Framework.Application
{
    public class FileExtensionAttribute:ValidationAttribute,IClientModelValidator
    {
        private readonly string[]  _extension;
        
        public FileExtensionAttribute(string[] extension)
        {
            _extension = extension;
        }

        
        
     
        public string GetErrorMessage()
        {
            var se = string.Join(",", _extension);
            return $"The file format is incorrect, acceptable formats({se})";
        }

        protected override ValidationResult? IsValid(
            object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extension.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
        
            return ValidationResult.Success;
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            string myStringOutput = String.Join("/", _extension.Select(p => p.ToString()).ToArray());
            context.Attributes.Add("data-val-extension",GetErrorMessage());
            context.Attributes.Add("data-val-FileFormat", myStringOutput);
        }
    }
}
