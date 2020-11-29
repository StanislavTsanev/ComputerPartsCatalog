namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Mapping;

    public class ProductDetailsViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public double AverageRating { get; set; }

        public IEnumerable<FeaturesViewModel> ProductFeatures { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(x => x.AverageRating, opt =>
                    opt.MapFrom(x => x.Ratings.Average(r => r.Value)))
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                    x.Image.RemoteImageUrl != null ?
                    x.Image.RemoteImageUrl :
                    "/img/products/" + x.Image.Id + "." + x.Image.Extension));
        }
    }
}
