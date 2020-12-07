namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using System.Collections.Generic;

    using ComputerPartsCatalog.Common;
    using ComputerPartsCatalog.Web.Infrastructure.ValidatorAttributes;
    using Microsoft.AspNetCore.Http;

    public class AddProductInputModel : BaseProductInputModel
    {
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        [MaxFileSize(GlobalConstants.DataValidations.MaxFileLength)]
        public IFormFile Image { get; set; }

        public IEnumerable<ProductFeatureInputModel> Features { get; set; }
    }
}
