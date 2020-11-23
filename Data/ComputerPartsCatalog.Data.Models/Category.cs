using ComputerPartsCatalog.Data.Common.Models;
using System.Collections.Generic;

namespace ComputerPartsCatalog.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
