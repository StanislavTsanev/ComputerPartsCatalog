namespace ComputerPartsCatalog.Web.ViewComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Services.Data.Categories;
    using ComputerPartsCatalog.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoriesService;

        public CategoryListViewComponent(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new CategoriesListViewModel()
            {
                Categories = await this.categoriesService.GetAll<CategoryViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
