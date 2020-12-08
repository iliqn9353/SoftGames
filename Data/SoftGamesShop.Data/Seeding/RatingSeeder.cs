namespace SoftGamesShop.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SoftGamesShop.Data.Models;

    public class RatingSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Ratings.Any())
            {
                return;
            }

            var ratings = new List<string> { "AO - Adult Only 18+", "E - Everyone", "E10+ - Everyone 10+", "EC - Early Childhood", "M - Mature 17+", "Not Rated", "RP - Rating Pending", "T - Teen", };
            foreach (var rating in ratings)
            {
                await dbContext.Ratings.AddAsync(new Rating
                {
                    Name = rating,
                });
            }

        }
    }
}