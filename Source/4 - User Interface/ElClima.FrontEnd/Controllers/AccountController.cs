using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElClima.FrontEnd.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Add()
        {
            ViewBag.Id = -1;
            return View("AccountForm");
        } 

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RedirectFromLogin()
        {
            var returnUrl = HttpContext.Request.Query["ReturnUrl"].ToString();

            var user = Authorization.AuthorizationHelper.GetCurrentLoggedUser(HttpContext);

            if (user != null)
            {
                return Redirect("/Social");
            }

            return Redirect("/Account/AccessDenied");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}