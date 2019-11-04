using ElClima.ApplicationServices.Services;
using ElClima.Domain.Core.Repository;
using ElClima.Domain.Model.Enums.Common;
using ElClima.Domain.Model.Models.Comun;
using System.Collections.Generic;
using System.Linq;

namespace ElClima.ApplicationServices.Setup.Common
{
    internal static class ContactoTipoInitializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<ContactoTipo>
            {
                new ContactoTipo(ContactoTipoEnum.Celular),
                new ContactoTipo(ContactoTipoEnum.Telefono),
                new ContactoTipo(ContactoTipoEnum.Email),
                new ContactoTipo(ContactoTipoEnum.Fax)
            };
            var service = new Service<ContactoTipo>(unitOfWork);
            var contactos = service.GetAll();

            foreach(var item in predeterminados)
            {
                if(contactos.All(exist => item.nombre != exist.nombre))
                {
                    var encontrado = false;

                    foreach(var contacto in contactos)
                    {
                        if (item.Equals(contacto))
                        {
                            encontrado = true;
                            if (item.nombre != contacto.nombre)
                            {
                                //Hay cambios, actualizo.
                                contacto.nombre = item.nombre;
                                service.Update(contacto);
                            }
                        }
                    }

                    if (!encontrado)
                    {
                        service.Insert(item);
                    }
                }
            }
        }
    }
}
