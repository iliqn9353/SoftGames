namespace SoftGamesShop.Web.Areas.Administration.Controllers
{
    using SoftGamesShop.Common;
    using SoftGamesShop.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
