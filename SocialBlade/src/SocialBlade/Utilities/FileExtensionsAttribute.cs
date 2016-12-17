using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Utilities
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileExtensionsAttribute : ValidationAttribute
    {
        private List<string> AllowedExtensions { get; set; }

        public FileExtensionsAttribute(string fileExtensions, string errorMessage)
        {
            AllowedExtensions = fileExtensions.ToLower().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            IFormFile file = value as IFormFile;

            if (file != null)
            {
                var fileName = file.FileName;

                return AllowedExtensions.Any(y => fileName.ToLower().EndsWith(y));
            }

            return true;
        }
    }
}
