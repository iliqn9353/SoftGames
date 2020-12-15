using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SoftGamesShop.Services.Data.Tests
{
   public class GameServiceTests
    {
        [Fact]
        public void TestSortByAlphabeticalCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("UniBookDbTest").Options;
            var dbContext = new ApplicationDbContext(options);

            dbContext.Add(new Book
            {
                Name = "Хари Потър",
            });

            dbContext.Add(new Book
            {
                Name = "Алената буква",
            });
            dbContext.SaveChanges();

            var bookService = new BookService(dbContext);
            var firstBook = bookService.SortByAlphabetical().FirstOrDefault();

            Assert.Equal("Алената буква", firstBook.Name);
        }
    }
}
