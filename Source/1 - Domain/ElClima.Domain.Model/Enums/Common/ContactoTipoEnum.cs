using System;
using System.ComponentModel;

namespace ElClima.Domain.Model.Enums.Common
{
    public enum ContactoTipoEnum
    {
        [Description("Celular")]
        Celular = 1,

        [Description("Telefono")]
        Telefono = 2,

        [Description("Fax")]
        Fax = 3,

        [Description("Email")]
        Email = 4
    }

    public static partial class Extensions
    {
        public static string GetDescription(this ContactoTipoEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
