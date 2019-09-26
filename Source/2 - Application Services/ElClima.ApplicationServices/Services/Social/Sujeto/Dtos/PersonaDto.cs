using ElClima.ApplicationServices.Services.Comun;
using ElClima.Domain.Model.Models.Comun;
using System;
using System.Collections.Generic;
using System.Text;

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

        public UbicacionDto ubicacion { get; set; }

        public int idSexo { get; set; }

        public List<DomicilioDto> domicilios { get; set; }

        public List<Sexo> comboSexo { get; set; }
    }
}
