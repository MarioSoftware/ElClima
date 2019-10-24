using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Enums.Social.Sujeto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Sujetos
{
    public class Operacion: BaseEntity
    {
        public Operacion()
        { 
        }

        public Operacion(OperacionEnum operacion)
        {
            id = (int)operacion;
            nombre = operacion.GetDescription();
        }

        public string nombre { get; set; }
    }
}
