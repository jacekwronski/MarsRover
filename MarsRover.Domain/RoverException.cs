
using System;

namespace MarsRover.Domain
{
    public class RoverException : System.Exception
    {
        public Position LastPosition { get; protected set; }
        public RoverException(Position position)
        {
            this.LastPosition = position;
        }
        public RoverException(string message, Position position) : base(message)
        {
            this.LastPosition = position;
        }
        public RoverException(string message, System.Exception inner, Position position) : base(message, inner)
        {
            this.LastPosition = position;
        }
        protected RoverException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context,
            Position position) : base(info, context)
        {
            this.LastPosition = position;
        }
    }
}