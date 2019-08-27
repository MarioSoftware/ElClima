using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Posicionamiento
{
    public class Ubicacion : BaseEntity
    {
        public  string longitud { get; set; }

        public string latitud { get; set; }

        public string direccion { get; set; }
    }
}
