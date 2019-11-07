using ElClima.ApplicationServices.Services.Comun;
using ElClima.Domain.Model.Models.Comun;
using System.Collections.Generic;

namespace ElClima.ApplicationServices.Services.Social.Sujeto.Dtos
{
    public class DomicilioDto
    {
        public int id { get; set; }

        public string calle { get; set; }

        public int? numero { get; set; }

        public int? piso { get; set; }

        public string departamento { get; set; }

        public string barrio { get; set; }

        public int idProvincia { get; set; }

        public LocalidadLiteDto localidad { get; set; }

        public UbicacionDto ubicacion { get; set; } 

        public List<Provincia> comboProvincia { get; set; }

        public List<LocalidadLiteDto> comboLocalidad { get; set; } 
    }
}
