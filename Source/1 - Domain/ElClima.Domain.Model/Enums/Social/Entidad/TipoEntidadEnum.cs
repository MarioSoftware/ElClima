using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ElClima.Domain.Model.Enums.Social.Entidad
{
    public enum TipoEntidadEnum
    {
        [Description("Carniceria")]
        Carniceria = 1,

        [Description("Panaderia")]
        Panaderia = 2,

        [Description("Dietetica")]
        Dietetica = 3,

        [Description("Bar")]
        Bar = 4,

        [Description("BarCafe")]
        BarCafe = 5,

        [Description("MaxiKiosco")]
        MaxiKiosco = 6,

        [Description("Fiambreria")]
        Fiambreria = 7,

        [Description("Farmacia")]
        Farmacia = 8,

        [Description("Clinica")]
        Clinica = 9,

        [Description("Laboratorio")]
        Laboratorio = 9,

        [Description("EscuelaPublica")]
        EscuelaPublica = 9
    }

    public static partial class Extensions
    {
        public static string GetDescription(this TipoEntidadEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
