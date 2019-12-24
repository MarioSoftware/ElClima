using Microsoft.Extensions.Options;
using System; 

namespace ElClima.FrontEnd.Config
{
    public class ElClimaConfiguration
    {
        public enum ElClimaEnvironment
        {
            Devs,
            Daily,
            Test,
            Production
        }

        private readonly IOptions<ElClimaConfigurationOptions> _options;

        public ElClimaConfiguration(IOptions<ElClimaConfigurationOptions> options)
        {
            _options = options;
        }

        public ElClimaEnvironment GetEnvironment()
        {
            switch (_options.Value.Environment.ToLower())
            {
                case "production":
                    return ElClimaEnvironment.Production;

                case "test":
                    return ElClimaEnvironment.Test;

                case "daily":
                    return ElClimaEnvironment.Daily;

                case "devs":
                    return ElClimaEnvironment.Devs;
                default:
                    throw new ApplicationException("No se ha podido establecer el ambiente de ejecución. Verifique la sección ElClima en appsettings.json");
            }
        }
    }
}
