using ElClima.Authorization.IdentityHelper;
using ElClima.DataAccess;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ElClima.Authorization
{
    public static partial class AuthorizationHelper
    {
        public static RegisterResultDto Register(string dni, string apellido, string nombre, string password)
        {
            var signInManager = Configuration.GetService<SignInManager<ApplicationUser>>();

            var user = new ApplicationUser { dni = dni, apellido = apellido, UserName = nombre };

            var result = Task.Run(() => signInManager.UserManager.CreateAsync(user, password)).Result;

            return new RegisterResultDto
            {
                success = result.Succeeded,
                messages = !result.Succeeded ? GetErrorMessages(result) : ""
            };
             
        }

        private static string GetErrorMessages(IdentityResult result)
        {
            string messages = "";
            if (result?.Errors != null)
            {
                foreach (var item in result.Errors)
                {
                    if (!string.IsNullOrWhiteSpace(Handler.GetErrorMessages(item.Code)))
                    {
                        messages += Handler.GetErrorMessages(item.Code);
                    } 
                }
            }

            return messages;
        }
    }
}
