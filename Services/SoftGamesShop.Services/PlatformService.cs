namespace SoftGamesShop.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;

    public class PlatformService : IPlatformService
    {
        private readonly IDeletableEntityRepository<Platform> platformRepository;

        public PlatformService(
            IDeletableEntityRepository<Platform> platformRepository)
        {
            this.platformRepository = platformRepository;
        }
        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.platformRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Type,
                })
                .OrderBy(x => x.Type)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Type));
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Platform> query =
               this.platformRepository.All().OrderBy(x => x.Type);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }
    }
}
