namespace ComputerPartsCatalog.Services.Data.Ratings
{
    using System.Threading.Tasks;

    public interface IRatingsService
    {
        Task SetRatingAsync(int productId, string userId, byte value);

        Task<double> GetAverageRatingAsync(int productId);
    }
}
