using ElClima.Domain.Core.Exceptions;
using ElClima.FrontEnd.WebApi.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace ElClima.FrontEnd.WebApi.Account
{
    [Route("/api/[controller]")] 
    public class AccountController : BaseWebApiController
    {
        [HttpPut]
        [Route("/api/Account/Register")]
        public void Register([FromBody] RegisterDataDto data)
        {
            var result = Authorization.AuthorizationHelper.Register(data.dni, data.apellido, data.nombre, data.password); 

            if(!result.success)            
                throw new ElClimaException(result.messages);            
        }
    }
}
