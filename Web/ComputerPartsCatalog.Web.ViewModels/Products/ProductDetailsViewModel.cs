namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using System.Collections.Generic;

    using AutoMapper;
    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Mapping;

    public class ProductDetailsViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<FeaturesViewModel> ProductFeatures { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                    x.Image.RemoteImageUrl != null ?
                    x.Image.RemoteImageUrl :
                    "/img/products/" + x.Image.Id + "." + x.Image.Extension));
        }
    }
}
