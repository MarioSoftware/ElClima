using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class ServicioImagen : BaseEntity
    {
        public Servicio servicio { get; set; }

        public string descripcion { get; set; }

        public DateTime fechaHoraSubida { get; set; }

        public string imagen { get; set; }
    }
}
