namespace ComputerPartsCatalog.Services.Data.Search
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISearchService
    {
        Task<IEnumerable<T>> Get<T>(string searchString);
    }
}
