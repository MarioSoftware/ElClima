using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElClima.ApplicationServices.Setup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElClima.FrontEnd.WebApi.InitializeDb
{
     
    public class InitializeDbController : Controller
    {
        public IActionResult Index()
        {
            var s = new DbSetup();
            try
            {
                s.InitializeDatabase();
            }
            catch (Exception ex)
            {
                return Content(ex.Message + ex.InnerException?.Message);
            }

            return Content("Base de datos inicializada correctamente");

        }

    }
}