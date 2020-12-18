using Microsoft.EntityFrameworkCore;
using SoftGamesShop.Data;
using SoftGamesShop.Data.Models;
using SoftGamesShop.Data.Repositories;
using SoftGamesShop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SoftGamesShop.Services.Data.Tests
{
   public class CommentServiceTests
    {
        public class MyTestComment : IMapFrom<Comment>
        {
            public int CommentId { get; set; }
            public string Content { get; set; }
            public int GameId { get; set; }
            public int? ParentId { get; set; }
        }
        [Theory]
        [InlineData(1,"bcd","Hiall")]
       
        public async Task ComentIsInPost(int gameId, string userId, string content, int? parentId = null)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));
            var commenta = new Comment { Id = 1, Content = "test", GameId = 1, ParentId = 2 };
            repository.AddAsync(commenta).GetAwaiter().GetResult();
            repository.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new CommentsService(repository);
            AutoMapperConfig.RegisterMappings(typeof(MyTestComment).Assembly);

            var comment = service.IsInPostId(commenta.Id,gameId);
            Assert.Equal(1,commenta.Id);
        }

        [Theory]
        [InlineData(1, "bcd", "Hiall")]

        public async Task CreateComment(int gameId, string userId, string content, int? parentId = null)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));
            var commenta = new Comment { Id = 1, Content = "test", GameId = 1, ParentId = 2 };
            repository.AddAsync(commenta).GetAwaiter().GetResult();
            repository.SaveChangesAsync().GetAwaiter().GetResult();
            var service = new CommentsService(repository);
            AutoMapperConfig.RegisterMappings(typeof(MyTestComment).Assembly);
            var user = new ApplicationUser
            {
                Id=Guid.NewGuid().ToString(),
            };
            var viewModel = new Comment
            {
                Content = content,
                ParentId = parentId,
                GameId = gameId,
                UserId = userId,
            };
                var postId = service.Create(viewModel.GameId, user.Id,viewModel.Content,viewModel.ParentId);
            Assert.True(postId.IsCompleted);
        }
    }
}
