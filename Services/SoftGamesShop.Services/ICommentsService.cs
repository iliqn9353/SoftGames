using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoftGamesShop.Services
{
    public interface  ICommentsService
    {
        Task Create(int gameId, string userId, string content, int? parentId = null);

        bool IsInPostId(int commentId, int gameId);
    }
}
