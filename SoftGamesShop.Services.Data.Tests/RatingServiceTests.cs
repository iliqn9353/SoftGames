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
    public class RatingServiceTests
    {
        public class MyTestGameAll : IMapFrom<Rating>
        {
            public string Name { get; set; }
        }
        [Fact]
        public async Task TestGetAll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
            repositoryRating.AddAsync(new Rating { Name = "test" }).GetAwaiter().GetResult();
            repositoryRating.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new RatingService(repositoryRating);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameAll).Assembly);


            var ratings = service.GetAll<MyTestGameAll>();
            Assert.Equal(1, ratings.Count());
        }

        [Fact]
        public async Task TestGetAllKeyValue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repositoryRating = new EfDeletableEntityRepository<Rating>(new ApplicationDbContext(options.Options));
            repositoryRating.AddAsync(new Rating { Name = "test" }).GetAwaiter().GetResult();
            repositoryRating.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new RatingService(repositoryRating);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameAll).Assembly);


            var rating = service.GetAllAsKeyValuePairs();
            Assert.Equal(1, rating.Count());
        }
    }
}
