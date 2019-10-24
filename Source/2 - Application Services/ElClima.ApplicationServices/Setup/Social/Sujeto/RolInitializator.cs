using ElClima.ApplicationServices.Services;
using ElClima.Domain.Core.Repository;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System.Collections.Generic;
using System.Linq;

namespace ElClima.ApplicationServices.Setup.Social.Sujeto
{
    internal static class RolInitializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<Rol>
            {
                new Rol {detalle="Administrador", esSuperUsuario=true},
            };

            var services = new Service<Rol>(unitOfWork);
            var tipos = services.GetAll();

            foreach (var item in predeterminados)
            {
                if(tipos.All(exist => item.detalle != exist.detalle))
                {
                    services.Insert(item);
                }
            }
        }
    }
}
