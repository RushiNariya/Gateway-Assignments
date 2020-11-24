using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlAssignment1.Models
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileExtension:ValidationAttribute
    {
        private List<string> AllowedExtensions { get; set; }

        public string Extensions { get; set; } = "png,jpg";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            HttpPostedFileBase file = customer.Photo as HttpPostedFileBase;
            bool isValid = true;
            List<string> AllowedExtensions = this.Extensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (file == null)
                return new ValidationResult("Customer's Photo is Required.");

                var fileName = file.FileName;
                isValid = AllowedExtensions.Any(y => fileName.EndsWith(y));

            if (isValid)
                return ValidationResult.Success;
            else
                return new ValidationResult("FIle Extension must be png or jpg.");
        }
    }
}