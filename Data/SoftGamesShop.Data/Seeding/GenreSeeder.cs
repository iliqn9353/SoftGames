namespace SoftGamesShop.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SoftGamesShop.Data.Models;

    public class GenreSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genres.Any())
            {
                return;
            }

            var genres = new List<string> { "FPS", "Strategy", "RPG", "Simulator", "Racing", "Action", "MMORPG", "Horror", "Sandbox" };
            foreach (var genre in genres)
            {
                await dbContext.Genres.AddAsync(new Genre
                {
                    Name = genre,
                });
            }

        }
    }
}
