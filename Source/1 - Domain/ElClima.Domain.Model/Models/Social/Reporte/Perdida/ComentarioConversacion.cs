﻿using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Reporte.Perdida
{
    public class ComentarioConversacion : BaseEntity
    {
        public Comentario comentario { get; set; }

        public string descripcion { get; set; }

        public Persona persona { get; set; }

        public DateTime fechaHoraCreado { get; set; }
    }
}
