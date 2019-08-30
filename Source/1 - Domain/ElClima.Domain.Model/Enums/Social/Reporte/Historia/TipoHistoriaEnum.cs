using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Enums.Social.Reporte.Historia
{
    public enum TipoHistoriaEnum
    {
        
        [Description("Historia")]
        Historia = 1,

        [Description("Pegunta")]
        Pegunta = 2,

        [Description("Perdida")]
        Perdida = 3

    }

    public static partial class Extensions
    {
        public static string GetDescription(this TipoHistoriaEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
