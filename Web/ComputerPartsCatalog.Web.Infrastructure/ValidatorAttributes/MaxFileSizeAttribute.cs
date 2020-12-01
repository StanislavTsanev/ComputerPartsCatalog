namespace ComputerPartsCatalog.Web.Infrastructure.ValidatorAttributes
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            this.maxFileSize = maxFileSize;
        }

        public string GetErrorMessage()
        {
            return $"Maximum allowed file size is {this.maxFileSize} bytes.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            // var extension = Path.GetExtension(file.FileName);
            // var allowedExtensions = new[] { ".jpg", ".png" };`enter code here`
            if (file != null)
            {
                if (file.Length > this.maxFileSize)
                {
                    return new ValidationResult(this.GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }
    }
}
