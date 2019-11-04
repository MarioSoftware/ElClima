using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace ElClima.Authorization
{
    public static partial class AuthorizationHelper
    {
        private static readonly object PermissionLockObject = new object();

        internal static bool CheckForPermission(bool isDevelopment, AuthorizationHandlerContext context, string operationName)
        {

            var email = context.User.Identity.Name; /*TODO: Find out dni property from Context*/
            var permissionKey = email + "|" + operationName;
            Dictionary<string, bool> authorizationDictionary;

            lock (PermissionLockObject)
            {
                var memoryCache = Configuration.GetService<IMemoryCache>();

                if (!memoryCache.TryGetValue("AuthorizationDictionary", out authorizationDictionary))
                {
                    authorizationDictionary = new Dictionary<string, bool>();

                    var item = memoryCache.CreateEntry("AuthorizationDictionary");
                    item.Value = authorizationDictionary;

                    memoryCache.Set("AuthorizationDictionary", authorizationDictionary);
                }

                if (authorizationDictionary.ContainsKey(permissionKey))
                {
                    return authorizationDictionary[permissionKey];
                }

                // No la tenemos, creamos la clave y mas abajo la seteamos
                authorizationDictionary.Add(permissionKey, false);
            }


            // Obtenemos el usuario actual
            var personService = new ApplicationServices.Services.Social.Sujeto.PersonaService();
            var resultado = personService.CheckForPermission(email, operationName);


            lock (PermissionLockObject)
            {
                // volvemos a bloquear el diccionario por las dudas hayan borrando la cache cuando consultaba la base de datos
                if (authorizationDictionary.ContainsKey(permissionKey))
                {
                    authorizationDictionary[permissionKey] = resultado;
                }
            }

            return resultado;
        }

        public static void ClearPermissionCache()
        {
            lock (PermissionLockObject)
            {
                var memoryCache = Configuration.GetService<IMemoryCache>();

                // Intentamos obtener el diccionario de autorizaciones
                if (memoryCache.TryGetValue("AuthorizationDictionary",
                    out Dictionary<string, bool> authorizationDictionary))
                {
                    // Si lo pudo traer, lo borramos
                    authorizationDictionary.Clear();
                }
            }
        }

    }
}
