namespace SoftGamesShop.Web.ViewModels.Pages
{
    using System;

    public class PageViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.GamesCount / this.ItemsPerPage);

        public int GamesCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
