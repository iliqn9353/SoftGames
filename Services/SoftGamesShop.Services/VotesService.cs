namespace SoftGamesShop.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public int GetAllVotes(int gameId)
        {
            var votes = this.votesRepository.All()
                .Where(x => x.GameId == gameId).Sum(x => (int)x.VoteKind);
            return votes;
        }

        public async Task VotesAsync(int gameId, string userId, bool isUpVote)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.GameId == gameId && x.UserId == userId);
            if (vote != null)
            {
                vote.VoteKind = isUpVote ? VoteUpOrDownENUM.VoteUp : VoteUpOrDownENUM.VoteDown;
            }
            else
            {
                vote = new Vote
                {
                    GameId = gameId,
                    UserId = userId,
                    VoteKind = isUpVote ? VoteUpOrDownENUM.VoteUp : VoteUpOrDownENUM.VoteDown,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }
    }
}
