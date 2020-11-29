namespace ComputerPartsCatalog.Web.ViewModels.Ratings
{
    using System.ComponentModel.DataAnnotations;

    public class PostRatingInputModel
    {
        public int ProductId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
