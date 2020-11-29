namespace ComputerPartsCatalog.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Data.Common.Repositories;
    using ComputerPartsCatalog.Data.Models;

    public class RatingsService : IRatingsService
    {
        private readonly IRepository<Rating> ratingsRepository;

        public RatingsService(IRepository<Rating> ratingsRepository)
        {
            this.ratingsRepository = ratingsRepository;
        }

        public double GetAverageRating(int productId)
        {
            return this.ratingsRepository.All()
                .Where(x => x.ProductId == productId)
                .Average(x => x.Value);
        }

        public async Task SetRatingAsync(int productId, string userId, byte value)
        {
            var rating = this.ratingsRepository.All()
                .FirstOrDefault(x => x.ProductId == productId && x.UserId == userId);

            if (rating == null)
            {
                rating = new Rating
                {
                    ProductId = productId,
                    UserId = userId,
                };

                await this.ratingsRepository.AddAsync(rating);
            }

            rating.Value = value;
            await this.ratingsRepository.SaveChangesAsync();
        }
    }
}
