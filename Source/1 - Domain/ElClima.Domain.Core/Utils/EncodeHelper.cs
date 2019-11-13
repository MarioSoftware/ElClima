using System;
using System.Text;

namespace ElClima.Domain.Core.Utils
{
    public static class EncodeHelper
    {
        public static string DecodeFromBase64String(string encodedText)
        {
            if (encodedText != null && encodedText.Contains(" "))
                encodedText = encodedText.Replace(" ", "+");

            return string.IsNullOrWhiteSpace(encodedText)
                ? ""
                : Encoding.UTF8.GetString(Convert.FromBase64String(encodedText));
        }

        public static string EncodeToBase64String(string textToEncode)
        {
            return string.IsNullOrWhiteSpace(textToEncode)
                ? ""
                : Convert.ToBase64String(Encoding.UTF8.GetBytes(textToEncode));
        }
    }
}
