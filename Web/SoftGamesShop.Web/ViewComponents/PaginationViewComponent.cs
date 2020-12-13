namespace SoftGamesShop.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using SoftGamesShop.Web.ViewModels;

    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PaginationViewModel model)
        {
            return this.View(model);
        }
    }
}
