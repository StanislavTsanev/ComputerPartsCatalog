namespace ComputerPartsCatalog.Web.Controllers
{
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Data;
    using ComputerPartsCatalog.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IProductsService productsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductsController(ICategoriesService categoriesService, IProductsService productsService, UserManager<ApplicationUser> userManager)
        {
            this.categoriesService = categoriesService;
            this.productsService = productsService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new AddProductInputModel();
            viewModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.productsService.CreateAsync(input, user.Id);

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            var viewModel = new ProductsListViewModel()
            {
                PageNumber = id,
                Products = this.productsService.GetAll<ProductSimpleViewModel>(id, 12),
            };

            return this.View(viewModel);
        }
    }
}
