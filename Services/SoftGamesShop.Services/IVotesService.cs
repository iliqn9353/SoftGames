namespace SoftGamesShop.Services
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task VotesAsync(int gameId, string userId, bool isUpVote);

        int GetAllVotes(int gameId);
    }
}
