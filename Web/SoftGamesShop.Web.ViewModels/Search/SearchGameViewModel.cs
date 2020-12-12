﻿namespace SoftGamesShop.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using SoftGamesShop.Web.ViewModels.Game;
    using SoftGamesShop.Web.ViewModels.Pages;

    public class SearchGameViewModel 
    {
        public IEnumerable<AllGamesViewModel> Games { get; set; }
    }
}
