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
    internal static class DiaSemanaInitializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<DiaSemana>
            {
                new DiaSemana(DiaSemanaEnum.Domingo),
                new DiaSemana(DiaSemanaEnum.Jueves),
                new DiaSemana(DiaSemanaEnum.Lunes),
                new DiaSemana(DiaSemanaEnum.Martes),
                new DiaSemana(DiaSemanaEnum.Miercoles),
                new DiaSemana(DiaSemanaEnum.Sabado),
                new DiaSemana(DiaSemanaEnum.Viernes)

            };
            var service = new Service<DiaSemana>(unitOfWork);
            var dias = service.GetAll();

            foreach(var item in predeterminados)
            {
                if(dias.All(exist => item.detalle != exist.detalle))
                {
                    var encontrado = false;

                    foreach(var dia in dias)
                    {
                        if (item.Equals(dia))
                        {
                            encontrado = true;
                            if (item.detalle != dia.detalle)
                            {
                                //Hay cambios, actualizo.
                                dia.detalle = item.detalle;
                                service.Update(dia);
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
