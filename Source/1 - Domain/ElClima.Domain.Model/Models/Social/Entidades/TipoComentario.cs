using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Enums.Social.Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class TipoComentario : BaseEntity
    {
        public TipoComentario()
        {

        }

        public TipoComentario(TipoComentarioEnum tipoEntidad)
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
