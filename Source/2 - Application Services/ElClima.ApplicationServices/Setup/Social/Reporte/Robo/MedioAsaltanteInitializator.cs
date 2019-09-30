using ElClima.ApplicationServices.Services;
using ElClima.Domain.Core.Repository;
using ElClima.Domain.Model.Enums.Social.Reporte.Robo;
using ElClima.Domain.Model.Models.Social.Reporte.Robo;
using System.Collections.Generic;
using System.Linq;

namespace ElClima.ApplicationServices.Setup.Social.Reporte.Robo
{
    internal static class MedioAsaltanteInitializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<MedioAsaltante>
            {
                new MedioAsaltante(MedioAsaltanteEnum.APie),
                new MedioAsaltante(MedioAsaltanteEnum.Automovil),
                new MedioAsaltante(MedioAsaltanteEnum.Motocicleta),
                new MedioAsaltante(MedioAsaltanteEnum.NoDefinido) 
            };
            var service = new Service<MedioAsaltante>(unitOfWork);
            var mediosAsaltante = service.GetAll();

            foreach (var item in predeterminados)
            {
                if (mediosAsaltante.All(exist => item.detalle != exist.detalle))
                {
                    var encontrado = false;

                    foreach (var medioAsaltante in mediosAsaltante)
                    {
                        if (item.Equals(medioAsaltante))
                        {
                            encontrado = true;
                            if (item.detalle != medioAsaltante.detalle)
                            {
                                //Hay cambios, actualizo.
                                medioAsaltante.detalle = item.detalle;
                                service.Update(medioAsaltante);
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
