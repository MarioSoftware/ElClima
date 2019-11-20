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
            try
            {
                return new LoginDataDto { key = Authorization.AuthorizationHelper.GenerateEncriptedKey(HttpContext, data) };   
            }
            catch (Exception)
            {
                throw new ElClimaException("Ha ocurrido un error al intentar obtener la clave de encriptacion");
            } 
        }

        [HttpPut]
        [Route("/api/Account/Login")]
        public void Login([FromBody] LoginDataDto data)
        {
            Authorization.AuthorizationHelper.DescriptLoginData(HttpContext, data.data); 
        }
 
    }
}
