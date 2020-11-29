namespace ComputerPartsCatalog.Data.Models
{
    using ComputerPartsCatalog.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
