using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Enums.Social.Reporte.Robo
{
    public enum TipoInvolucradoRoboEnum
    {
        [Description("Persona")]
        Persona = 1,

        [Description("Moto")]
        Moto = 2,

        [Description("Auto")]
        Auto = 3,

        [Description("Otro")]
        Otro = 4 
    }

    public static partial class Extensions
    {
        public static string GetDescription(this TipoInvolucradoRoboEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
