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
            departamento = new Departamento();
        }

        public string nombre { get; set; }
        public Departamento departamento { get; set; }

        public override string ToString()
        {
            return $"{nombre} ({id})";
        }
    }
}
