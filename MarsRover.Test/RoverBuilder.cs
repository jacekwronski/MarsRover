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

        private Direction direction = Direction.East;
        public Rover Build()
        {
            rover.Initialize(x, y, direction);
            return rover;
        }

        public RoverBuilder WithInitialStateLeftBottomEast()
        {
            this.x = 0;
            this.y = 0;
            this.direction = Direction.East;

            return this;
        }

        public RoverBuilder WithInitialStateLeftBottomNorth()
        {
            this.x = 0;
            this.y = 0;
            this.direction = Direction.North;

            return this;
        }

        public RoverBuilder WithInitialDirectionWest()
        {
            this.direction = Direction.West;
            return this;
        }

        public RoverBuilder WithInitialDirectionSouth()
        {
            this.direction = Direction.South;
            return this;
        }

        public RoverBuilder WithInitialPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            return this;
        }

    }
}