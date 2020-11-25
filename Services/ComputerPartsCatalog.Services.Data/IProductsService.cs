namespace ComputerPartsCatalog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Web.ViewModels.Products;

    public interface IProductsService
    {
        Task CreateAsync(AddProductInputModel input, string userId);

        IEnumerable<T> GetAll<T>(int page, int productsPerPage = 12);

        int GetCount();
    }
}
