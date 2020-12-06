namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ComputerPartsCatalog.Web.Infrastructure.ValidatorAttributes;
    using Microsoft.AspNetCore.Http;

    public class AddProductInputModel : BaseProductInputModel
    {
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        [MaxFileSize(5 * 1024 * 1024)]
        public IFormFile Image { get; set; }

        public IEnumerable<ProductFeatureInputModel> Features { get; set; }
    }
}
