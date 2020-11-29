namespace ComputerPartsCatalog.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using ComputerPartsCatalog.Services.Data;
    using ComputerPartsCatalog.Web.ViewModels.Ratings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : BaseController
    {
        private readonly IRatingsService ratingsService;

        public RatingsController(IRatingsService ratingsService)
        {
            this.ratingsService = ratingsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostRatingResponseModel>> Post(PostRatingInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.ratingsService.SetRatingAsync(input.ProductId, userId, input.Value);
            var averageRating = this.ratingsService.GetAverageRating(input.ProductId);

            return new PostRatingResponseModel { AverageRating = averageRating };
        }
    }
}
