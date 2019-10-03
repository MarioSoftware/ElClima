using ElClima.ApplicationServices.Services.Comun;
using ElClima.Domain.Model.Models.Comun;
using ElClima.Domain.Model.Models.Posicionamiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.ApplicationServices.Services.Social.Sujeto.Dtos
{
    public class DomicilioDto
    {
        public int idPersona { get; set; }

        public string calle { get; set; }

        public int numero { get; set; }

        public int piso { get; set; }

        public string numeroDepartamento { get; set; } 

        public int idprovincia { get; set; }

        public int idLocalidad { get; set; }

        public UbicacionDto ubicacionActual { get; set; }

        public string barrio { get; set; }

        public List<Provincia> comboProvincia { get; set; }

        public List<Localidad> comboLocalidad { get; set; } 
    }
}
