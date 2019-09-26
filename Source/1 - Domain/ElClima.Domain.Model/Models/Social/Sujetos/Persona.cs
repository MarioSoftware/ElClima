using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Enums.Common;
using ElClima.Domain.Model.Models.Comun;
using ElClima.Domain.Model.Models.Posicionamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Models.Social.Sujetos
{
    public class Persona : BaseEntity
    {
        public Persona()
        {
            //ubicacionActual = new Ubicacion();
            sexo = new Sexo(SexoEnum.Masculino);
            fechaNacimiento = new DateTime(); 
        }
        public string apellido { get; set; }

        public string nombre { get; set; }

        public string dni { get; set; }

        public string alias{ get; set; }

        public DateTime fechaNacimiento { get; set; }

        public Ubicacion ubicacionActual{ get; set; }

        public Sexo sexo { get; set; }

        public ICollection<Domicilio> domicilios{ get; set; } 
    }
}
