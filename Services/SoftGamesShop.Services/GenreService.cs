namespace SoftGamesShop.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;

    public class GenreService : IGenreService
    {
        private readonly IDeletableEntityRepository<Genre> genreRepository;

        public GenreService(
            IDeletableEntityRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Genre> query =
               this.genreRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.genreRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public T GetByName<T>(string name)
        {
            var genre = this.genreRepository.All()
               .Where(x => x.Name.Replace(" ", "-") == name.Replace(" ", "-"))
               .To<T>().FirstOrDefault();
            return genre;
        }
    }
}
