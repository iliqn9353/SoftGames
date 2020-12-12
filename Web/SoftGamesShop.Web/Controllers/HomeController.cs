namespace SoftGamesShop.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SoftGamesShop.Data;
    using SoftGamesShop.Services;
    using SoftGamesShop.Web.ViewModels;
    using SoftGamesShop.Web.ViewModels.Game;

    public class HomeController : BaseController
    {
        private readonly IGamesService gamesService;
        private readonly ApplicationDbContext db;

        public HomeController(IGamesService gamesService, ApplicationDbContext db)
        {
            this.gamesService = gamesService;
            this.db = db;
        }

        [Authorize]
        public IActionResult Chat()
        {
            return this.View();
        }

        public IActionResult Index()
        {
            var model = new SoftGamesShop.Web.ViewModels.Home.IndexViewModel
            {
                GamesCount = this.db.Games.Count(),
                GenreCount = this.db.Genres.Count(),
                PlatformsCount = this.db.Platforms.Count(),
                ImagesCount = this.db.Images.Count(),
                LatestGame = this.gamesService.GetLatest<AllGamesViewModel>(3),
            };
            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
