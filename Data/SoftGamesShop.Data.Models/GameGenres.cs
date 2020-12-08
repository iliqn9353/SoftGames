namespace SoftGamesShop.Data.Models
{
    using SoftGamesShop.Data.Common.Models;

    public class GameGenres : BaseDeletableModel<int>
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
