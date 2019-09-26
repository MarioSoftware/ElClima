using ElClima.ApplicationServices.Services;
using ElClima.Domain.Core.Repository;
using ElClima.Domain.Model.Enums.Common;
using ElClima.Domain.Model.Models.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElClima.ApplicationServices.Setup.Common
{
    internal static class SexoInitializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<Sexo>
            {
                new Sexo(SexoEnum.Femenino),
                new Sexo(SexoEnum.Masculino)
            };
            var service = new Service<Sexo>(unitOfWork);
            var sexos = service.GetAll();

            foreach(var item in predeterminados)
            {
                if(sexos.All(exist => item.nombre != exist.nombre))
                {
                    var encontrado = false;

                    foreach(var sexo in sexos)
                    {
                        if (item.Equals(sexo))
                        {
                            encontrado = true;
                            if (item.nombre != sexo.nombre)
                            {
                                //Hay cambios, actualizo.
                                sexo.nombre = item.nombre;
                                service.Update(sexo);
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
