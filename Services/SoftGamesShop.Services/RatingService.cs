namespace SoftGamesShop.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;

    public class RatingService : IRatingService
    {
        private readonly IDeletableEntityRepository<Rating> ratingRepository;

        public RatingService(
            IDeletableEntityRepository<Rating> ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Rating> query =
               this.ratingRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.ratingRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
