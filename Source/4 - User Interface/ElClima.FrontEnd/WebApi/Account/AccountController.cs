using ElClima.Authorization.IdentityHelper;
using ElClima.Domain.Core.Exceptions;
using ElClima.FrontEnd.WebApi.BaseController;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ElClima.FrontEnd.WebApi.Account
{
    [Route("/api/[controller]")] 
    public class AccountController : BaseWebApiController
    {
        [HttpPut]
        [Route("/api/Account/Register")]
        public RegisterResultDto Register([FromBody] RegisterDataDto data)
        {
            return Authorization.AuthorizationHelper.Register(data.dni, data.apellido, data.nombre, data.password);  
        }
    }
}
