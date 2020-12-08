namespace SoftGamesShop.Web.ViewModels.Collection
{
    using System.Collections.Generic;

    using SoftGamesShop.Web.ViewModels.Pages;

    public class MyCollectionListViewModel : PageViewModel
    {
        public IEnumerable<MyCollectionViewModel> Games { get; set; }
    }
}
