namespace SoftGamesShop.Web.ViewModels.Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Web.ViewModels.Genre;
    using SoftGamesShop.Web.ViewModels.Platform;
    using SoftGamesShop.Web.ViewModels.Rating;

    public class AddGameInputModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the game Name (Title)")]
        [StringLength(50, ErrorMessage = "Name must be at least {2} and not more than {1} symbols.", MinimumLength = 3)]
        [Display(Name = "Game Name (Title)", Prompt = "Game name goes here...")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a description")]
        [StringLength(2000, ErrorMessage = "Description must be at least {2} and not more than {1} symbols.", MinimumLength = 10)]
        [Display(Name = "Game Description", Prompt = "No description is currently available for this game, please feel free to add one.")]
        public string Description { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^(https?\:\/\/)?(www\.youtube\.com|youtu\.?be)\/.+$",
       ErrorMessage = "Only YouTube Links Allowed!")]
        [Display(Name = "Trailer (YouTube)",Prompt = "https://www.youtube.com/watch?v=oHg5SJYRHA0&ab_channel=cotter548")]
        public string Trailer { get; set; }

        [Range(1, 32, ErrorMessage = "Please enter a number between 1 and 32.")]
        [Display(Name = "Players Count")]
        public int PlayersCount { get; set; }

        public bool CoOp { get; set; }

        [Display(Prompt = "Blizzard,EA,Rockstar Games etc...")]
        public string Developer { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public int PlatformId { get; set; }

        public IEnumerable<PlatformViewModel> Platforms { get; set; }

        public int RatingId { get; set; }

        public IEnumerable<RatingViewModel> Ratings { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
