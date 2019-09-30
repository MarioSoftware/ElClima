using ElClima.ApplicationServices.Services;
using ElClima.Domain.Core.Repository;
using ElClima.Domain.Model.Enums.Social.Reporte.Robo;
using ElClima.Domain.Model.Models.Social.Reporte.Robo;
using System.Collections.Generic;
using System.Linq;

namespace ElClima.ApplicationServices.Setup.Social.Reporte.Robo
{
    internal static class ObjetoRobadoInitializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<ObjetoRobado>
            {
                new ObjetoRobado(ObjetoRobadoEnum.Auto),
                new ObjetoRobado(ObjetoRobadoEnum.Cartera),
                new ObjetoRobado(ObjetoRobadoEnum.Celular),
                new ObjetoRobado(ObjetoRobadoEnum.Moto),
                new ObjetoRobado(ObjetoRobadoEnum.Bicicleta),
                new ObjetoRobado(ObjetoRobadoEnum.Billetera),
                new ObjetoRobado(ObjetoRobadoEnum.Laptop),
                new ObjetoRobado(ObjetoRobadoEnum.Indefinido)
            };
            var service = new Service<ObjetoRobado>(unitOfWork);
            var objetosRobados = service.GetAll();

            foreach (var item in predeterminados)
            {
                if (objetosRobados.All(exist => item.detalle != exist.detalle))
                {
                    var encontrado = false;

                    foreach (var objetoRobado in objetosRobados)
                    {
                        if (item.Equals(objetoRobado))
                        {
                            encontrado = true;
                            if (item.detalle != objetoRobado.detalle)
                            {
                                //Hay cambios, actualizo.
                                objetoRobado.detalle = item.detalle;
                                service.Update(objetoRobado);
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
