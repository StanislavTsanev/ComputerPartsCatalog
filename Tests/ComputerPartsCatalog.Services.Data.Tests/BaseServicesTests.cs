namespace ComputerPartsCatalog.Services.Data.Tests
{
    using System;

    using ComputerPartsCatalog.Data;
    using ComputerPartsCatalog.Data.Common.Repositories;
    using ComputerPartsCatalog.Data.Repositories;
    using ComputerPartsCatalog.Services.Data.Products;
    using ComputerPartsCatalog.Services.Data.Ratings;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class BaseServicesTests : IDisposable
    {
        protected BaseServicesTests()
        {
            var services = this.SetServices();

            this.ServiceProvider = services.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        public IServiceProvider ServiceProvider { get; set; }

        public ApplicationDbContext DbContext { get; set; }

        public void Dispose()
        {
            this.DbContext.Database.EnsureDeleted();
            this.SetServices();
        }

        private ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // App services
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IRatingsService, RatingsService>();

            return services;
        }
    }
}
