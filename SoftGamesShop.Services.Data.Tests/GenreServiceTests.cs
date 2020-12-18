using Microsoft.EntityFrameworkCore;
using SoftGamesShop.Data;
using SoftGamesShop.Data.Models;
using SoftGamesShop.Data.Repositories;
using SoftGamesShop.Services.Mapping;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SoftGamesShop.Services.Data.Tests
{
   public class GenreServiceTests
    {
        public class MyTestGameAll : IMapFrom<Genre>
        {
            public string Name { get; set; }
        }
        [Fact]
        public async Task TestGetAll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            repositoryGenre.AddAsync(new Genre { Name = "test" }).GetAwaiter().GetResult();
            repositoryGenre.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GenreService(repositoryGenre);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameAll).Assembly);


            var genre = service.GetAll<MyTestGameAll>();
            Assert.Equal(1, genre.Count());
        }

        public class MyTestGameSearch : IMapFrom<Genre>
        {

            public string Name { get; set; }
        }

        [Theory]
        [InlineData("icko")]
        [InlineData("goshko")]
        public async Task TestGameSearch(string search)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            repositoryGenre.AddAsync(new Genre { Name = search }).GetAwaiter().GetResult();
            repositoryGenre.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GenreService(repositoryGenre);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameSearch).Assembly);
            var game = service.GetByName<MyTestGameSearch>(search);
            Assert.Equal(search,game.Name);
        }

        [Fact]
        public async Task TestGetAllKeyValue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            repositoryGenre.AddAsync(new Genre { Name = "test" }).GetAwaiter().GetResult();
            repositoryGenre.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GenreService(repositoryGenre);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameAll).Assembly);


            var genre = service.GetAllAsKeyValuePairs();
            Assert.Equal(1, genre.Count());
        }
    }
}
