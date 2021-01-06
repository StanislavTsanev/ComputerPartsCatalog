namespace ComputerPartsCatalog.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Data.Products;
    using ComputerPartsCatalog.Web.ViewModels.Products;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class ProductsServiceTests : BaseServicesTests
    {
        private IProductsService Service => this.ServiceProvider.GetRequiredService<IProductsService>();

        [Fact]
        public async Task CreateAsyncShouldCreateCorrectly()
        {
            var newId = 1;
            await this.CreateProductAsync(newId);

            var name = new NLipsum.Core.Sentence().ToString();
            var brand = new NLipsum.Core.Sentence().ToString();
            var description = new NLipsum.Core.Sentence().ToString();
            var price = 123.123M;
            var categoryId = 1;
            var userId = Guid.NewGuid().ToString();

            var inputModel = new AddProductInputModel()
            {
                Name = name,
                Brand = brand,
                Description = description,
                Price = price,
                CategoryId = categoryId,
            };
            var imagePath = "TestPath";
            await this.Service.CreateAsync(inputModel, userId, imagePath);

            var productsCount = await this.DbContext.Products.CountAsync();
            Assert.Equal(2, productsCount);
        }

        [Fact]

        public async Task DeleteAsyncShouldDeleteProperly()
        {
            var product = await this.CreateProductAsync(1);

            await this.Service.DeleteAsync(product.Id);

            var productsCount = this.DbContext.Products.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedProduct = await this.DbContext.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

            Assert.Equal(0, productsCount);
            Assert.Null(deletedProduct);
        }

        [Fact]

        public async Task UpdateAsyncShouldUpdateProperly()
        {
            await this.CreateProductAsync(1);

            var productEdit = new EditProductInputModel()
            {
                Id = 1,
                Name = "Updated Name",
                Brand = "Updated Brand",
                Description = "Updated Description",
                Price = 321.321M,
                CategoryId = 1,
            };

            await this.Service.UpdateAsync(1, productEdit);
            var product = await this.DbContext.Products.Where(x => x.Id == 1).FirstOrDefaultAsync();

            Assert.Equal(productEdit.Name, product.Name);
            Assert.Equal(productEdit.Brand, product.Brand);
            Assert.Equal(productEdit.Description, product.Description);
            Assert.Equal(productEdit.Price, product.Price);
        }

        private async Task<Product> CreateProductAsync(int newId)
        {
            var product = new Product()
            {
                Id = newId,
                Name = new NLipsum.Core.Sentence().ToString(),
                Brand = new NLipsum.Core.Sentence().ToString(),
                Description = new NLipsum.Core.Sentence().ToString(),
                Price = 123.123M,
                CategoryId = 1,
                UserId = Guid.NewGuid().ToString(),
            };

            var feature = new Feature()
            {
                Name = new NLipsum.Core.Sentence().ToString(),
                Type = new NLipsum.Core.Sentence().ToString(),
            };

            product.ProductFeatures.Add(new ProductFeature
            {
                Feature = feature,
                Product = product,
            });

            await this.DbContext.Products.AddAsync(product);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Product>(product).State = EntityState.Detached;

            return product;
        }
    }
}
