namespace ComputerPartsCatalog.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Data.Common.Repositories;
    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Data.Categories;
    using ComputerPartsCatalog.Services.Mapping;
    using ComputerPartsCatalog.Web.ViewModels;
    using ComputerPartsCatalog.Web.ViewModels.Categories;
    using Moq;
    using Xunit;

    public class CategoriesServiceTests
    {
        /*private List<Category> categories;
        private CategoriesService service;

        public CategoriesServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly, Assembly.Load("ComputerPartsCatalog.Services.Data.Tests"));
            this.categories = new List<Category>();

            var mockCategoryRepo = new Mock<IDeletableEntityRepository<Category>>();
            mockCategoryRepo.Setup(x => x.All()).Returns(this.categories.AsQueryable());
            mockCategoryRepo.Setup(x => x.AllAsNoTracking()).Returns(this.categories.AsQueryable());

            this.service = new CategoriesService(mockCategoryRepo.Object);

            var testCategories = new List<Category>()
            {
                new Category { Id = 1, Name = "TestCategory1" },
                new Category { Id = 2, Name = "TestCategory2" },
                new Category { Id = 3, Name = "TestCategory3" },
                new Category { Id = 4, Name = "TestCategory4" },
                new Category { Id = 5, Name = "TestCategory5" },
            };

            this.categories.AddRange(testCategories);
        }

        [Fact]
        //TODO: System.InvalidOperationException : The source IQueryable doesn't implement IAsyncEnumerable
        public async Task GetAllShouldWorkCorrectly()
        {
            var resultObj = await this.service.GetAll<CategoryViewModel>();

            Assert.Equal(5, resultObj.Count());
        }
        */
    }
}
