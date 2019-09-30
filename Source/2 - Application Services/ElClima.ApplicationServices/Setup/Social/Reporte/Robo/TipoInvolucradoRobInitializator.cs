using ElClima.ApplicationServices.Services;
using ElClima.Domain.Core.Repository;
using ElClima.Domain.Model.Enums.Social.Reporte.Robo;
using ElClima.Domain.Model.Models.Social.Reporte.Robo;
using System.Collections.Generic;
using System.Linq;

namespace ElClima.ApplicationServices.Setup.Social.Reporte.Robo
{
    internal static class TipoInvolucradoRobInitializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<TipoInvolucradoRobo>
            {
                new TipoInvolucradoRobo(TipoInvolucradoRoboEnum.Auto),
                new TipoInvolucradoRobo(TipoInvolucradoRoboEnum.Moto),
                new TipoInvolucradoRobo(TipoInvolucradoRoboEnum.Otro),
                new TipoInvolucradoRobo(TipoInvolucradoRoboEnum.Persona) 
            };
            var service = new Service<TipoInvolucradoRobo>(unitOfWork);
            var tiposInvolucradoRobo = service.GetAll();

            foreach (var item in predeterminados)
            {
                if (tiposInvolucradoRobo.All(exist => item.detalle != exist.detalle))
                {
                    var encontrado = false;

                    foreach (var tipoInvolucradoRobo in tiposInvolucradoRobo)
                    {
                        if (item.Equals(tipoInvolucradoRobo))
                        {
                            encontrado = true;
                            if (item.detalle != tipoInvolucradoRobo.detalle)
                            {
                                //Hay cambios, actualizo.
                                tipoInvolucradoRobo.detalle = item.detalle;
                                service.Update(tipoInvolucradoRobo);
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
