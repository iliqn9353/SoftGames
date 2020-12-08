namespace SoftGamesShop.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SoftGamesShop.Data.Models;

    public class PlatformSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Platforms.Any())
            {
                return;
            }

            var platforms = new List<string> { "Pc", "Playstation 1", "X-Box Classic", "Mac", "Playstation 2", "Playstation 3",
            "Playstation 4", "X-Box 360", "X-Box ONE", };
            foreach (var platform in platforms)
            {
                await dbContext.Platforms.AddAsync(new Platform
                {
                    Type = platform,
                });
            }
        }
    }
}
