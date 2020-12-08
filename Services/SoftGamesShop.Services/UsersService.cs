namespace SoftGamesShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;
    using SoftGamesShop.Web.ViewModels.Collection;
    using SoftGamesShop.Web.ViewModels.Game;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<UserCollection> userRepository;
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(
            IDeletableEntityRepository<UserCollection> userRepository,
            IDeletableEntityRepository<Game> gameRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.gameRepository = gameRepository;
            this.userManager = userManager;
        }

        public async Task AddGameToUserCollection(string name, string userId, int gameId)
        {
            if (this.userRepository.All().Any(x => x.ApplicationUserId == userId && x.GameId == gameId))
            {
                return;
            }
            var item = new UserCollection
            {
                ApplicationUserId = userId,
                GameId=gameId,
            };

            await this.userRepository.AddAsync(item);

            await this.userRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var games = this.gameRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)

                .To<T>().ToList();
            return games;
        }

        public IEnumerable<MyCollectionViewModel> GetByUserId(string userId)
        {
            var game= this.userRepository.All().Where(x => x.ApplicationUserId == userId)
                .Select(x => new MyCollectionViewModel
                {
                   ApplicationUserId=x.ApplicationUserId,
                   GameId=x.GameId,
                   Name=x.Game.Name,
                   ImageUrl = x.Game.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Game.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/Games/" + x.Game.Images.FirstOrDefault().Id + "." + x.Game.Images.FirstOrDefault().Extension,
        }).ToList();

            return game;
        }

        public async Task RemoveGameFromUserCollection(string userId, int gameId)
        {
            var userGame = this.userRepository.All().SingleOrDefault(x => x.GameId == gameId && x.ApplicationUserId == userId);
            this.userRepository.Delete(userGame);
            await this.userRepository.SaveChangesAsync();
        }
     
    }
}
