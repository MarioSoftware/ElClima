using ElClima.ApplicationServices.Services.Comun;
using ElClima.ApplicationServices.Services.Social.Sujeto;
using ElClima.ApplicationServices.Services.Social.Sujeto.Dtos;
using ElClima.FrontEnd.WebApi.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet("/api/Persons/Edit/{id}")]
        [AllowAnonymous]
        public PersonaDto Get(int id)
        {
            return _personaService.GetDto(id);
        }

        [HttpGet("/api/Persons/GetLocalities/{idProvince}/{text}")]
        public List<LocalidadLiteDto> GetComboLocalities(int idProvince, string text)
        {
            return _personaService.GetComboLocalities(idProvince, text);
        }

        [HttpPost("/api/Persons/Add")]
        public void Post([FromBody] PersonaDto entity)
        { 
            _personaService.InsertDto(entity);
        }

        [HttpGet("/api/Persons/Exist/{dni}")]
        public bool CheckPersonExist(string dni)
        { 
            return _personaService.ExistPerson(dni);
        }
    }
}
