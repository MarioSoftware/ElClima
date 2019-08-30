using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Enums.Social.Reporte.Robo
{
    public enum TipoObjetoRobadoEnum
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
        Indefinido = 5 
    }

    public static partial class Extensions
    {
        public static string GetDescription(this TipoObjetoRobadoEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
