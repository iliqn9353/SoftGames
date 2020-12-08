using SoftGamesShop.Services.Mapping;


namespace SoftGamesShop.Web.ViewModels.Genre
    
{

    using SoftGamesShop.Data.Models;

    public class GenreViewModel : IMapFrom<Genre>, IMapFrom<GameGenres>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
    }
}
