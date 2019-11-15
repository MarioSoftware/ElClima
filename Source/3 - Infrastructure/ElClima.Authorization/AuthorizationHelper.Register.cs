using ElClima.Authorization.IdentityHelper;
using ElClima.DataAccess;
using ElClima.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElClima.Authorization
{
    public static partial class AuthorizationHelper
    {
        public static RegisterResultDto Register(string dni, string apellido, string nombre, string password, string email)
        { 
            var nameValid="";
            if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(apellido))
            {
                nombre = nombre.Trim();
                apellido = apellido.Trim();

                nameValid = string.Concat(nombre.Replace(" ", string.Empty) + apellido.Replace(" ", string.Empty)); 
            } 

            var signInManager = Configuration.GetService<SignInManager<ApplicationUser>>();

            var user = new ApplicationUser { dni = dni, apellido = apellido, UserName = nameValid, Email= email};

            var result = Task.Run(() => signInManager.UserManager.CreateAsync(user, password)).Result;

            return new RegisterResultDto
            {
                success = result.Succeeded,
                messages = GetErrorMessages(result)
            };
             
        }

        private static List<string> GetErrorMessages(IdentityResult result)
        {
            List<string> messages= new List<string>();
            if (result?.Errors != null)
            {
                foreach (var item in result.Errors)
                {
                    if (!string.IsNullOrWhiteSpace(Handler.GetErrorMessages(item.Code)))
                    {
                        messages.Add(Handler.GetErrorMessages(item.Code));
                    } 
                }
            }

            return messages;
        }
    }
}
