namespace SoftGamesShop.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using SoftGamesShop.Web.ViewModels.Game;

    public class IndexViewModel
    {
        public IEnumerable<AllGamesViewModel> LatestGame { get; set; }

        public int GamesCount { get; set; }

        public int GenreCount { get; set; }

        public int PlatformsCount { get; set; }

        public int ImagesCount { get; set; }
    }
}
