namespace SoftGamesShop.Services
{
    using System.Collections.Generic;

    public interface IRatingService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
