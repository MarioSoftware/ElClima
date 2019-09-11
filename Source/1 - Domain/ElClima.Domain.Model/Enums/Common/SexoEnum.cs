using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElClima.Domain.Model.Enums.Common
{
    public enum SexoEnum
    {
        [Description("Masculino")]
        Masculino = 1,

        [Description("Femenino")]
        Femenino=2
    }

    public static partial class Extensions
    {
        public static string GetDescription(this SexoEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
