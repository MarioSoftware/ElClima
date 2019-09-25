using Microsoft.AspNetCore.Mvc;
using System; 

namespace ElClima.FrontEnd.WebApi.BaseController
{
    public class BaseWebApiController : Controller
    {
        public BaseWebApiController()
        {

        }


        [HttpGet("/api/BaseApi/GetCurrentTime")]
        public string GetCurrentTime()
        {
            var now = DateTime.Now;
            return now.ToShortDateString() + " " + now.ToString("HH:mm");
        }
    }
}
