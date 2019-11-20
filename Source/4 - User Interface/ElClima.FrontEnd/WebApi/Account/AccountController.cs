using ElClima.Authorization.IdentityHelper;
using ElClima.Domain.Core.Exceptions;
using ElClima.Domain.Core.Utils;
using ElClima.FrontEnd.WebApi.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ElClima.FrontEnd.WebApi.Account
{
    [Route("/api/[controller]")] 
    public class AccountController : BaseWebApiController
    {
        [HttpPut]
        [Route("/api/Account/Register")]
        public RegisterResultDto Register([FromBody] RegisterDataDto data)
        {
            return Authorization.AuthorizationHelper.Register(data.dni, data.apellido, data.nombre, data.password, data.email);  
        }

        [HttpGet]
        [Route("/api/Account/GetKey/{data}")]
        public LoginDataDto GetKey(string data)
        {
            var context = HttpContext;

            var tokenEncriptado = EncodeHelper.DecodeFromBase64String(data);
            var token = EncriptionHelper.OpenSslDecrypt(tokenEncriptado, "30ce8e7a4a34jjkh4ddhjs99a4");

            var userIpAndHost = GetUserIpAddress();

            var password = EncriptionHelper.GetMd5Sum(userIpAndHost + token);


            context.Response.Cookies.Delete("5klewj23oi4uy5234sdfgkew23d");
            context.Response.Cookies.Append("5klewj23oi4uy5234sdfgkew23d", EncriptionHelper.Encrypt(password),
                new CookieOptions { Expires = DateTimeOffset.Now.AddMinutes(1) });

            var r = new LoginDataDto
            {
                key = EncriptionHelper.OpenSslEncrypt(password + userIpAndHost, "23ko4uj5o23k4u5klewj23oi4uy5234")
            };

            return r;
        }


        [HttpPut]
        [Route("/api/Account/Login")]
        public void Login([FromBody] LoginDataDto data)
        { 
            string password;
            string dni; 

            try
            {
                var context = HttpContext;
                var userIpAndHost = GetUserIpAddress();

                var encriptedData = EncodeHelper.DecodeFromBase64String(data.data);

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

                dni = EncriptionHelper.OpenSslDecrypt(dataArray[0],secondPassword);

                password = EncriptionHelper.OpenSslDecrypt(dataArray[2], secondPassword);
                 

            }
            catch (Exception)
            {

                throw new ElClimaException("Datos incorrectos. Intente nuevamente.");
            }

            if (!Authorization.AuthorizationHelper.Login(dni, password))
            {
                throw new ElClimaException("Datos incorrectos. Intente nuevamente.");
            }
        }

        public string GetUserIpAddress()
        {
            var context = HttpContext;

            return context.Request.Host.ToString();

            var ipAddress = context.Request.Headers.Keys.FirstOrDefault(c => c.ToUpper() == "HTTP_X_FORWARDED_FOR");

            if (string.IsNullOrEmpty(ipAddress))
                return context.Request.Headers.Keys.FirstOrDefault(c => c.ToUpper() == "REMOTE_ADDR");

            var addresses = ipAddress.Split(',');
            return addresses.Length != 0
                ? addresses[0]
                : context.Request.Headers.Keys.FirstOrDefault(c => c.ToUpper() == "REMOTE_ADDR");
        }
    }
}
