namespace SoftGamesShop.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SoftGamesShop.Web.ViewModels.Collection;
    using SoftGamesShop.Web.ViewModels.Game;

    public interface IUsersService
    {
        Task AddGameToUserCollection(string name, string userId, int gameId);

        IEnumerable<MyCollectionViewModel> GetByUserId(string userId);

        IEnumerable<T> GetAll<T>();

        Task RemoveGameFromUserCollection(string userId, int gameId);
    }
}
