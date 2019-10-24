using System;
using System.ComponentModel;

namespace ElClima.Domain.Model.Enums.Social.Sujeto
{
    public enum OperacionEnum
    {
        [Description("CommonFunctions.Todo")]
        CommonFunctionsTodo = 1,

        [Description("SpecialFunctions.Especial")]
        SpecialFunctionsEspecial = 2
    }

    public static partial class Extensions
    {
        public static string GetDescription(this OperacionEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute
                ? attribute.Description
                : value.ToString();
        }
    }
}
