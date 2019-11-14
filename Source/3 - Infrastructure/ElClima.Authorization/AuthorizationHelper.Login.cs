using ElClima.ApplicationServices.Services.Social.Sujeto;
using ElClima.DataAccess;
using ElClima.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ElClima.Authorization
{
    public static partial class AuthorizationHelper
    {
        public static bool Login(string dni, string password, string email)
        {
            var signInManager = Configuration.GetService<SignInManager<ApplicationUser>>();
            var personService = new PersonaService();

            var user = personService.GetOneByDniAndEmail(dni, email);

            if(user == null)
            {
                throw new ElClimaException("No existe un Usuario con este DNI y este Email"); 
            }

            var loginResult = Task.Run(() => signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false)).Result;

            return loginResult.Succeeded;
        } 
    }
}
