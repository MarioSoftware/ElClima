namespace ElClima.Authorization
{
    public static partial class AuthorizationHelper
    {
        public static string GetUserName(string name, string apellido)
        {
            var nameValid = "";
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(apellido))
            {
                name = name.Trim();
                apellido = apellido.Trim();

                nameValid = string.Concat(name.Replace(" ", string.Empty) + apellido.Replace(" ", string.Empty)); 
            }

            return nameValid;
        }
         
    }
}
