using ElClima.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Social.Sujetos
{
    public class RolPersona : BaseEntity
    { 
        public Persona persona { get; set; }

        public Rol rol { get; set; }
    }
}
