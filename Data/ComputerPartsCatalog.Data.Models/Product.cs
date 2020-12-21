namespace ComputerPartsCatalog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ComputerPartsCatalog.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.ProductFeatures = new HashSet<ProductFeature>();
            this.Ratings = new HashSet<Rating>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
