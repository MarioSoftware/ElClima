using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Posicionamiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Perdida
{
    public class UbicacionPerdida : BaseEntity
    {
        public Perdida perdida { get; set; }

        public string observacion { get; set; }

        public string imagen { get; set; }

        public Ubicacion ubicacion { get; set; }
    }
}
