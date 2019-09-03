using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Posicionamiento;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class Producto : BaseEntity
    { 

        public LineaProducto lineaProducto { get; set; }

        public string descripcion { get; set; }

        public DateTime fechaHoraCrecion { get; set; }

        public decimal precio { get; set; }

        public bool disponible { get; set; }

        public DateTime fechaHoraUltimaActualizacion { get; set; }
    }
}
