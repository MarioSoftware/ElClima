using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ElClima.Domain.Model.Enums.Social.Entidad
{
    public enum TipoComentarioEnum
    {
        [Description("Comentario")]
        Comentario = 1,

        [Description("Consulta")]
        Consulta = 2,

       
    }

    public static partial class Extensions
    {
        public static string GetDescription(this TipoComentarioEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
