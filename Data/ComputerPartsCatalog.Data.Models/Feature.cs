namespace ComputerPartsCatalog.Data.Models
{
    using System.Collections.Generic;

    using ComputerPartsCatalog.Data.Common.Models;

    public class Feature : BaseDeletableModel<int>
    {
        public Feature()
        {
            this.ProductFeatures = new HashSet<ProductFeature>();
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
    }
}
