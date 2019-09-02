using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Historia
{
    public class ComentarioImagen : BaseEntity
    {
        public Imagen imagen { get; set; }

        public string descripcion { get; set; }

        public DateTime fechaHoraCreada { get; set; }

        public Persona persona { get; set; }
    }
}
