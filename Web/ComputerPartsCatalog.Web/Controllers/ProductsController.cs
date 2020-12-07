namespace ComputerPartsCatalog.Web.Controllers
{
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Services.Data;
    using ComputerPartsCatalog.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            const int ItemsPerPage = 12;
            var viewModel = new ProductsListViewModel()
            {
                Products = await this.productsService.GetAllAsync<ProductSimpleViewModel>(id, ItemsPerPage),
                PageNumber = id,
                ProductsCount = await this.productsService.GetCountAsync(),
                ItemsPerPage = ItemsPerPage,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await this.productsService.GetByIdAsync<ProductDetailsViewModel>(id);

            return this.View(viewModel);
        }
    }
}
