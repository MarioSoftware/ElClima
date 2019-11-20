using ElClima.ApplicationServices.Services.Social.Sujeto;
using ElClima.DataAccess;
using ElClima.Domain.Core.Exceptions;
using ElClima.Domain.Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text.RegularExpressions;
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

        public static string GenerateEncriptedKey(HttpContext context, string data )
        {
            var tokenEncriptado = EncodeHelper.DecodeFromBase64String(data);
            var token = EncriptionHelper.OpenSslDecrypt(tokenEncriptado, "30ce8e7a4a34jjkh4ddhjs99a4");

            var userIpAndHost = GetUserIpAddress(context);

            var password = EncriptionHelper.GetMd5Sum(userIpAndHost + token);


            context.Response.Cookies.Delete("5klewj23oi4uy5234sdfgkew23d");
            context.Response.Cookies.Append("5klewj23oi4uy5234sdfgkew23d", EncriptionHelper.Encrypt(password),
                new CookieOptions { Expires = DateTimeOffset.Now.AddMinutes(1) });


            return EncriptionHelper.OpenSslEncrypt(password + userIpAndHost, "23ko4uj5o23k4u5klewj23oi4uy5234");
        }

        public static string GetUserIpAddress(HttpContext context)
        { 

            return context.Request.Host.ToString();

            var ipAddress = context.Request.Headers.Keys.FirstOrDefault(c => c.ToUpper() == "HTTP_X_FORWARDED_FOR");

            if (string.IsNullOrEmpty(ipAddress))
                return context.Request.Headers.Keys.FirstOrDefault(c => c.ToUpper() == "REMOTE_ADDR");

            var addresses = ipAddress.Split(',');
            return addresses.Length != 0
                ? addresses[0]
                : context.Request.Headers.Keys.FirstOrDefault(c => c.ToUpper() == "REMOTE_ADDR");
        }

        public static void DescriptLoginData(HttpContext context, string data)
        {
            string password;
            string dni;

            try
            {
                var userIpAndHost = GetUserIpAddress(context);

                var encriptedData = EncodeHelper.DecodeFromBase64String(data);

                if (!encriptedData.Contains("[---0---]"))
                {
                    //Here I should log the IpAndHost from the possible attacker
                    throw new ElClimaException("No se ha podido validar correctamente al Usuario");
                }

                var dataArray = Regex.Split(encriptedData, @"(\[---0---])");

                var myCookie = context.Request.Cookies["5klewj23oi4uy5234sdfgkew23d"];

                if (string.IsNullOrWhiteSpace(myCookie))
                {
                    throw new ElClimaException("No se ha podido validar correctamente al usuario, error de cookie");
                }

                var encriptationPassword = EncriptionHelper.Decrypt(myCookie);

                var secondPassword = encriptationPassword + userIpAndHost;

                dni = EncriptionHelper.OpenSslDecrypt(dataArray[0], secondPassword);

                password = EncriptionHelper.OpenSslDecrypt(dataArray[2], secondPassword);

            }
            catch (Exception)
            {
                throw new ElClimaException("Datos incorrectos. Intente nuevamente.");
            }

            if(!Login(dni, password))
                  throw new ElClimaException("Datos incorrectos. Intente nuevamente."); 

        }
    }
}
