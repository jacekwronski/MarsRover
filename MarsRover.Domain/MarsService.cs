using System;

namespace MarsRover.Domain
{
    public class MarsService : IMarsService
    {
        private readonly IWorld world;
        private Rover rover;
        public MarsService(IWorld world)
        {
            this.world = world;
        }

        public Position LandRover(int x, int y, DirectionEnum direction)
        {
            this.rover = new Rover();
            this.rover.Initialize(x, y, direction, world);

            return new Position(rover.Position.X, rover.Position.Y, rover.Position.Direction);
        }

        public Position MoveRover(string[] commands)
        {
            this.rover.Move(commands);

            return new Position(rover.Position.X, rover.Position.Y, rover.Position.Direction);
        }
    }
}