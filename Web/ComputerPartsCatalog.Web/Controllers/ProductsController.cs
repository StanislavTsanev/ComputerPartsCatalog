namespace ComputerPartsCatalog.Web.Controllers
{
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Common;
    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Data;
    using ComputerPartsCatalog.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IProductsService productsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public ProductsController(
            ICategoriesService categoriesService,
            IProductsService productsService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.categoriesService = categoriesService;
            this.productsService = productsService;
            this.userManager = userManager;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new AddProductInputModel();
            viewModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Add(AddProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.productsService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/img");

            return this.Redirect("/");
        }

        public async Task<IActionResult> All(int id = 1)
        {
            const int ItemsPerPage = 12;
            var viewModel = new ProductsListViewModel()
            {
                Products = await this.productsService.GetAll<ProductSimpleViewModel>(id, ItemsPerPage),
                PageNumber = id,
                ProductsCount = this.productsService.GetCount(),
                ItemsPerPage = ItemsPerPage,
            };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var viewModel = this.productsService.GetById<ProductDetailsViewModel>(id);

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var viewModel = this.productsService.GetById<EditProductInputModel>(id);
            viewModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View();
            }

            await this.productsService.UpdateAsync(id, input);
            return this.RedirectToAction(nameof(this.Details), new { id });
        }
    }
}
