using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Enums.Social.Entidad;
using ElClima.Domain.Model.Enums.Social.Reporte.Robo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Robo
{
    public class MedioAsaltante : BaseEntity
    {
        public MedioAsaltante()
        {

        }

        public MedioAsaltante(MedioAsaltanteEnum medioAsaltante)
        {
            id = (int)medioAsaltante;
            detalle = medioAsaltante.GetDescription();
        }

        public string detalle { get; set; }

        public override string ToString()
        {
            return $"{detalle} ({id})";
        }
    }
}
