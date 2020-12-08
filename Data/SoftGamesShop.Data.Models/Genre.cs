namespace SoftGamesShop.Data.Models
{
    using System.Collections.Generic;

    using SoftGamesShop.Data.Common.Models;

    public class Genre : BaseDeletableModel<int>
    {
        public Genre()
        {
            this.Games = new HashSet<GameGenres>();
        }

        public string Name { get; set; }

        public ICollection<GameGenres> Games { get; set; }
    }
}
