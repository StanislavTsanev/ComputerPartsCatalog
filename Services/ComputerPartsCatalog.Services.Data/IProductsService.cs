namespace ComputerPartsCatalog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Web.ViewModels.Products;

    public interface IProductsService
    {
        Task CreateAsync(AddProductInputModel input, string userId, string imagePath);

        Task<IEnumerable<T>> GetAll<T>(int page, int productsPerPage = 12);

        Task<IEnumerable<T>> GetRandom<T>(int count);

        int GetCount();

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditProductInputModel input);
    }
}
