namespace SoftGamesShop.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;

    public class LoginController : Controller
    {
        private readonly IAuthenticationSchemeProvider authenticationSchemeProvider;

        public LoginController(IAuthenticationSchemeProvider authenticationSchemeProvider)
        {
            this.authenticationSchemeProvider = authenticationSchemeProvider;
        }

        public async Task<IActionResult> Login()
        {
            var allSchemeProvider = (await this.authenticationSchemeProvider.GetAllSchemesAsync())
                .Select(n => n.DisplayName).Where(n => !string.IsNullOrEmpty(n));

            return this.View(allSchemeProvider);
        }

        public IActionResult SignIn(string provider)
        {
            return this.Challenge(new AuthenticationProperties { RedirectUri = "/" }, provider);
        }

        public async Task<IActionResult> SignOut()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
