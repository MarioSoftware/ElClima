using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class Comentario : BaseEntity
    {
        public Servicio servicio { get; set; }

        public Persona persona { get; set; }

        public TipoComentario tipoComentario { get; set; }

        public DateTime fechaHoraCreacion { get; set; }

        public string descripcion { get; set; }
    }
}
