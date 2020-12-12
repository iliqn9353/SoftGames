namespace SoftGamesShop.Services
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int gameId, string userId, string content, int? parentId = null);

        bool IsInPostId(int commentId, int gameId);
    }
}
