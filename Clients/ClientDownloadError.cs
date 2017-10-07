using System;
using System.Runtime.Serialization;

namespace Clients
{
    [Serializable]
    internal class ClientDownloadError : Exception
    {
        public ClientDownloadError()
        {
        }

        public ClientDownloadError(string message) : base(message)
        {
        }

        public ClientDownloadError(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientDownloadError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}