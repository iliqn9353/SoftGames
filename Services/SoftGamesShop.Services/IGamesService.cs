namespace SoftGamesShop.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SoftGamesShop.Web.ViewModels.Game;

    public interface IGamesService
    {
        Task CreateGame(AddGameInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 5);

        IEnumerable<T> GetForSearch<T>();

        IEnumerable<T> GetByName<T>(string search, int page, int itemsPerPage = 5);

        int GetCount();

        T GetById<T>(int id);
    }
}
