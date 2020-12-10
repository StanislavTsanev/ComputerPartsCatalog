namespace ComputerPartsCatalog.Services.Data.Ratings
{
    using System.Linq;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Data.Common.Repositories;
    using ComputerPartsCatalog.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class RatingsService : IRatingsService
    {
        private readonly IRepository<Rating> ratingsRepository;

        public RatingsService(IRepository<Rating> ratingsRepository)
        {
            this.ratingsRepository = ratingsRepository;
        }

        public async Task<double> GetAverageRatingAsync(int productId)
        {
            return await this.ratingsRepository.All()
                .Where(x => x.ProductId == productId)
                .AverageAsync(x => x.Value);
        }

        public async Task SetRatingAsync(int productId, string userId, byte value)
        {
            var rating = await this.ratingsRepository.All()
                .FirstOrDefaultAsync(x => x.ProductId == productId && x.UserId == userId);

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
