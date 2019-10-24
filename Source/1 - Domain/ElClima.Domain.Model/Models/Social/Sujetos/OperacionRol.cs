using ElClima.Domain.Core.Entities;

namespace ElClima.Domain.Model.Models.Social.Sujetos
{
    public class OperacionRol : BaseEntity
    {
        public OperacionRol()
        { 
        }

        public Operacion operacion { get; set; }

        public Rol rol { get; set; }
    }
}
