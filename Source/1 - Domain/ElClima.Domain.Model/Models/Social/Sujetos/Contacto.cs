using ElClima.Domain.Model.Models.Comun;

namespace ElClima.Domain.Model.Models.Social.Sujetos
{
    public class Contacto
    {
        public ContactoTipo contactoTipo { get; set; }

        public Persona persona { get; set; }

        public string contacto { get; set; }
    }
}
