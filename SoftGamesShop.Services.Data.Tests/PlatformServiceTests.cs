using Microsoft.EntityFrameworkCore;
using SoftGamesShop.Data;
using SoftGamesShop.Data.Models;
using SoftGamesShop.Data.Repositories;
using SoftGamesShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SoftGamesShop.Services.Data.Tests
{
    public class PlatformServiceTests
    {
        public class MyTestGameAll : IMapFrom<Platform>
        {
            public string Name { get; set; }
        }
        [Fact]
        public async Task TestGetAll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repositoryPlatform = new EfDeletableEntityRepository<Platform>(new ApplicationDbContext(options.Options));
            repositoryPlatform.AddAsync(new Platform { Type = "test" }).GetAwaiter().GetResult();
            repositoryPlatform.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new PlatformService(repositoryPlatform);
            AutoMapperConfig.RegisterMappings(typeof(MyTestGameAll).Assembly);


            var platform = service.GetAll<MyTestGameAll>();
            Assert.Equal(1, platform.Count());
        }
    }
}
