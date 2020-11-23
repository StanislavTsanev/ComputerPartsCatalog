using System.Threading.Tasks;

namespace ComputerPartsCatalog.Services.Data
{
    public interface IProductsService
    {
        Task CreateAsync(AddProductInputModel input, string userId);
    }
}
