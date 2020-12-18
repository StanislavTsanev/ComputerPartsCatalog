namespace ComputerPartsCatalog.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Data.Models;
    using ComputerPartsCatalog.Services.Data.Categories;
    using ComputerPartsCatalog.Services.Data.Ratings;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class RatingsServiceTests : BaseServicesTests
    {
        private IRatingsService Service => this.ServiceProvider.GetRequiredService<IRatingsService>();

        [Fact]
        public async Task OneVoteShouldBeCountedWhenSameUserVotesTwiceForSameProduct()
        {
            var userId = Guid.NewGuid().ToString();
            await this.Service.SetRatingAsync(1, userId, 1);
            await this.Service.SetRatingAsync(1, userId, 4);
            await this.Service.SetRatingAsync(1, userId, 3);
            await this.Service.SetRatingAsync(1, userId, 5);

            var timesVoted = await this.DbContext.Ratings.Where(x => x.UserId == userId).CountAsync();
            Assert.Equal(1, timesVoted);
        }

        [Fact]

        public async Task AverageVoteShouldAddUpCorrectlyWhenUsersVote()
        {
            var firstUserId = Guid.NewGuid().ToString();
            var secondUserId = Guid.NewGuid().ToString();

            await this.Service.SetRatingAsync(10, firstUserId, 5);
            await this.Service.SetRatingAsync(10, secondUserId, 1);
            await this.Service.SetRatingAsync(10, firstUserId, 2);

            var expected = await this.Service.GetAverageRatingAsync(10);
            Assert.Equal(1.5, expected);
        }
    }
}
