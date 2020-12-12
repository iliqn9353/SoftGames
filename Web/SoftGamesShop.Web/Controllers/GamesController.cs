namespace SoftGamesShop.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services;

    using SoftGamesShop.Web.ViewModels.Game;
    using SoftGamesShop.Web.ViewModels.Genre;
    using SoftGamesShop.Web.ViewModels.Platform;
    using SoftGamesShop.Web.ViewModels.Rating;
    using SoftGamesShop.Web.ViewModels.Search;

    public class GamesController : Controller
    {
        private const int ItemsPerPage = 8;
        private readonly IGamesService gamesService;
        private readonly IHostingEnvironment hostingEnvironment;

        private readonly IGenreService genreService;
        private readonly IPlatformService platformService;
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly IRatingService ratingService;
        private readonly UserManager<ApplicationUser> userManager;

        public GamesController(
            IGamesService gamesService,
            IHostingEnvironment hostingEnvironment,
            IGenreService genreService,
            UserManager<ApplicationUser> userManager,
            IPlatformService platformService,
            IDeletableEntityRepository<Game> gameRepository,
            IRatingService ratingService)
        {
            this.gamesService = gamesService;
            this.hostingEnvironment = hostingEnvironment;
            this.genreService = genreService;
            this.userManager = userManager;
            this.platformService = platformService;
            this.gameRepository = gameRepository;
            this.ratingService = ratingService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new AddGameInputModel();
            viewModel.Genres = this.genreService.GetAll<GenreViewModel>();
            viewModel.Platforms = this.platformService.GetAll<PlatformViewModel>();
            viewModel.Ratings = this.ratingService.GetAll<RatingViewModel>();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddGameInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (this.ModelState.IsValid)
            {
                model.Genres = this.genreService.GetAll<GenreViewModel>();
                model.Platforms = this.platformService.GetAll<PlatformViewModel>();
                model.Ratings = this.ratingService.GetAll<RatingViewModel>();
                await this.gamesService.CreateGame(model, user.Id, $"{this.hostingEnvironment.WebRootPath}/images");
            }

            return this.Redirect("/Games/All");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new AllGamesListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                GamesCount = this.gamesService.GetCount(),
                Games = this.gamesService.GetAll<AllGamesViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var game = this.gamesService.GetById<SingleGameViewModel>(id);
            return this.View(game);
        }

        [HttpGet]
        public IActionResult Search(string searchString, int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var games = this.gamesService.GetByName<AllGamesViewModel>(searchString);

            var viewModel = new SearchGameViewModel
            {
                Games = games,
            };
            return this.View("Views/Games/Search.cshtml", viewModel);
        }
    }
}
