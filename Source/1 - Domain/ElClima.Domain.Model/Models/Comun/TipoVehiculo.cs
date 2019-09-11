using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Enums.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Domain.Model.Models.Comun
{
    public class TipoVehiculo : BaseEntity
    {
        public string nombre { get; set; }

        public TipoVehiculo()
        {
        }

        public TipoVehiculo(TipoVehiculoEnum tipoVehiculo)
        {
            id = (int)tipoVehiculo;
            nombre = tipoVehiculo.GetDescription();
        }

        public override string ToString()
        {
            return $"{nombre} ({id})";
        }
    }
}
