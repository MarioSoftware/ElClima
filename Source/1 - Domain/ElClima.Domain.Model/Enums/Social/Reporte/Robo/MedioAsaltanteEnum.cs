using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Enums.Social.Reporte.Robo
{
    public enum MedioAsaltanteEnum
    {
        [Description("Motocicleta")]
        Motocicleta = 1,

        [Description("Automovil")]
        Automovil = 2,

        [Description("A pie")]
        APie = 3,

        [Description("No definido")]
        NoDefinido = 4
    }

    public static partial class Extensions
    {
        public static string GetDescription(this MedioAsaltanteEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
