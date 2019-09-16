using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Perdida
{
    public class Perdida : BaseEntity
    {
        public string descripcion { get; set; }

        public string informacionUtil { get; set; }

        public DateTime fechaHoraPerdida { get; set; }

        public DateTime fechaHoraCreada { get; set; }

        public Persona persona{ get; set; }

        public bool encontrado { get; set; }
    }
}
