namespace SoftGamesShop.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services;
    using SoftGamesShop.Web.ViewModels.Votes;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            IVotesService votesService,
            UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AllVotesViewModel>> Game(VoteInputViewModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.votesService.VotesAsync(input.GameId, userId, input.IsUpVote);
            var votes = this.votesService.GetAllVotes(input.GameId);
            return new AllVotesViewModel { VotesCounter = votes };
        }
    }
}
