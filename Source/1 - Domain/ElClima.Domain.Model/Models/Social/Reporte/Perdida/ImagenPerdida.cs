using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Perdida
{
    public class ImagenPerdida : BaseEntity
    {
        public string descripcion { get; set; }

        public Perdida perdida { get; set; }

        public DateTime fechaHoraSubida { get; set; }

        public string imagen { get; set; }
    }
}
