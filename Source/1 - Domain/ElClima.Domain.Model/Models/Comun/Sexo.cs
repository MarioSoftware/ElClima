using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Enums.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Comun
{
    public class Sexo : BaseEntity
    {
        public string nombre { get; set; }

        public Sexo()
        {
        }

        public Sexo(SexoEnum sexo)
        {
            id = (int)sexo;
            nombre = sexo.GetDescription();
        }

        public override string ToString()
        {
            return $"{nombre} ({id})";
        }
    }
}
