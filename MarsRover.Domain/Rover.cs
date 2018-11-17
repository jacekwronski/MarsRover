using System;

namespace MarsRover.Domain
{
    public class Rover
    {
        public Position Position { get; protected set;}

        private IWorld myWorld;
        
        public Rover() { }

        public void Initialize(int x, int y, DirectionEnum direction, IWorld world)
        {
            this.Position = new Position(x, y, direction);
            this.myWorld = world;
        }

        public void MoveForward()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Forward, myWorld);
            this.Position = movement.Move();
        }

        public void MoveBackward()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Backward, myWorld);
            this.Position = movement.Move();
        }

        public void MoveLeft() 
        {
            Movement movement = new Movement(this.Position, MovementEnum.Left, myWorld);
            this.Position = movement.Move();
        }

        public void MoveRight()
        {
            Movement movement = new Movement(this.Position, MovementEnum.Right, myWorld);
            this.Position = movement.Move();
        }
    }
}