using ElClima.ApplicationServices.Services;
using ElClima.Domain.Core.Repository;
using ElClima.Domain.Model.Enums.Common;
using ElClima.Domain.Model.Enums.Social.Entidad;
using ElClima.Domain.Model.Models.Comun;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElClima.ApplicationServices.Setup.Social.Entidad
{
    internal static class TipoServicioIntializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<TipoServicio>
            {
                new TipoServicio(TipoServicioEnum.Compra),
                new TipoServicio(TipoServicioEnum.CompraVenta),
                new TipoServicio(TipoServicioEnum.Reparacion),
                new TipoServicio(TipoServicioEnum.Seguro),
                new TipoServicio(TipoServicioEnum.SoftwarePersonalizado),
                new TipoServicio(TipoServicioEnum.Venta) 
            };
            var service = new Service<TipoServicio>(unitOfWork);
            var tiposServicio = service.GetAll();

            foreach(var item in predeterminados)
            {
                if(tiposServicio.All(exist => item.detalle != exist.detalle))
                {
                    var encontrado = false;

                    foreach(var tipoServicio in tiposServicio)
                    {
                        if (item.Equals(tipoServicio))
                        {
                            encontrado = true;
                            if (item.detalle != tipoServicio.detalle)
                            {
                                //Hay cambios, actualizo.
                                tipoServicio.detalle = item.detalle;
                                service.Update(tipoServicio);
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
