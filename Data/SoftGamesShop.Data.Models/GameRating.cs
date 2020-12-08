namespace SoftGamesShop.Data.Models
{

    using SoftGamesShop.Data.Common.Models;

    public class GameRating : BaseDeletableModel<int>
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
