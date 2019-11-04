using Microsoft.AspNetCore.Identity;

namespace ElClima.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        public string dni { get; set; }

        public string apellido { get; set; }
    }
}
