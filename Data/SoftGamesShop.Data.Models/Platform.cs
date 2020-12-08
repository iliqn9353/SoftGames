namespace SoftGamesShop.Data.Models
{
    using System.Collections.Generic;

    using SoftGamesShop.Data.Common.Models;

    public class Platform : BaseDeletableModel<int>
    {
        public Platform()
        {
            this.Games = new HashSet<GamePlatform>();
        }

        public string Type { get; set; }

        public virtual ICollection<GamePlatform> Games { get; set; }
    }
}
