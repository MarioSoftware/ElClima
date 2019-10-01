using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Comun;
using ElClima.Domain.Model.Models.Posicionamiento;
using System;

namespace ElClima.Domain.Model.Models.Social.Sujetos
{
    public class Domicilio : BaseEntity
    {
        public Persona persona { get; set; }

        public string calle { get; set; }

        public int numero { get; set; }

        public int piso { get; set; }

        public string numeroDepartamento { get; set; }

        public Provincia provincia{ get; set; }

        public Localidad localidad { get; set; }

        public Barrio barrio{ get; set; }
        
        public DateTime fechaHoraCreacion { get; set; }

        public DateTime fechaHoraUltimaActualizacion { get; set; }

        public Ubicacion ubicacionActual { get; set; }
    }
}
