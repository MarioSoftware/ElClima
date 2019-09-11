using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.ApplicationServices.Services
{
    public class BaseDto
    {
        public BaseDto()
        {
            CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            CurrentTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm");
            CurrentDate = DateTime.Today.ToShortDateString();
        }
        public string CurrentCulture { get; }
        public string CurrentTime { get; set; }
        public string CurrentDate { get; set; }
    }
}
