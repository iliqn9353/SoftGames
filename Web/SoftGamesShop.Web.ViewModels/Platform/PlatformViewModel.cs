namespace SoftGamesShop.Web.ViewModels.Platform
{
    using SoftGamesShop.Data.Models;
    using SoftGamesShop.Services.Mapping;

    public class PlatformViewModel : IMapFrom<Platform>, IMapFrom<GamePlatform>
    {
        public int Id { get; set; }

        public string Type { get; set; }
    }
}
