namespace ComputerPartsCatalog.Data.Models
{
    public class ProductFeature
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int FeatureId { get; set; }

        public virtual Feature Feature { get; set; }
    }
}
