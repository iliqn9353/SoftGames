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

            var platforms = new List<string> { "Pc", "Mac", "Sony Playstation", "Sony Playstation 2", "Sony Playstation 3",
                "Sony Playstation 4", "Sony Playstation 5", "Sony Playstation Portable", "Microsoft Xbox",
             "Microsoft Xbox 360", "Microsoft Xbox ONE", "Nintendo Wii", "Nintendo Switch", };
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
