using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Comun
{
    public class Localidad : BaseEntity
    {
        public Localidad()
        {
            provincia = new Provincia();
        }

        public string nombre { get; set; }
        public Provincia provincia{ get; set; }
        public string codigoPostal { get; set; }

        public override string ToString()
        {
            return $"{nombre} ({id})";
        }
    }
}
