namespace SoftGamesShop.Web.ViewModels.Genre
{
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;

    public class GenreViewModel : IMapFrom<Genre>, IMapFrom<GameGenres>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
