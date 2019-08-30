using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Historia
{
   public class ImageneHistoria : BaseEntity
    {
        public string descripcion { get; set; }

        public Historia historia { get; set; }

        public DateTime fechaHoraSubida { get; set; }

        public string observacion { get; set; }

        public Persona persona { get; set; }

        public bool contribuidaExternamente { get; set; }
    }
}
