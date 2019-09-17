using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Perdida
{
    public class ComentarioImagen : BaseEntity
    {
        public Comentario comentario { get; set; }

        public DateTime fechaHoraSubida { get; set; }

        public string descripcion { get; set; }
    }
}
