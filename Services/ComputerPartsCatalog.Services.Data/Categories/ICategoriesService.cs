namespace ComputerPartsCatalog.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<T>> GetAll<T>();

        Task<T> GetById<T>(int id);
    }
}
