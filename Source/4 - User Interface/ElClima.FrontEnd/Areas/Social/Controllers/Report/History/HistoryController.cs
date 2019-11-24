using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElClima.FrontEnd.Areas.Social.Controllers.Reporte.History
{
    [Area("Social")]
  
    public class HistoryController : Controller
    {
        [Route("/Social/History/Add")]
        [AllowAnonymous]
        public IActionResult Add()
        {
            return View("../Report/History/_HistoryForm");
        }
    }
}