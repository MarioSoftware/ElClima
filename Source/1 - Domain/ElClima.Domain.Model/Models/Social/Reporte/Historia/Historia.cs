using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Posicionamiento;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Historia
{
    public class Historia : BaseEntity
    {
        public string descripcion { get; set; }

        public Ubicacion ubicacion { get; set; }

        public DateTime fechaHoraCreada { get; set; }

        public Persona persona { get; set; }

        string  observacion { get; set; }

        public bool aportarImagen { get; set; }

    }
}
