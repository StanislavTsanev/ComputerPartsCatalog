namespace ComputerPartsCatalog.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ComputerPartsCatalog.Common;

    public abstract class BaseProductInputModel
    {
        [Required]
        [MinLength(GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.DataValidations.BrandMinLength)]
        public string Brand { get; set; }

        [Range(typeof(decimal), GlobalConstants.DataValidations.MinPrice, GlobalConstants.DataValidations.MaxPrice)]
        public decimal Price { get; set; }

        [MaxLength(GlobalConstants.DataValidations.DescriptionMaxLenght)]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
