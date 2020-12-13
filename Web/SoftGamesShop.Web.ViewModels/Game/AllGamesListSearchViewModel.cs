namespace SoftGamesShop.Web.ViewModels.Game
{
    using System.Collections.Generic;

    public class AllGamesListSearchViewModel
    {
        public IEnumerable<AllGamesViewModel> Games { get; set; }

        public PaginationViewModel PaginationViewModel { get; set; }
    }
}
