﻿namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using AutoMapper;
    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Mapping;

    public class ProductSimpleViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductSimpleViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                    x.Image.RemoteImageUrl != null ?
                    x.Image.RemoteImageUrl :
                    "/img/products/" + x.Image.Id + "." + x.Image.Extension));
        }
    }
}
