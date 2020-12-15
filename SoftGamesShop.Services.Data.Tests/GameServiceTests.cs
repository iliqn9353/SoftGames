using Microsoft.EntityFrameworkCore;
using Moq;
using SoftGamesShop.Data;
using SoftGamesShop.Data.Common.Repositories;
using SoftGamesShop.Data.Models;
using SoftGamesShop.Data.Repositories;
using SoftGamesShop.Services.Mapping;
using SoftGamesShop.Web.ViewModels.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SoftGamesShop.Services.Data.Tests
{
   
    public class GameServiceTests
    {

        public class MyTestGameById : IMapFrom<Game>
        {
            public string Name { get; set; }
        }
        [Fact]
        public async Task TestGetById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString());

            
            var repositoryGame = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            var repositoryPlatform = new EfDeletableEntityRepository<Platform>(new ApplicationDbContext(options.Options));
            var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
            repositoryGame.AddAsync(new Game { Name = "test" }).GetAwaiter().GetResult();
            repositoryGame.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GameService(repositoryGame, repositoryGenre, repositoryPlatform, repositoryRating);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameById).Assembly);
            var game = service.GetById<MyTestGameById>(1);
            Assert.Equal("test", game.Name);

        }
        public class MyTestGameAll : IMapFrom<Game>
        {
            public string Name { get; set; }
        }
        [Fact]
        public async Task TestGetAll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString());


            var repositoryGame = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            var repositoryPlatform = new EfDeletableEntityRepository<Platform>(new ApplicationDbContext(options.Options));
            var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
            repositoryGame.AddAsync(new Game { Name = "abc" }).GetAwaiter().GetResult();
            repositoryGame.AddAsync(new Game { Name = "abcd" }).GetAwaiter().GetResult();
            repositoryGame.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GameService(repositoryGame, repositoryGenre, repositoryPlatform, repositoryRating);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameAll).Assembly);
            var game = service.GetAll<MyTestGameAll>();
            Assert.Equal(2, game.Count());

        }
        public class MyTestGameAToZ : IMapFrom<Game>
        {
            public string Name { get; set; }
        }

        [Fact]
        public async Task TestSortAToZ()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString());


            var repositoryGame = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            var repositoryPlatform = new EfDeletableEntityRepository<Platform>(new ApplicationDbContext(options.Options));
            var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
            repositoryGame.AddAsync(new Game { Name = "abc" }).GetAwaiter().GetResult();
            repositoryGame.AddAsync(new Game { Name = "zyx" }).GetAwaiter().GetResult();
            repositoryGame.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GameService(repositoryGame, repositoryGenre, repositoryPlatform, repositoryRating);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameAToZ).Assembly);
            var game = service.SortAToZ<MyTestGameAToZ>().FirstOrDefault();
            Assert.Equal("abc", game.Name);

        }

        public class MyTestGameZToA : IMapFrom<Game>
        {
            public string Name { get; set; }
        }

        [Fact]
        public async Task TestSortZToA()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString());


            var repositoryGame = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            var repositoryPlatform = new EfDeletableEntityRepository<Platform>(new ApplicationDbContext(options.Options));
            var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
            repositoryGame.AddAsync(new Game { Name = "abc" }).GetAwaiter().GetResult();
            repositoryGame.AddAsync(new Game { Name = "zyx" }).GetAwaiter().GetResult();
            repositoryGame.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GameService(repositoryGame, repositoryGenre, repositoryPlatform, repositoryRating);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameZToA).Assembly);
            var game = service.SortZToA<MyTestGameZToA>().FirstOrDefault();
            Assert.Equal("zyx", game.Name);

        }

        public class MyTestGameLatest : IMapFrom<Game>
        {

            public string Name { get; set; }
        }

        [Fact]
        public async Task TestSortLatest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString());


            var repositoryGame = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            var repositoryPlatform = new EfDeletableEntityRepository<Platform>(new ApplicationDbContext(options.Options));
            var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
            repositoryGame.AddAsync(new Game { Name = "first" }).GetAwaiter().GetResult();
            repositoryGame.AddAsync(new Game { Name = "second" }).GetAwaiter().GetResult();
            repositoryGame.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GameService(repositoryGame, repositoryGenre, repositoryPlatform, repositoryRating);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameLatest).Assembly);
            var game = service.GetLatest<MyTestGameLatest>(2).First();
            Assert.Equal("second", game.Name);

        }

        public class MyTestGameAdded : IMapFrom<Game>
        {

            public string Name { get; set; }
        }

        [Fact]
        public async Task TestSortAdded()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString());


            var repositoryGame = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            var repositoryPlatform = new EfDeletableEntityRepository<Platform>(new ApplicationDbContext(options.Options));
            var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
            repositoryGame.AddAsync(new Game { Name = "now" }).GetAwaiter().GetResult();
            repositoryGame.AddAsync(new Game { Name = "later" }).GetAwaiter().GetResult();
            repositoryGame.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GameService(repositoryGame, repositoryGenre, repositoryPlatform, repositoryRating);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameAdded).Assembly);
            var game = service.SortDateAdded<MyTestGameAdded>().Last();
            Assert.Equal("later", game.Name);

        }

        public class MyTestGameAddedNew : IMapFrom<Game>
        {

            public string Name { get; set; }
        }

        [Fact]
        public async Task TestSortAddedNew()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString());


            var repositoryGame = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            var repositoryPlatform = new EfDeletableEntityRepository<Platform>(new ApplicationDbContext(options.Options));
            var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
            repositoryGame.AddAsync(new Game { Name = "now" }).GetAwaiter().GetResult();
            repositoryGame.AddAsync(new Game { Name = "later" }).GetAwaiter().GetResult();
            repositoryGame.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GameService(repositoryGame, repositoryGenre, repositoryPlatform, repositoryRating);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameAddedNew).Assembly);
            var game = service.SortDateAddedNew<MyTestGameAddedNew>().First();
            Assert.Equal("later", game.Name);

        }

        public class MyTestGameSearch : IMapFrom<Game>
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
            //var search = string.Empty;

            var repositoryGame = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var repositoryGenre = new EfDeletableEntityRepository<Genre>(new ApplicationDbContext(options.Options));
            var repositoryPlatform = new EfDeletableEntityRepository<Platform>(new ApplicationDbContext(options.Options));
            var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
            repositoryGame.AddAsync(new Game { Name = search }).GetAwaiter().GetResult();
            
          
            repositoryGame.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new GameService(repositoryGame, repositoryGenre, repositoryPlatform, repositoryRating);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameSearch).Assembly);
            var game = service.GetByName<MyTestGameSearch>(search);
            Assert.Single(game);
        }

    }
}