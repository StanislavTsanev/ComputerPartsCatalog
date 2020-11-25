namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class ProductsListViewModel : PagingViewModel
    {
        public IEnumerable<ProductSimpleViewModel> Products { get; set; }
    }
}
