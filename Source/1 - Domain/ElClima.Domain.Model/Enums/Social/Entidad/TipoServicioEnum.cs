using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ElClima.Domain.Model.Enums.Social.Entidad
{
    public enum TipoServicioEnum
    {
        [Description("Seguro")]
        Seguro = 1,

        [Description("Reparacion")]
        Reparacion = 2,

        [Description("Venta")]
        Venta = 3,

        [Description("Compra")]
        Compra = 4,

        [Description("Compra y venta")]
        CompraVenta = 5,

       [Description("Software a medida ")]
        SoftwarePersonalizado = 6
    }

    public static partial class Extensions
    {
        public static string GetDescription(this TipoServicioEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
