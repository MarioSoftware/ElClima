using ElClima.ApplicationServices.Services.Comun;
using ElClima.ApplicationServices.Services.Social.Reporte.Historias;
using ElClima.ApplicationServices.Services.Social.Reporte.Historias.Dtos;
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
    public class HistoryController : BaseWebApiController
    {
        private readonly HistoriaService _historyService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HistoryController(IHostingEnvironment hostingEnvironment)
        {
            _historyService = new HistoriaService();
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("/api/History/Get/{id}")]
        [Authorize]
        public HistoriaDto Get(int id)
        {
            return _historyService.GetDto(id);
        }

      
    }
}
