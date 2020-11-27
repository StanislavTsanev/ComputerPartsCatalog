using ComputerPartsCatalog.Data.Common.Models;
using System.Collections.Generic;

namespace ComputerPartsCatalog.Data.Models
{
    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.ProductFeatures = new HashSet<ProductFeature>();
        }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
    }
}
