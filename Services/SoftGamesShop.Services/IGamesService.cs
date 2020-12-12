namespace SoftGamesShop.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SoftGamesShop.Web.ViewModels.Game;

    public interface IGamesService
    {
        Task CreateGame(AddGameInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 8);

        IEnumerable<T> GetForSearch<T>();

        IEnumerable<T> GetLatest<T>(int count);

        IEnumerable<T> GetByName<T>(string search);

        int GetCount();

        int GetSearchedCount(string search);

        T GetById<T>(int id);
    }
}
