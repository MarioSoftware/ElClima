using ElClima.ApplicationServices.Services.Social.Sujeto;
using ElClima.DataAccess;
using ElClima.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ElClima.Authorization
{
    public static partial class AuthorizationHelper
    {
        public static bool Login(string dni, string password)
        {
            var signInManager = Configuration.GetService<SignInManager<ApplicationUser>>();
            var personService = new PersonaService();

            var person = personService.GetOneByDni(dni);

            if(person == null)
            {
                throw new ElClimaException("No existe un Usuario con este DNI"); 
            }
            

            var loginResult = Task.Run(() => signInManager.PasswordSignInAsync(GetUserName(person.nombre,person.apellido), password, true, lockoutOnFailure: false)).Result;

            return loginResult.Succeeded;
        } 
    }
}
