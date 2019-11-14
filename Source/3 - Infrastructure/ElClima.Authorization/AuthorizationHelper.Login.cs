using ElClima.ApplicationServices.Services.Social.Sujeto;
using ElClima.Authorization.IdentityHelper;
using ElClima.DataAccess;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElClima.Authorization
{
    public static partial class AuthorizationHelper
    {
        public static bool Login(string dni, string password)
        {
            var signInManager = Configuration.GetService<SignInManager<ApplicationUser>>();
            var personService = new PersonaService();

            var user = personService.GetOneByDni(dni);

            if(user == null)
            {
                return false;
            }

            //signInManager.PasswordSignInAsync

                return false;
        }
      
    }
}
