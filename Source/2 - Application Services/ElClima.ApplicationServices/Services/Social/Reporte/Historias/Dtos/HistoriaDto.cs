using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.ApplicationServices.Services.Social.Reporte.Historias.Dtos
{
    public class HistoriaDto 
    {
        public int id { get; set; }

        public int idUbicacion { get; set; }

        public string fechHoraCreada { get; set; }

        public int idPersona { get; set; }

        public bool aportarImagen { get; set; }

    }
}
