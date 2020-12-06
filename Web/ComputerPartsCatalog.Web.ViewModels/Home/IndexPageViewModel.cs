namespace ComputerPartsCatalog.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using ComputerPartsCatalog.Web.ViewModels.Categories;
    using ComputerPartsCatalog.Web.ViewModels.Products;

    public class IndexPageViewModel
    {
        public IEnumerable<ProductSimpleViewModel> Products { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
