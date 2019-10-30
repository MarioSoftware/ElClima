using ElClima.Domain.Core.Entities;

namespace ElClima.Domain.Model.Models.Comun
{
    public class Localidad : BaseEntity
    {
        public Localidad()
        {
            provincia = new Provincia();
        }

        public string nombre { get; set; }
        public Provincia provincia{ get; set; }
        public string codigoPostal { get; set; }
         
    }
}
