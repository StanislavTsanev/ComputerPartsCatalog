namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class ProductsListViewModel
    {
        public IEnumerable<ProductSimpleViewModel> Products { get; set; }

        public int PageNumber { get; set; }
    }
}
