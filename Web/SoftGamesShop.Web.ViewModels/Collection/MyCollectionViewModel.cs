namespace SoftGamesShop.Web.ViewModels.Collection
{
    using System;

    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;

    public class MyCollectionViewModel : IMapFrom<Game>
    {
        public int GameId { get; set; }

        public string ApplicationUserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ImageUrl { get; set; }

    }
}
