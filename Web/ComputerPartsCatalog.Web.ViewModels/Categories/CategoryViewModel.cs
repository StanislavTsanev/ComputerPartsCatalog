namespace ComputerPartsCatalog.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Mapping;
    using ComputerPartsCatalog.Web.ViewModels.Products;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductSimpleViewModel> Products { get; set; }
    }
}
