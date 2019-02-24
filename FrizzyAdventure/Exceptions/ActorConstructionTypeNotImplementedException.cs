namespace FrizzyAdventure.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    internal sealed class ActorConstructionTypeNotImplementedException : BaseGameException
    {
        public ActorConstructionTypeNotImplementedException()
        {
        }

        public ActorConstructionTypeNotImplementedException(string message) : base(message)
        {
        }

        public ActorConstructionTypeNotImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ActorConstructionTypeNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}