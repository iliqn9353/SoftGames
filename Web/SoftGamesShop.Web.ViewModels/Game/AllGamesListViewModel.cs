namespace SoftGamesShop.Web.ViewModels.Game
{
    using System.Collections.Generic;

    using SoftGamesShop.Web.ViewModels.Pages;

    public class AllGamesListViewModel : PageViewModel
    {
        public IEnumerable<AllGamesViewModel> Games { get; set; }
    }
}
