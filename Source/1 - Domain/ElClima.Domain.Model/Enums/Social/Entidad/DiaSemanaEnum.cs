using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ElClima.Domain.Model.Enums.Social.Entidad
{
    public enum DiaSemanaEnum
    {
        [Description("Lunes")]
        Lunes = 1,

        [Description("Martes")]
        Martes = 2,

        [Description("Miercoles")]
        Miercoles = 3,

        [Description("Jueves")]
        Jueves = 4,

        [Description("Viernes")]
        Viernes = 5,

        [Description("Sabado")]
        Sabado = 6,

        [Description("Domingo")]
        Domingo = 7
    }

    public static partial class Extensions
    {
        public static string GetDescription(this DiaSemanaEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
