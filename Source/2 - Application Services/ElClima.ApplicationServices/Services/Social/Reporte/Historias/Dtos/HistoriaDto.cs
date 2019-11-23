using ElClima.ApplicationServices.Services.Comun;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.ApplicationServices.Services.Social.Reporte.Historias.Dtos
{
    public class HistoriaDto 
    {
        public int id { get; set; }

        public  UbicacionDto ubicacion{ get; set; }

        public string descripcion  { get; set; }

        public string fechaHoraCreada { get; set; }

        public int idPersona { get; set; }

        string observacion { get; set; }

        public bool aportarImagen { get; set; }

    }
}
