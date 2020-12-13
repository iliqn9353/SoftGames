namespace SoftGamesShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;

    using SoftGamesShop.Services.Mapping;
    using SoftGamesShop.Web.ViewModels.Game;

    public class GameService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly IDeletableEntityRepository<Genre> genreRepository;
        private readonly IDeletableEntityRepository<Platform> platformRepository;
        private readonly IDeletableEntityRepository<Rating> ratingRepository;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };

        public GameService(
            IDeletableEntityRepository<Game> gameRepository,
            IDeletableEntityRepository<Genre> genreRepository,
            IDeletableEntityRepository<Platform> platformRepository,
            IDeletableEntityRepository<Rating> ratingRepository)
        {
            this.gameRepository = gameRepository;
            this.genreRepository = genreRepository;
            this.platformRepository = platformRepository;
            this.ratingRepository = ratingRepository;
        }

        public async Task CreateGame(AddGameInputModel model, string userId, string imagePath)
        {
            var game = new Game
            {
                Id = model.Id,
                CreatedById = userId,
                Name = model.Name,
                Description = model.Description,
                Developer = model.Developer,
                PlayersCount = model.PlayersCount,
                Trailer = model.Trailer,
                CoOp = model.CoOp,
                ReleaseDate = model.ReleaseDate,
                GenreId = model.GenreId,
                PlatformId = model.PlatformId,
                RatingId = model.RatingId,
            };

            var genre = this.genreRepository.All().SingleOrDefault(x => x.Id == model.GenreId);
            game.GameGenres.Add(new GameGenres
            {
                Genre = genre,
            });
            var platform = this.platformRepository.All().SingleOrDefault(x => x.Id == model.PlatformId);
            game.GamePlatforms.Add(new GamePlatform
            {
                Platform = platform,
            });

            var rating = this.ratingRepository.All().SingleOrDefault(x => x.Id == model.RatingId);
            game.GameRatings.Add(new GameRating
            {
                Rating = rating,
            });
            Directory.CreateDirectory($"{imagePath}/Games/");
            foreach (var image in model.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };
                game.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/Games/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.gameRepository.AddAsync(game);

            await this.gameRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var game = this.gameRepository.AllAsNoTracking()
              .Where(x => x.Id == id)
              .To<T>().FirstOrDefault();

            return game;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var games = this.gameRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .To<T>().ToList();
            return games;
        }

        public int GetCount()
        {
            return this.gameRepository.All().Count();
        }

        public IEnumerable<T> GetByName<T>(string search)
        {
            var query = this.gameRepository.All().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            return query.To<T>().ToList();
        }

        public int GetSearchedCount(string search)
        {
            var query = this.gameRepository.All().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }

            return query.Count();
        }

        public IEnumerable<T> GetLatest<T>(int count)
        {
            return this.gameRepository.All()
               .OrderByDescending(x => x.Id)
               .Take(count)
               .To<T>().ToList();
        }

        public IEnumerable<T> SortAToZ<T>()
        {
            return this.gameRepository.All()
             .OrderBy(x => x.Name)
             .To<T>().ToList();
        }

        IEnumerable<T> IGamesService.PaginationGames<T>(int id, IEnumerable<T> data, int max)
        {
            int skip = (id - 1) * max;
            var resultData = data.Skip(skip).Take(max).ToList();
            int pageCount = (int)Math.Ceiling(data.Count() / (decimal)max);
            return resultData;
        }

        public IEnumerable<T> SortDateAdded<T>()
        {
            return this.gameRepository.All()
             .OrderBy(x => x.CreatedOn)
             .To<T>().ToList();
        }
    }
}
