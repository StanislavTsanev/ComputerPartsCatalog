namespace ComputerPartsCatalog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Web.ViewModels.Products;

    public interface IProductsService
    {
        Task CreateAsync(AddProductInputModel input, string userId, string imagePath);

        Task<IEnumerable<T>> GetAllAsync<T>(int page, int productsPerPage = 12);

        Task<IEnumerable<T>> GetRandomAsync<T>(int count);

        Task<int> GetCountAsync();

        Task<T> GetByIdAsync<T>(int id);

        Task UpdateAsync(int id, EditProductInputModel input);

        Task DeleteAsync(int id);
    }
}
