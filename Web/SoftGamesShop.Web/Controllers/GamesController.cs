namespace SoftGamesShop.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services;
    using SoftGamesShop.Web.ViewModels;
    using SoftGamesShop.Web.ViewModels.Game;
    using SoftGamesShop.Web.ViewModels.Genre;
    using SoftGamesShop.Web.ViewModels.Platform;
    using SoftGamesShop.Web.ViewModels.Rating;

    public class GamesController : Controller
    {
        private const int ItemsPerPage = 8;
        private readonly IGamesService gamesService;
        private readonly IHostingEnvironment hostingEnvironment;

        private readonly IGenreService genreService;
        private readonly IPlatformService platformService;
        private readonly IRatingService ratingService;
        private readonly UserManager<ApplicationUser> userManager;

        public GamesController(
            IGamesService gamesService,
            IHostingEnvironment hostingEnvironment,
            IGenreService genreService,
            UserManager<ApplicationUser> userManager,
            IPlatformService platformService,
            IRatingService ratingService)
        {
            this.gamesService = gamesService;
            this.hostingEnvironment = hostingEnvironment;
            this.genreService = genreService;
            this.userManager = userManager;
            this.platformService = platformService;
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

            var games = this.gamesService.GetAll<AllGamesViewModel>();
            var result = this.gamesService.PaginationGames<AllGamesViewModel>(id, games, ItemsPerPage);
            var viewModel = new AllGamesListSearchViewModel
            {
                Games = result,
                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = id,
                    PagesCount = (int)Math.Ceiling(games.Count() / (decimal)ItemsPerPage),
                    DataCount = games.Count(),
                    Controller = "Games",
                    Action = "All",
                },
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var game = this.gamesService.GetById<SingleGameViewModel>(id);
            return this.View(game);
        }

        public IActionResult Index(SeachGameViewModel search, int? id = 1)
        {
            var vm = new MyErrorViewModel
            {
                Description="No game found !"
            };
            if (search.GameName != null)
            {
                return this.RedirectToAction("SearchByGameName", new { id = id, search = search.GameName });
            }

            //return this.NotFound();
            return this.View("Views/Error/NotFound.cshtml",vm);
        }

        public IActionResult SearchByGameName(int id, string search)
        {
            var games = this.gamesService.GetByName<AllGamesViewModel>(search);

            var result = this.gamesService.PaginationGames<AllGamesViewModel>(id, games, ItemsPerPage);
            var viewModel = new AllGamesListSearchViewModel
            {
                Games = result,

                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = id,
                    PagesCount = (int)Math.Ceiling(games.Count() / (decimal)ItemsPerPage),
                    DataCount = games.Count(),
                    Controller = "Games",
                    Action = "SearchByGameName",
                    Search = search,
                },
            };
            return this.View("Views/Games/All.cshtml", viewModel);
        }

        public IActionResult SortAlphabetical(int id = 1)
        {
            var games = this.gamesService.SortAToZ<AllGamesViewModel>();

            var result = this.gamesService.PaginationGames<AllGamesViewModel>(id, games, ItemsPerPage);
            var viewModel = new AllGamesListSearchViewModel
            {
                Games = result,

                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = id,
                    PagesCount = (int)Math.Ceiling(games.Count() / (decimal)ItemsPerPage),
                    DataCount = games.Count(),
                    Controller = "Games",
                    Action = "SortAlphabetical",
                },
            };
            return this.View("Views/Games/All.cshtml", viewModel);
        }

        public IActionResult SortAlphabeticalLast(int id = 1)
        {
            var games = this.gamesService.SortZToA<AllGamesViewModel>();

            var result = this.gamesService.PaginationGames<AllGamesViewModel>(id, games, ItemsPerPage);
            var viewModel = new AllGamesListSearchViewModel
            {
                Games = result,

                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = id,
                    PagesCount = (int)Math.Ceiling(games.Count() / (decimal)ItemsPerPage),
                    DataCount = games.Count(),
                    Controller = "Games",
                    Action = "SortAlphabeticalLast",
                },
            };
            return this.View("Views/Games/All.cshtml", viewModel);
        }

        public IActionResult SortDateAdded(int id = 1)
        {
            var games = this.gamesService.SortDateAdded<AllGamesViewModel>();

            var result = this.gamesService.PaginationGames<AllGamesViewModel>(id, games, ItemsPerPage);
            var viewModel = new AllGamesListSearchViewModel
            {
                Games = result,

                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = id,
                    PagesCount = (int)Math.Ceiling(games.Count() / (decimal)ItemsPerPage),
                    DataCount = games.Count(),
                    Controller = "Games",
                    Action = "SortDateAdded",
                },
            };
            return this.View("Views/Games/All.cshtml", viewModel);
        }

        public IActionResult SortDateAddedNew(int id = 1)
        {
            var games = this.gamesService.SortDateAddedNew<AllGamesViewModel>();

            var result = this.gamesService.PaginationGames<AllGamesViewModel>(id, games, ItemsPerPage);
            var viewModel = new AllGamesListSearchViewModel
            {
                Games = result,

                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = id,
                    PagesCount = (int)Math.Ceiling(games.Count() / (decimal)ItemsPerPage),
                    DataCount = games.Count(),
                    Controller = "Games",
                    Action = "SortDateAddedNew",
                },
            };
            return this.View("Views/Games/All.cshtml", viewModel);
        }
    }
}
