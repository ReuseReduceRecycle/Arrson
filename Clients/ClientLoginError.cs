using System;
using System.Runtime.Serialization;

namespace Clients
{
    [Serializable]
    internal class ClientLoginError : Exception
    {
        public ClientLoginError()
        {
        }

        public ClientLoginError(string message) : base(message)
        {
        }

        public ClientLoginError(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientLoginError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}