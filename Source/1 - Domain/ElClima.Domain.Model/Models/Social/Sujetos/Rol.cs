using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Sujetos
{
    public class Rol : BaseEntity
    {
        public Rol()
        {
            rolPersona = new List<RolPersona>();
        }

        public string detalle { get; set; }

        public bool esSuperUsuario { get; set; }

        public ICollection<RolPersona> rolPersona { get; set; }
    }
}
