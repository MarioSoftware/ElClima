using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Enums.Social.Reporte.Historia;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Historia
{
    public class TipoHistoria : BaseEntity
    {
        public TipoHistoria()
        {

        }

        public TipoHistoria(TipoHistoriaEnum tipoEntidad)
        {
            id = (int)tipoEntidad;
            detalle = tipoEntidad.GetDescription();
        }

        public string detalle { get; set; }

        public override string ToString()
        {
            return $"{detalle} ({id})";
        }
    }
}
