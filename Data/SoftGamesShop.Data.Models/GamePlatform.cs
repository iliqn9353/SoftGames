﻿namespace SoftGamesShop.Data.Models
{
    using SoftGamesShop.Data.Common.Models;

    public class GamePlatform : BaseDeletableModel<int>
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public int PlatformId { get; set; }

        public virtual Platform Platform { get; set; }
    }
}
