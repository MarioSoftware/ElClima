using ElClima.ApplicationServices.Services.Social.Sujeto;
using ElClima.ApplicationServices.Services.Social.Sujeto.Dtos;
using ElClima.FrontEnd.WebApi.BaseController;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElClima.FrontEnd.WebApi.Social.Sujetos
{
    [Route("/api/[controller]")]
    public class PersonaController : BaseWebApiController
    {
        private readonly PersonaService _personaService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PersonaController(IHostingEnvironment hostingEnvironment)
        {
            _personaService = new PersonaService();
            _hostingEnvironment = hostingEnvironment;
        }

        
        [HttpPost("/api/Persons/Add")]
        public void Post([FromBody] PersonaDto entity)
        { 
            _personaService.InsertDto(entity);
        }
    }
}
