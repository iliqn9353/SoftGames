using Microsoft.EntityFrameworkCore;
using SoftGamesShop.Data;
using SoftGamesShop.Data.Models;
using SoftGamesShop.Data.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SoftGamesShop.Services.Data.Tests
{
   public class VoteServiceTests
    {
        [Fact]
        public async Task TwoDownVotesShouldCountOnce()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfRepository<Vote>(new ApplicationDbContext(options.Options));
            var service = new VotesService(repository);

            for (int i = 0; i < 100; i++)
            {
                await service.VotesAsync(1, "1", false);
            }

            for (int i = 0; i < 100; i++)
            {
                await service.VotesAsync(1, "2", false);
            }

            var votes = service.GetAllVotes(1);
            Assert.Equal(-2, votes);
        }
    }
}
