using MarsRover.Domain;

namespace MarsRover.Test
{
    public class RoverBuilder
    {
        public RoverBuilder()
        {}

        Rover rover = new Rover();
        private int x = 0;
        private int y = 0;

        private string direction = "E";
        public Rover Build()
        {
            rover.Initialize(x, y, direction);
            return rover;
        }

        public RoverBuilder WithInitialStateLeftBottomEast()
        {
            this.x = 0;
            this.y = 0;
            this.direction = "E";

            return this;
        }
    }
}