using ElClima.ApplicationServices.Services.Social.Sujeto;
using ElClima.Authorization.Session;
using ElClima.DataAccess;
using ElClima.Domain.Model.Models.Social.Sujetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ElClima.Authorization
{
    public static partial class AuthorizationHelper
    {
        private static readonly object CurrentLoggerUsserLockObject = new object();

        public static Persona GetCurrentLoggedUser(HttpContext context)
        {

            //return GetLoggedUserFromDatabase(context);

            const string currentUserKey = "CurrentLoggedUser";

            // si el usuario lo tenemos en session, lo deserealizamos
            var currentLoggedUser = context.Session.GetObjectFromJson<Persona>(currentUserKey);

            if (currentLoggedUser != null)
                return currentLoggedUser;

            lock (CurrentLoggerUsserLockObject)
            {
                // Else, we got it form DataBase
                currentLoggedUser = GetLoggedUserFromDatabase(context);

                // We save it in Session , serialized
                context.Session.SetObjectAsJson(currentUserKey, currentLoggedUser);

                return currentLoggedUser;
            }
        }

        private static Persona GetLoggedUserFromDatabase(HttpContext context)
        {
            var signInManager = Configuration.GetService<SignInManager<ApplicationUser>>();
            var applicationUser = signInManager.UserManager.GetUserAsync(context.User).Result;
            if (applicationUser == null)
            {
                return null;
            }

            var personService = new PersonaService();

            //var uow = usuarioService.GetCurrentUnitOfWork();
            var usuarios = personService.GetByFilter(f => f.dni == applicationUser.dni && f.email == applicationUser.Email);
            if (usuarios.Count == 0)
            {
                //There is not User, should had not started Session
                return null;
            }

            return usuarios[0];
        }
    }
}
