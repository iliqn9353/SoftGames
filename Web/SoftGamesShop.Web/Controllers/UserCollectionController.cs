namespace SoftGamesShop.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services;

    public class UserCollectionController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;

        public UserCollectionController(
            UserManager<ApplicationUser> userManager,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
        }

        public IActionResult MyCollection(int id)
        {
            var user = this.userManager.GetUserId(this.User);
            var viewModel = this.usersService.GetByUserId(user);
            return this.View(viewModel);
        }

        [Authorize]

        public async Task<IActionResult> AddToCollection(int gameId, string name)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.usersService.AddGameToUserCollection(name, user.Id, gameId);

            return this.Redirect($"/Games/ById/{gameId}");
            //return this.Redirect("/UserCollection/MyCollection");
        }

        public async Task<IActionResult> RemoveFromCollection(int gameId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.usersService.RemoveGameFromUserCollection(user.Id, gameId);
            return this.Redirect("/UserCollection/MyCollection");
        }
    }
}
