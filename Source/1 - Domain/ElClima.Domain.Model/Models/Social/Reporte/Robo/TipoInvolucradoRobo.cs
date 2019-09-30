using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Enums.Social.Entidad;
using ElClima.Domain.Model.Enums.Social.Reporte.Robo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Robo
{
    public class TipoInvolucradoRobo : BaseEntity
    {
        public TipoInvolucradoRobo()
        {

        }

        public TipoInvolucradoRobo(TipoInvolucradoRoboEnum tipoInvolucrado)
        {
            id = (int)tipoInvolucrado;
            detalle = tipoInvolucrado.GetDescription();
        }

        public string detalle { get; set; }

        public override string ToString()
        {
            return $"{detalle} ({id})";
        }
    }
}
