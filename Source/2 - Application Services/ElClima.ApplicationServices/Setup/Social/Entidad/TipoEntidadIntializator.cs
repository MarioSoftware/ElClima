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
    internal static class TipoEntidadIntializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<TipoEntidad>
            {
                new TipoEntidad(TipoEntidadEnum.Bar),
                new TipoEntidad(TipoEntidadEnum.BarCafe),
                new TipoEntidad(TipoEntidadEnum.Carniceria),
                new TipoEntidad(TipoEntidadEnum.Clinica),
                new TipoEntidad(TipoEntidadEnum.Dietetica),
                new TipoEntidad(TipoEntidadEnum.EscuelaPublica),
                new TipoEntidad(TipoEntidadEnum.Farmacia),
                new TipoEntidad(TipoEntidadEnum.Fiambreria),
                new TipoEntidad(TipoEntidadEnum.Laboratorio),
                new TipoEntidad(TipoEntidadEnum.MaxiKiosco),
                new TipoEntidad(TipoEntidadEnum.Panaderia)
            };
            var service = new Service<TipoEntidad>(unitOfWork);
            var tiposEntidad = service.GetAll();

            foreach(var item in predeterminados)
            {
                if(tiposEntidad.All(exist => item.detalle != exist.detalle))
                {
                    var encontrado = false;

                    foreach(var tipoEntidad in tiposEntidad)
                    {
                        if (item.Equals(tipoEntidad))
                        {
                            encontrado = true;
                            if (item.detalle != tipoEntidad.detalle)
                            {
                                //Hay cambios, actualizo.
                                tipoEntidad.detalle = item.detalle;
                                service.Update(tipoEntidad);
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
