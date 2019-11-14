namespace ElClima.Domain.Core.Utils
{
    public static class IntegerHelper
    {
        public static int ValidOrInvalidStringToInteger(string value)
        {
            return int.TryParse(value, out var number) ? number : 0;
        }
    }
}
