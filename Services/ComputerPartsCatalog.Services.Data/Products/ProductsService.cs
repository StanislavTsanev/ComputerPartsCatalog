namespace ComputerPartsCatalog.Services.Data.Products
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Data.Common.Repositories;
    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Mapping;
    using ComputerPartsCatalog.Web.ViewModels.Products;
    using Microsoft.EntityFrameworkCore;

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;
        private readonly IDeletableEntityRepository<Feature> featuresRepository;

        public ProductsService(IDeletableEntityRepository<Product> productsRepository, IDeletableEntityRepository<Feature> featuresRepository)
        {
            this.productsRepository = productsRepository;
            this.featuresRepository = featuresRepository;
        }

        public async Task CreateAsync(AddProductInputModel input, string userId, string imagePath)
        {
            var product = new Product()
            {
                Name = input.Name,
                Brand = input.Brand,
                Price = input.Price,
                Description = input.Description,
                CategoryId = input.CategoryId,
                UserId = userId,
            };

            if (input.Features != null)
            {
                foreach (var inputFeature in input.Features)
                {
                    var feature = await this.featuresRepository.All().FirstOrDefaultAsync(x => x.Name == inputFeature.Name && x.Type == inputFeature.Type);

                    if (feature == null)
                    {
                        feature = new Feature { Name = inputFeature.Name, Type = inputFeature.Type };
                    }

                    product.ProductFeatures.Add(new ProductFeature
                    {
                        Feature = feature,
                        Product = product,
                    });
                }
            }

             // wwwroot / img / products /{ id}.{ ext}
            Directory.CreateDirectory($"{imagePath}/products/");
            var extension = Path.GetExtension(input.Image.FileName).TrimStart('.');

            var dbImage = new Image
            {
                UserId = userId,
                Extension = extension,
            };
            product.Image = dbImage;

            var physicalPath = $"{imagePath}/products/{dbImage.Id}.{extension}";
            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await input.Image.CopyToAsync(fileStream);

            await this.productsRepository.AddAsync(product);
            await this.productsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await this.productsRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            this.productsRepository.Delete(product);

            await this.productsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int page, int productsPerPage = 12)
        {
            var products = await this.productsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * productsPerPage)
                .Take(productsPerPage)
                .To<T>()
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<T>> GetByCategoryIdAsync<T>(int id)
        {
            return await this.productsRepository.All().Where(x => x.CategoryId == id).To<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var product = await this.productsRepository.AllAsNoTracking()
                .Where(p => p.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<int> GetCountAsync()
        {
            return await this.productsRepository.All().CountAsync();
        }

        public async Task<IEnumerable<T>> GetRandomAsync<T>(int count)
        {
            return await this.productsRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .To<T>()
                .ToListAsync();
        }

        public async Task UpdateAsync(int id, EditProductInputModel input)
        {
            var product = await this.productsRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            product.Name = input.Name;
            product.Brand = input.Brand;
            product.Price = input.Price;
            product.Description = input.Description;
            product.CategoryId = input.CategoryId;

            await this.productsRepository.SaveChangesAsync();
        }
    }
}
