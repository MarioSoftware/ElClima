using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class LineaProducto : BaseEntity
    {
        public Servicio servicio { get; set; }

        public string descripcion { get; set; }

        public DateTime fechaHoraCreado { get; set; }

        public string observacion { get; set; }

        public DateTime fechaHoraUltimaActualizacion { get; set; }
    }
}
