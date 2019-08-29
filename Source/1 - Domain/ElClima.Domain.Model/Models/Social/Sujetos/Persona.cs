using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Models.Social.Sujetos
{
    public class Persona : BaseEntity
    {
        public string apellido { get; set; }

        public string nombre { get; set; }

        public string dni { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public int idDireccionNacimiento { get; set; }

        public int idDireccionActual { get; set; }

    }
}
