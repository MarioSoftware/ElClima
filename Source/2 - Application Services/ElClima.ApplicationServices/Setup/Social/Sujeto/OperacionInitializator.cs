using ElClima.ApplicationServices.Services;
using ElClima.Domain.Core.Repository;
using ElClima.Domain.Model.Enums.Social.Sujeto;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System.Collections.Generic;
using System.Linq;

namespace ElClima.ApplicationServices.Setup.Social.Sujeto
{
    internal static class OperacionInitializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<Operacion>
            {
                new Operacion (OperacionEnum.CommonFunctionsTodo),
                new Operacion (OperacionEnum.SpecialFunctionsEspecial)
            };

            var service = new Service<Operacion>(unitOfWork);
            var tipos = service.GetAll();

            foreach (var item in predeterminados)
            {
                if (tipos.All(exist => item.nombre != exist.nombre))
                {
                    var encontrado = false;

                    foreach (var operacion in tipos)
                    {
                        if (item.Equals(operacion))
                        {
                            encontrado = true;
                            if (item.nombre != operacion.nombre)
                            {
                                //Hay cambios, actualizo.
                                operacion.nombre = item.nombre;
                                service.Update(operacion);
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
