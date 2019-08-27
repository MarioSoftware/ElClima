using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Enums.Social.Reporte
{
    public enum TipoReporteEnum
    {
        [Description("Robo")]
        Robo = 1,

        [Description("Accidente")]
        Automovil = 2 
    }

    public static partial class Extensions
    {
        public static string GetDescription(this TipoReporteEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
