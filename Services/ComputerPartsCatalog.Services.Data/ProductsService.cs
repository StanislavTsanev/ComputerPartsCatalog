namespace ComputerPartsCatalog.Services.Data
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

            foreach (var inputFeature in input.Features)
            {
                var feature = this.featuresRepository.All().FirstOrDefault(x => x.Name == inputFeature.Name && x.Type == inputFeature.Type);

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

            // /wwwroot/img/products/{id}.{ext}
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

        public IEnumerable<T> GetAll<T>(int page, int productsPerPage = 12)
        {
            var products = this.productsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * productsPerPage)
                .Take(productsPerPage)
                .To<T>()
                .ToList();

            return products;
        }

        public T GetById<T>(int id)
        {
            var product = this.productsRepository.AllAsNoTracking()
                .Where(p => p.Id == id)
                .To<T>()
                .FirstOrDefault();

            return product;
        }

        public int GetCount()
        {
            return this.productsRepository.All().Count();
        }
    }
}
