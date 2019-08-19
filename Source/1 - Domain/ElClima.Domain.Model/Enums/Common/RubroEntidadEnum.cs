using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Enums.Common
{
    public enum RubroEntidadEnum
    {
        [Description("Carniceria")]
        Carniceria=1,

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
        public static string GetDescription(this RubroEntidadEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }

}
