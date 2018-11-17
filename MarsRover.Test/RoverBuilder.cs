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

        private DirectionEnum direction = DirectionEnum.East;

        private IWorld world;
        public Rover Build()
        {
            rover.Initialize(x, y, direction, world);
            return rover;
        }

        public RoverBuilder WithInitialStateLeftBottomEast()
        {
            this.x = 0;
            this.y = 0;
            this.direction = DirectionEnum.East;

            return this;
        }

        public RoverBuilder WithInitialStateLeftBottomNorth()
        {
            this.x = 0;
            this.y = 0;
            this.direction = DirectionEnum.North;

            return this;
        }

        public RoverBuilder WithInitialDirectionWest()
        {
            this.direction = DirectionEnum.West;
            return this;
        }

        public RoverBuilder WithInitialDirectionSouth()
        {
            this.direction = DirectionEnum.South;
            return this;
        }

        public RoverBuilder WithInitialDirectionEast()
        {
            this.direction = DirectionEnum.East;
            return this;
        }

        public RoverBuilder WithInitialDirectionNorth()
        {
            this.direction = DirectionEnum.North;
            return this;
        }

        public RoverBuilder WithInitialPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            return this;
        }

        public RoverBuilder WithWorld(IWorld world) 
        {
            this.world = world;

            return this;
        }

    }
}