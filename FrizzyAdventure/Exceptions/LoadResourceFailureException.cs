namespace FrizzyAdventure.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    internal sealed class LoadResourceFailureException : BaseGameException
    {
        public LoadResourceFailureException()
        {
        }

        public LoadResourceFailureException(string message) : base(message)
        {
        }

        public LoadResourceFailureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public LoadResourceFailureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}