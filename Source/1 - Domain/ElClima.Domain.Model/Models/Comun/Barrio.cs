using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Comun
{
    public class Barrio : BaseEntity
    {
        public Barrio()
        {
            localidad = new Localidad();
        }

        public string nombre { get; set; }
        public Localidad localidad { get; set; }

        public override string ToString()
        {
            return $"{nombre} ({id})";
        }
    }
}
