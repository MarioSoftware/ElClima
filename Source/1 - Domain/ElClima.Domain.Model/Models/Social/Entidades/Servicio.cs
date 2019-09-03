using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class Servicio : BaseEntity
    {
        public Entidad entidad { get; set; }

        public TipoServicio tipoServicio { get; set; }

        public string descripcion { get; set; }

        public string observacion { get; set; }

        public string foto { get; set; }
    }
}
