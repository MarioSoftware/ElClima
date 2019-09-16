using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Perdida
{
    public class ConversacionImagen : BaseEntity
    {
        public Conversacion conversacion{ get; set; }

        public DateTime fechaHoraSubida { get; set; }

        public string observacion { get; set; }
    }
}
