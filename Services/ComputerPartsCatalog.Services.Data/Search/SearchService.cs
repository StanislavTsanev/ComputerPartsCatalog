namespace ComputerPartsCatalog.Services.Data.Search
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Data.Common.Repositories;
    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;

        public SearchService(IDeletableEntityRepository<Product> productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<IEnumerable<T>> Get<T>(string searchString)
        {
            return await this.productsRepository.AllAsNoTracking()
                .Where(p => p.Name.Contains(searchString))
                .To<T>()
                .ToListAsync();
        }
    }
}
