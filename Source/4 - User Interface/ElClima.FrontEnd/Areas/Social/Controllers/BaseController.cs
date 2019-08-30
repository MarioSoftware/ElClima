using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ElClima.FrontEnd.Areas.Social.Controllers
{
    [Area("Social")]
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View("Base");
        }
    }
}