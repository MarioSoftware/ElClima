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
            return View("Login/Login");
        }

        public IActionResult RedirectFromLogin()
        {
            var returnUrl = HttpContext.Request.Query["ReturnUrl"].ToString();

            var userPerson = Authorization.AuthorizationHelper.GetCurrentLoggedUser(HttpContext);

            if (userPerson != null)
            {
                if (!string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);

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