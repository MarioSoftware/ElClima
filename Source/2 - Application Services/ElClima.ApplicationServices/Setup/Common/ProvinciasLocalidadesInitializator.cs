using ElClima.ApplicationServices.Services;
using ElClima.Domain.Core.Repository;
using ElClima.Domain.Model.Models.Comun;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElClima.ApplicationServices.Setup.Common
{
    internal static class ProvinciasLocalidadesInitializator
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {

            var provinciasJson =  Resources.ResourceManager.GetString("provinciasa_json");
            var localidadesJson = Properties.Resources.ResourceManager.GetString("localidades_json");

            var provinciasPredeterminadas = JsonConvert.DeserializeObject<List<ProvinciaArgentinaJson>>(provinciasJson);
            var localidadesPredeterminadas = JsonConvert.DeserializeObject<List<LocalidadArgentinaJson>>(localidadesJson);

            // Creamos una lista de localidades con su provincia
            var localidadesProvinciasJoin = (from localidad in localidadesPredeterminadas
                                             join provincia in provinciasPredeterminadas
                                                 on localidad.IdProvincia equals provincia.ProvinciaId
                                                 into grouping
                                             from provincia in grouping.DefaultIfEmpty()
                                             select new { localidad, provincia }).ToList();

            //Inicializamos provincias primero
            var provinciaService = new Service<Provincia>(unitOfWork);
            var provincias = provinciaService.GetAll();
            //var paisService = new Service<Pais>(unitOfWork);
            //var argentina = paisService.GetOne((int)PaisEnum.Argentina);

            var provinciasAInsertar = new List<Provincia>();
            foreach (var item in provinciasPredeterminadas)
            {
                if (provincias.All(exist => item.Detalle != exist.nombre))
                {
                    var provincia = new Provincia
                    {
                        id = item.ProvinciaId,
                        nombre = item.Detalle, 
                    };

                    provinciasAInsertar.Add(provincia);
                }
            }

            provinciaService.BulkInsertOrUpdate(provinciasAInsertar);


            //Luego las localidades
            var localidadService = new Service<Localidad>(unitOfWork);
            var localidades = localidadService.GetAll();
            //provincias = provinciaService.GetByFilter(f => f.Pais == argentina);
     

            var localidadesAInsertar = new List<Localidad>();
            foreach (var item in localidadesProvinciasJoin)
            {
                if (localidades.All(exist => item.localidad.Detalle != exist.nombre))
                {
                    var localidadAInsertar = new Localidad
                    {
                        nombre = item.localidad.Detalle,
                        provincia = provincias.SingleOrDefault(f => f.nombre == item.provincia.Detalle), 
                        codigoPostal = item.localidad.CodigoPostal
                    };

            

                    // Lo marcamos para dar de alta pero no lo damos de alta aqui.
                    localidadesAInsertar.Add(localidadAInsertar);
                   
                }
            }

            localidadService.BulkInsertOrUpdate(localidadesAInsertar);

            // Aqui se dan todas las altas.
            //unitOfWork.SaveChanges();

        }


        private class ProvinciaArgentinaJson
        {
            public int ProvinciaId { get; set; }
            public string Detalle { get; set; }
            public int IdPais { get; set; }
        }

        private class LocalidadArgentinaJson
        {
            public int LocalidadId { get; set; }
            public string Detalle { get; set; }
            public int IdProvincia { get; set; }
            public string CodigoPostal { get; set; }
        }               
    }
}
