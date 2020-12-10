namespace ComputerPartsCatalog.Web.Controllers
{
    using System.Threading.Tasks;
    using ComputerPartsCatalog.Services.Data.Categories;
    using ComputerPartsCatalog.Services.Data.Products;
    using ComputerPartsCatalog.Web.ViewModels.Categories;
    using ComputerPartsCatalog.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
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

        public async Task<IActionResult> Category(int id)
        {
            var viewModel = new CategoryViewModel()
            {
                Products = await this.productsService.GetByCategoryIdAsync<ProductSimpleViewModel>(id),
            };

            return this.View(viewModel);
        }
    }
}
