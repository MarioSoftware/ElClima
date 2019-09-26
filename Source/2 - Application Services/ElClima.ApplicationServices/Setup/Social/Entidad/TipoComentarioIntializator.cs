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
    internal static class TipoComentarioIntializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            var predeterminados = new List<TipoComentario>
            {
                new TipoComentario(TipoComentarioEnum.Comentario),
                new TipoComentario(TipoComentarioEnum.Consulta) 
            };
            var service = new Service<TipoComentario>(unitOfWork);
            var tiposComentario = service.GetAll();

            foreach(var item in predeterminados)
            {
                if(tiposComentario.All(exist => item.detalle != exist.detalle))
                {
                    var encontrado = false;

                    foreach(var tipoComentario in tiposComentario)
                    {
                        if (item.Equals(tipoComentario))
                        {
                            encontrado = true;
                            if (item.detalle != tipoComentario.detalle)
                            {
                                //Hay cambios, actualizo.
                                tipoComentario.detalle = item.detalle;
                                service.Update(tipoComentario);
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
