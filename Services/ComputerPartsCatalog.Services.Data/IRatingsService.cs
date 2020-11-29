namespace ComputerPartsCatalog.Services.Data
{
    using System.Threading.Tasks;

    public interface IRatingsService
    {
        Task SetRatingAsync(int productId, string userId, byte value);

        double GetAverageRating(int productId);
    }
}
