using System;
using System.Runtime.Serialization;

namespace TrainsLibrary
{
    [Serializable]
    internal class NoRouteException : Exception
    {
        public NoRouteException()
        {
        }

        public NoRouteException(string message) : base(message)
        {
        }

        public NoRouteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoRouteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}