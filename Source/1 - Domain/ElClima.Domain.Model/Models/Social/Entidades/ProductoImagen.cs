using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class ProductoImagen : BaseEntity
    {
        public Producto producto { get; set; }

        public string descripcion { get; set; }

        public DateTime fechaHoraSubida { get; set; }
    }
}
