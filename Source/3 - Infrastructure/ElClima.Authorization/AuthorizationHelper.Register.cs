using ElClima.DataAccess;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ElClima.Authorization
{
    public static partial class AuthorizationHelper
    {
        public static bool Register(string dni, string apellido, string nombre, string password)
        {
            var signInManager = Configuration.GetService<SignInManager<ApplicationUser>>();

            var user = new ApplicationUser { dni = dni, apellido = apellido, UserName = nombre };

            var result = Task.Run(() => signInManager.UserManager.CreateAsync(user, password)).Result;

            if (result.Succeeded)
                return true;

            return false;
        }
    }
}
