namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Mapping;

    public class FeaturesViewModel : IMapFrom<ProductFeature>
    {
        public string FeatureName { get; set; }

        public string FeatureType { get; set; }
    }
}
