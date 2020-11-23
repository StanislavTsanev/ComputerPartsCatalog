using ComputerPartsCatalog.Data.Common.Models;
using System.Collections.Generic;

namespace ComputerPartsCatalog.Data.Models
{
    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Images = new HashSet<Image>();
            this.ProductFeatures = new HashSet<ProductFeature>();
        }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<ProductFeature> ProductFeatures { get; set; }
    }
}
