namespace ComputerPartsCatalog.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using ComputerPartsCatalog.Web.ViewModels.Products;

    public class SearchListInputModel
    {
        public string Value { get; set; }

        public IEnumerable<ProductSimpleViewModel> Products { get; set; }
    }
}
