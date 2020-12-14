namespace SoftGamesShop.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SoftGamesShop.Web.ViewModels.Game;

    public interface IGamesService
    {
        Task CreateGame(AddGameInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> SortAToZ<T>();

        IEnumerable<T> SortZToA<T>();

        IEnumerable<T> SortDateAdded<T>();

        IEnumerable<T> SortDateAddedNew<T>();

        IEnumerable<T> PaginationGames<T>(
            int id,
            IEnumerable<T> data,
            int max);

        IEnumerable<T> GetLatest<T>(int count);

        IEnumerable<T> GetByName<T>(string search);

        int GetCount();

        int GetSearchedCount(string search);

        T GetById<T>(int id);
    }
}
