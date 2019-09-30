using System;
using System.ComponentModel;

namespace ElClima.Domain.Model.Enums.Social.Reporte.Robo
{
    public enum ObjetoRobadoEnum
    {
        [Description("Auto")]
        Auto = 1,

        [Description("Moto")]
        Moto = 2,

        [Description("Celular")]
        Celular = 3,

        [Description("Cartera")]
        Cartera = 4,

        [Description("Indefinido")]
        Indefinido = 5,

        [Description("Billetera")]
        Billetera = 6,

        [Description("Bicicleta")]
        Bicicleta = 7,

        [Description("Laptop")]
        Laptop = 8,
    }

    public static partial class Extensions
    {
        public static string GetDescription(this ObjetoRobadoEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
