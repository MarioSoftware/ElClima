using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Enums.Social.Reporte
{
    public enum TipoDenunciaEnum
    {
        [Description("Violencia de genero")]
        ViolenciaGenero = 1,

        [Description("Disturbio")]
        Disturbio = 2,

        [Description("Incendio")]
        Incendio = 3,

        [Description("Tiroteo")]
        Tiroteo = 4,

        [Description("Accidente")]
        Accidente = 5,

        [Description("Fraude")]
        Fraude = 6
    }

    public static partial class Extensions
    {
        public static string GetDescription(this TipoDenunciaEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
