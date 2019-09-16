using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Posicionamiento;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Perdida
{
    public class Comentario : BaseEntity
    {
        public Perdida perdida { get; set; }

        public Persona persona { get; set; }

        public string comentario { get; set; }

        public Ubicacion ubicacion { get; set; }

        public DateTime fechaHoraCreacion { get; set; }      
    }
}
