namespace FrizzyAdventure.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    internal abstract class BaseGameException : Exception
    {
        public BaseGameException()
        {
        }

        public BaseGameException(string message) : base(message)
        {
        }

        public BaseGameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BaseGameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}