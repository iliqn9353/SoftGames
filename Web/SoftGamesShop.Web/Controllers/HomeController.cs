namespace SoftGamesShop.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using SoftGamesShop.Data;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Web.ViewModels;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string searching)
        {
            //var model = new SoftGamesShop.Web.ViewModels.Home.IndexViewModel
            //{
            //    GamesCount = this.db.Games.Count(),
            //    GenreCount = this.db.Genres.Count(),
            //    PlatformsCount = this.db.Platforms.Count(),
            //    ImagesCount = this.db.Images.Count(),
            //};
            //return this.View(model);

            return View(db.Games.Where(x => x.Name.Contains(searching) || searching == null).ToList());

            //var webClient = new WebClient();
            //var json = webClient.DownloadString(@"C:\Users\Ico\Desktop\SoftGamesShop-newest-main\Web\SoftGamesShop.Web\wwwroot\Json\games.json");
            //var games = JsonConvert.DeserializeObject<Game>(json);

            //return View(games);
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
