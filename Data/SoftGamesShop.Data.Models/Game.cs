namespace SoftGamesShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SoftGamesShop.Data.Common.Models;

    public class Game : BaseDeletableModel<int>
    {
        public Game()
        {
            this.GamePlatforms = new HashSet<GamePlatform>();
            this.Images = new HashSet<Image>();
            this.GameGenres = new HashSet<GameGenres>();
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
            this.GameRatings = new HashSet<GameRating>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Trailer { get; set; }

        [Range(1, 4)]
        public int PlayersCount { get; set; }

        public bool CoOp { get; set; }

        public string Developer { get; set; }

        public string SearchText { get; set; }

        public string CreatedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }

        public int PlatformId { get; set; }

        public Platform Platforms { get; set; }

        public virtual ICollection<GamePlatform> GamePlatforms { get; set; }

        public int GenreId { get; set; }

        public Genre Genres { get; set; }

        public int RatingId { get; set; }

        public Rating Rating { get; set; }

        public ICollection<GameGenres> GameGenres { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<GameRating> GameRatings { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
