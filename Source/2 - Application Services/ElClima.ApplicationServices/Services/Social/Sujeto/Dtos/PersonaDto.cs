using ElClima.ApplicationServices.Services.Comun;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.ApplicationServices.Services.Social.Sujeto.Dtos
{
    public class PersonaDto : BaseDto
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string dni { get; set; }

        public string fechaNacimiento { get; set; }

        public UbicacionDto ubicacion { get; set; }

        public int idSexo { get; set; }
    }
}
