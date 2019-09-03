using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class ComentarioServicio : BaseEntity
    {
        public Servicio servicio { get; set; }

        public Persona persona { get; set; }

        public TipoComentario tipoComentario { get; set; }

        public DateTime fechaHoraCreacion { get; set; }

        public string descripcion { get; set; }

        public string imagen1 { get; set; }

        public string imagen2 { get; set; }

        public string imagen3 { get; set; }
    }
}
