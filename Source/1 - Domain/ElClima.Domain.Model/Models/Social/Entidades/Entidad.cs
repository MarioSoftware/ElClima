using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Posicionamiento;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class Entidad : BaseEntity
    {
        public TipoEntidad tipoEntidad { get; set; }

        public string descripcion { get; set; } 
          
        public DateTime fechaHoraCreacion { get; set; } 

        public Persona propietario { get; set; }

        public Persona creador { get; set; }

        public Ubicacion ubicacion { get; set; }
    }
}
