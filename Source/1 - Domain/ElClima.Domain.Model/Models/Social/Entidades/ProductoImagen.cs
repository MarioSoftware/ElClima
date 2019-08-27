using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    class ProductoImagen
    {
        public Producto producto { get; set; }

        public string descripcion { get; set; }

        public DateTime fechaHoraSubida { get; set; }
    }
}
