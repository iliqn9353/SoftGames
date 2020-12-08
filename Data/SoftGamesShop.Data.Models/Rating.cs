namespace SoftGamesShop.Data.Models
{
    using System.Collections.Generic;

    using SoftGamesShop.Data.Common.Models;

    public class Rating : BaseDeletableModel<int>
    {
        public Rating()
        {
            this.Games = new HashSet<GameRating>();
        }

        public string Name { get; set; }

        public virtual ICollection<GameRating> Games { get; set; }
    }
}
