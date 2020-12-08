namespace SoftGamesShop.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;

   public class CommentsService:ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(
            IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(int gameId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                GameId = gameId,
                UserId = userId,
            };
            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public bool IsInPostId(int commentId, int gameId)
        {
            var commentGameId = this.commentsRepository.All().Where(x => x.Id == commentId)
                .Select(x => x.GameId).FirstOrDefault();
            return commentGameId == gameId;
        }
    }
}
