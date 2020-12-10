namespace ComputerPartsCatalog.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Services.Data.Search;
    using ComputerPartsCatalog.Web.ViewModels.Products;
    using ComputerPartsCatalog.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : BaseController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            string value = this.HttpContext.Request.QueryString.Value
                .ToString()
                .Split('=')
                .Last();

            var viewModel = new SearchListInputModel()
            {
                Value = value,
                Products = await this.searchService.Get<ProductSimpleViewModel>(searchString),
            };

            return this.View(viewModel);
        }
    }
}
