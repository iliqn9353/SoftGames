namespace SoftGamesShop.Web.ViewModels.Rating
{

    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;

    public class RatingViewModel : IMapFrom<Rating>, IMapFrom<GameRating>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
