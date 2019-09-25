using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ElClima.FrontEnd.Controllers
{
    public class AccountController : Controller
    {
         
        public IActionResult Add()
        {
            ViewBag.Id = -1;
            return View("AccountForm");
        }
    }
}