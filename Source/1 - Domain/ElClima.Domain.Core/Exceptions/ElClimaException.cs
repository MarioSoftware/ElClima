using System;

namespace ElClima.Domain.Core.Exceptions
{
    public class ElClimaException : Exception
    {
        public ElClimaException()
           : base() { }

        public ElClimaException(string message)
            : base(message) { }

        public ElClimaException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ElClimaException(string message, Exception innerException)
            : base(message, innerException) { }

        public ElClimaException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
