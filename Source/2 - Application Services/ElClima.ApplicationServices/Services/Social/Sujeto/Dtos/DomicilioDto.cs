﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.ApplicationServices.Services.Social.Sujeto.Dtos
{
    public class DomicilioDto
    { 
        public string calle { get; set; }

        public int numero { get; set; }

        public int piso { get; set; }

        public string numeroDepartamento { get; set; }
       
        public string fechaHoraCreacion { get; set; }

        public string fechaHoraUltimaActualizacion { get; set; }

        public int Idprovincia { get; set; }

        public int IdDepartamento { get; set; }

        public int IdUbicacionActual { get; set; }

        public int Idbarrio { get; set; }
    }
}
