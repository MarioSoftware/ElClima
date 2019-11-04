using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Enums.Common;

namespace ElClima.Domain.Model.Models.Comun
{
    public class ContactoTipo : BaseEntity
    {
        public string nombre { get; set; }

        public ContactoTipo()
        {
        }

        public ContactoTipo(ContactoTipoEnum contactoTipo)
        {
            id = (int)contactoTipo;
            nombre = contactoTipo.GetDescription();
        }

        public override string ToString()
        {
            return $"{nombre} ({id})";
        }
    }
}
