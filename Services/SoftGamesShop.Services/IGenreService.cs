namespace SoftGamesShop.Services
{
    using System.Collections.Generic;

    public interface IGenreService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
