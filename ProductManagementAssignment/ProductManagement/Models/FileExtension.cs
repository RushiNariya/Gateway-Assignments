using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProductManagement.Models;

namespace ProductManagement.Models
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileExtension: ValidationAttribute
    {
        private List<string> AllowedExtensions { get; set; }

        public string Extensions { get; set; } = "png,jpg,jpeg";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;
            HttpPostedFileBase smallImage = product.SmallImage as HttpPostedFileBase;
            bool isValid = true;
            List<string> AllowedExtensions = this.Extensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (smallImage == null)
                return ValidationResult.Success;

            var smallImageName = smallImage.FileName;
            isValid = AllowedExtensions.Any(y => smallImageName.EndsWith(y));

            if (isValid)
                return ValidationResult.Success;
            else
                return new ValidationResult("Product Image Extension must be png or jpg.");
        }
    }
}