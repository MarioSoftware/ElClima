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
    internal static class TipoVehiculoInitializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<TipoVehiculo>
            {
                new TipoVehiculo(TipoVehiculoEnum.Automovil),
                new TipoVehiculo(TipoVehiculoEnum.Bicicleta),
                new TipoVehiculo(TipoVehiculoEnum.CarroACaballo),
                new TipoVehiculo(TipoVehiculoEnum.Colectivo),
                new TipoVehiculo(TipoVehiculoEnum.Motocicleta)
            };
            var service = new Service<TipoVehiculo>(unitOfWork);
            var tipoVehiculos = service.GetAll();

            foreach(var item in predeterminados)
            {
                if(tipoVehiculos.All(exist => item.nombre != exist.nombre))
                {
                    var encontrado = false;

                    foreach(var tipoVehiculo in tipoVehiculos)
                    {
                        if (item.Equals(tipoVehiculo))
                        {
                            encontrado = true;
                            if (item.nombre != tipoVehiculo.nombre)
                            {
                                //Hay cambios, actualizo.
                                tipoVehiculo.nombre = item.nombre;
                                service.Update(tipoVehiculo);
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
