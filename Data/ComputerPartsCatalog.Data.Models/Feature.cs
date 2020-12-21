namespace ComputerPartsCatalog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ComputerPartsCatalog.Data.Common.Models;

    public class Feature : BaseDeletableModel<int>
    {
        public Feature()
        {
            this.ProductFeatures = new HashSet<ProductFeature>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
    }
}
