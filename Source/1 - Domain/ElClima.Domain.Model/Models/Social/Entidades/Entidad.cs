using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class Entidad : BaseEntity
    {
        public TipoEntidad tipoEntidad { get; set; }

        public string descripcion { get; set; }
    }
}
