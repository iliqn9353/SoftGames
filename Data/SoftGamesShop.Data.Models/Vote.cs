﻿namespace SoftGamesShop.Data.Models
{
    using SoftGamesShop.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

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
