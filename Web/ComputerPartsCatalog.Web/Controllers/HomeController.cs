namespace ComputerPartsCatalog.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Services.Data.Products;
    using ComputerPartsCatalog.Web.ViewModels;
    using ComputerPartsCatalog.Web.ViewModels.Home;
    using ComputerPartsCatalog.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexPageViewModel()
            {
                Products = await this.productsService.GetRandomAsync<ProductSimpleViewModel>(9),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
