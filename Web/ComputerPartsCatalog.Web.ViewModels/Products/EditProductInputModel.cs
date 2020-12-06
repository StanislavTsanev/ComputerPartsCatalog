namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Mapping;

    public class EditProductInputModel : BaseProductInputModel, IMapFrom<Product>
    {
        public int Id { get; set; }
    }
}
