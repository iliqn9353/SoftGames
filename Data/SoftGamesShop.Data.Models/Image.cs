﻿namespace SoftGamesShop.Data.Models
{
    using System;

    using SoftGamesShop.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

    }
}
