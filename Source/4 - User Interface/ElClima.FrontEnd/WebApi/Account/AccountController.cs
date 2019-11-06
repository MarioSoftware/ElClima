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

            if (!Authorization.AuthorizationHelper.Register(data.dni, data.apellido, data.nombre, data.password))
            {
                throw new ElClimaException("No se ha podido registrar la nueva cuenta, porfavor intente nuevamente.");
            }
        }
    }
}
