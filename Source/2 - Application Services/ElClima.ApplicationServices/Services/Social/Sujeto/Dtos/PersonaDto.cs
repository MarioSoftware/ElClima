using ElClima.ApplicationServices.Services.Comun;

namespace ElClima.ApplicationServices.Services.Social.Sujeto.Dtos
{
    public class PersonaDto 
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string dni { get; set; }

        public string alias { get; set; }

        public string fechaNacimiento { get; set; } 

        public int idSexo { get; set; }

        public string contrasenia { get; set; } 

        public UbicacionDto ubicacion { get; set; }

        public DomicilioDto domicilio { get; set; }

        public string email { get; set; }

        //public List<ContactoDto> contactos { get; set; }
    }
}
