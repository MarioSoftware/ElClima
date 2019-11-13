using System.Collections.Generic;

namespace ElClima.Authorization.IdentityHelper
{
    public  class RegisterResultDto
    {
        public bool success { get; set; }

        public List<string> messages { get; set; }
    }
}
