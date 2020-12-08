namespace SoftGamesShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using SoftGamesShop.Data.Common.Models;

    public class Vote : BaseDeletableModel<int>
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public VoteUpOrDownENUM VoteKind { get; set; }
    }
}
