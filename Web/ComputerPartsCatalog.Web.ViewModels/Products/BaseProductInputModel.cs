namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseProductInputModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        public string Brand { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
