using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Entidades
{
    public class DiaHorarioDisponible : BaseEntity
    {
        public DiaSemana dia { get; set; }

        public Entidad entidad { get; set; }

        public string horaDesde { get; set; }

        public string horaHasta { get; set; }

        public string horaDesdeSegundoTurno { get; set; }

        public string horaHastaSegundoTurno { get; set; }
    }
}
