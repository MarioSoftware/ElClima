using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Enums.Social.Reporte
{
    public enum TipoVehiculoEnum
    {
        [Description("Motocicleta")]
        Motocicleta = 1,

        [Description("Automovil")]
        Automovil = 2,

        [Description("Colectivo")]
        Colectivo = 3,

        [Description("Bicicleta")]
        Bicicleta = 4,

        [Description("Carro a caballo")]
        CarroACaballo = 5
    }

    public static partial class Extensions
    {
        public static string GetDescription(this TipoVehiculoEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
